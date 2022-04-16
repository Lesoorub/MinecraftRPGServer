using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets.Login
{
    //Server
    [BoundToServerPackage(State.Login)]
    public class LoginStart : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x00;

        public string name;
    }
    [BoundToServerPackage(State.Login)]
    public class EncryptionResponse : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x01;

        public byte[] SharedSecret;
        public byte[] VerifyToken;
    }
    [BoundToServerPackage(State.Login)]
    public class LoginPluginResponse : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x02;

        public VarInt MessageID;
        public bool Succesful;
        //OptionalByteArray Data;
    }
    //Client
    [BoundToClientPackage(State.Login)]
    public class Disconnect : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x00;

        public string reason;
    }
    [BoundToClientPackage(State.Login)]
    public class EncryptionRequest : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x01;

        public string ServerID;//const size is 20
        public byte[] PublicKey;
        public byte[] VerifyToken;
    }
    [BoundToClientPackage(State.Login)]
    public class LoginSuccess : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x02;

        public Guid uuid;
        public string username;
    }
    [BoundToClientPackage(State.Login)]
    public class SetCompression : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x03;

        public VarInt Threshold;
    }
    [BoundToClientPackage(State.Login)]
    public class LoginPluginRequest : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x04;

        public VarInt MessageID;
        public string Channel;
        //public byte[] Data; length is any data after channel field
    }
}
