using ProtoBuf;

namespace grpcCommonLibrary
{
    [ProtoContract]
    public class SensorRequest
    {
        [ProtoMember(1)]
        public int param;
    }
}
