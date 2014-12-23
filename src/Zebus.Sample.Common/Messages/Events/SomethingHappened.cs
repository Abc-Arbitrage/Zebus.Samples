using Abc.Zebus;
using ProtoBuf;

namespace Zebus.Sample.Common.Messages.Events
{
    [ProtoContract]
    public class SomethingHappened : IEvent
    {
    }
}
