using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MineServer
{
    public abstract class MineServer
    {
        protected readonly TcpListener listener;
        protected readonly ushort port;
        public readonly Logger errorLoger = new Logger();
        List<Client> clients = new List<Client>();
        public delegate void StartArgs();
        public event StartArgs OnStart;
        public delegate void StopArgs();
        public event StopArgs OnStop;
        /// <summary>
        /// Recalc every time, slowly
        /// </summary>
        public IClient[] connected_clients => clients.Select(x => x.subclient).ToArray();

        bool _isStarted = false;
        public bool isStarted { get => _isStarted; private set => _isStarted = value; }
        public MineServer(ushort port)
        {
            this.port = port;
            listener = TcpListener.Create(this.port);
        }
        public static ManualResetEvent connectionWaiter = new ManualResetEvent(false);
        /// <summary>
        /// Start server, asynchronously
        /// </summary>
        public void Start() 
        {
            listener.Start();
            isStarted = true;
            OnStart?.Invoke();

            Task.Run(() =>
            {
                while (isStarted)
                {
                    connectionWaiter.Reset();
                    listener.BeginAcceptTcpClient(new AsyncCallback(OnAccept), listener);
                    connectionWaiter.WaitOne();
                }
            });
        }
        private void OnAccept(IAsyncResult ar)
        {
            var tcpclient = ((TcpListener)ar.AsyncState).EndAcceptTcpClient(ar);

            var ip = ((IPEndPoint)tcpclient.Client.RemoteEndPoint).Address;
            var client = new Client(ip, tcpclient);
            client.network.OnConnected += () => client.subclient = OnClientConnect(client);
            client.network.OnDisconnected += (reason) => OnClientDisconnect(client, reason);
            //client.network.OnPacketRecieved += (packet) => OnPacketRecieved(client, packet);
            client.network.OnError += (ex) => errorLoger.Write(ex.Message, nameof(MineServer));
            clients.Add(client);

            connectionWaiter.Set();
        }
        /// <summary>
        /// Stop server, asynchronously
        /// </summary>
        public void Stop()
        {
            connectionWaiter.Set();
            foreach (var cl in clients)
            {
                try
                {
                    cl.thread.Interrupt();
                    cl.thread.Join();
                    OnClientDisconnect(cl, DisconnectReason.Aborted);
                }
                catch
                {
                    continue;
                }
            }
            listener.Stop();
            isStarted = false;
            OnStop?.Invoke();
        }
        /// <summary>
        /// Faster than connected_clients
        /// </summary>
        /// <param name="predicate"></param>
        public void ConnectedClientsForeach(Action<IClient> predicate) => clients.ForEach(x => predicate(x.subclient));
        protected virtual IClient OnClientConnect(Client client) { return null; }
        protected virtual void OnClientDisconnect(Client client, DisconnectReason reason) { }

        public void SendTo(IPAddress ip, IPacket packet) => 
            SendTo(ip, new BytesBasedPacket(packet).ToByteArray());
        public void SendTo(IPAddress ip, byte[] data)
        {
            var target = clients.FirstOrDefault(x => x.ip.Equals(ip));
            if (target == null) return;
            target.network.Send(data);
        }
        public void Broadcast(IPacket packet) => 
            Broadcast(new BytesBasedPacket(packet).ToByteArray());
        public void Broadcast(byte[] buffer)
        {
            foreach (var cl in clients)
                cl.network.Send(buffer);
        }
        public void BroadcastWithout(IPacket packet, IPAddress ip) => 
            Broadcast(new BytesBasedPacket(packet).ToByteArray(), (xip) => !xip.Equals(ip));
        public void Broadcast(byte[] data, Func<IPAddress, bool> predicate)
        {
            foreach (var cl in clients)
                if (predicate(cl.ip))
                    cl.network.Send(data);
        }
        public void Broadcast(IPacket packet, Func<IPAddress, bool> predicate) =>
            Broadcast(new BytesBasedPacket(packet).ToByteArray(), predicate);

        public void ChangeSubClient(IClient last, IClient @new)
        {
            var client = clients.FirstOrDefault(x => x.subclient == last);
            if (client == null) return;
            client.subclient = @new;
            @new.server = last.server;
        }
        protected class Client
        {
            public readonly IPAddress ip;
            public readonly Thread thread;
            public readonly NetworkProvider network;
            public IClient subclient;

            public Client(IPAddress ip, TcpClient client)
            {
                this.ip = ip;
                this.network = new NetworkProvider(client);
                thread = new Thread(() => network.Recieve());
                this.thread.Start();
            }
        }
    }
}