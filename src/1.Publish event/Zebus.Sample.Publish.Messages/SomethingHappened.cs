using Abc.Zebus;
using ProtoBuf;

namespace Zebus.Samples.Publish.Messages
{
    [ProtoContract]
    public class SomethingHappened : IEvent
    {
    }
}
