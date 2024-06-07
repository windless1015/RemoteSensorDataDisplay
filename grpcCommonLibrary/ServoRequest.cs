using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpcCommonLibrary
{
    [ProtoContract]
    public class ServoRequest
    {
        [ProtoMember(1)]
        public int code;
    }
}
