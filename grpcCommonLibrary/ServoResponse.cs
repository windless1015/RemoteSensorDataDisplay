using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpcCommonLibrary
{
    [ProtoContract]
    public class ServoResponse
    {
        [ProtoMember(1)]
        public bool result;
    }
}
