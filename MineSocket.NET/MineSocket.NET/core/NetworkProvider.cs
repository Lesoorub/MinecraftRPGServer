using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace MineServer
{
    public class NetworkProvider
    {
        public readonly NetworkStream stream;
        public readonly TcpClient client;
        public Queue<HistoryElement> history = new Queue<HistoryElement>();
        public int HitsoryMaxLength = 10;
        public bool connected = false;

        public delegate void DisconnectArgs(DisconnectReason reason);
        public delegate void ErrorArgs(Exception ex);
        public delegate void PacketRecievedArgs(BytesBasedPacket byte_packet);
        public delegate void ConnectArgs();

        public event DisconnectArgs OnDisconnected;
        public event ConnectArgs OnConnected;
        public event PacketRecievedArgs OnPacketRecieved;
        public event ErrorArgs OnError;

        public NetworkProvider(TcpClient client)
        {
            this.stream = client.GetStream();
            this.client = client;
        }

        public Func<byte[], byte[]> OnRecieveData = (byte[] data) => data;
        public Func<byte[], byte[]> OnSendData = (byte[] data) => data;

        public void Recieve()
        {
            connected = client.Connected;
            if (!client.Connected || !connected)
            {
                Disconnect();
                return;
            }

            OnConnected?.Invoke();
            while (client.Connected && connected)
            {
                BytesBasedPacket packet = null;
                try
                {
                    if (stream.ReadBytesToEndSync(out var bytes))
                    {
                        packet = new BytesBasedPacket(OnRecieveData(bytes));
                    }
                    else
                        connected = false;
                }
                catch (Exception ex)
                {
                    OnError?.Invoke(ex);
                    OnDisconnected?.Invoke(DisconnectReason.Error);
                    return;
                }
                finally
                {
                    if (packet != null)
                        OnPacketRecieved?.Invoke(packet);
                }
            }
            OnDisconnected?.Invoke(DisconnectReason.Normal);
        }

        public void Send(byte[] data)
        {
            send(data);
            AddToHistory(new BytesHistoryElement(data));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void send(byte[] data)
        {
            data = OnSendData(data);
            try
            {
                //Console.WriteLine($"[S->C, {GetType()}] " + data.ToDump());
                stream.Write(data, 0, data.Length);
            }
            catch
            {
                connected = false;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddToHistory(HistoryElement element)
        {
            history.Enqueue(element);
            if (history.Count > HitsoryMaxLength)
                history.Dequeue();
        }
        public void Send(string data)
        {
            send(Encoding.UTF8.GetBytes(data));
            AddToHistory(new StringHistoryElement(data));
        }
        public void Send(BytesBasedPacket packet)
        {
            send(packet.ToByteArray());
            AddToHistory(new BytesBasedPacketHistoryElement(packet));
        }
        public void Send(IPacket packet)
        {
            send(new BytesBasedPacket(packet).ToByteArray());
            AddToHistory(new IPacketHistoryElement(packet));
        }
        public void Disconnect() => connected = false;
    }

    public abstract class HistoryElement 
    {
        public DateTime time = DateTime.Now;
    }

    public sealed class BytesHistoryElement : HistoryElement
    {
        public byte[] data;

        public BytesHistoryElement(byte[] data)
        {
            this.data = data;
        }
        public override string ToString()
        {
            return $"time={time.Ticks} bytes={data.ToDump()}";
        }
    }
    public sealed class IPacketHistoryElement : HistoryElement
    {
        public IPacket packet;

        public IPacketHistoryElement(IPacket packet)
        {
            this.packet = packet;
        }
        public override string ToString()
        {
            return $"time={time.Ticks} packet_id={packet.package_id} IPacketBytes={new BytesBasedPacket(packet).ToByteArray().ToDump()}";
        }
    }
    public sealed class BytesBasedPacketHistoryElement : HistoryElement
    {
        public BytesBasedPacket packet;

        public BytesBasedPacketHistoryElement(BytesBasedPacket packet)
        {
            this.packet = packet;
        }
        public override string ToString()
        {
            return $"time={time.Ticks} packet={packet.ToByteArray().ToDump()}";
        }
    }
    public sealed class StringHistoryElement : HistoryElement
    {
        public string str;

        public StringHistoryElement(string str)
        {
            this.str = str;
        }
        public override string ToString()
        {
            return $"time={time.Ticks} string={str}";
        }
    }
}