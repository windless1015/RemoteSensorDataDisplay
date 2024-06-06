using ProtoBuf;

namespace grpcCommonLibrary
{
    [ProtoContract]
    public class SensorResponse
    {
        [ProtoMember(1)]
        public double result;
    }
}
