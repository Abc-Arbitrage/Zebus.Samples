using Abc.Zebus;
using ProtoBuf;

namespace Zebus.Samples.Common.Messages
{
    [ProtoContract]
    public class SomethingHappened : IEvent
    {
    }
}
