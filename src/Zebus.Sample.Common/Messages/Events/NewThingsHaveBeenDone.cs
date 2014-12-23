using Abc.Zebus;
using ProtoBuf;

namespace Zebus.Sample.Common.Messages.Events
{
    [ProtoContract]
    public class NewThingsHaveBeenDone : IEvent
    {
        [ProtoMember(1, IsRequired = true)]
        public readonly int NewThingsDoneCount;

        [ProtoMember(2, IsRequired = true)]
        public readonly int TotalThingsDoneCount;

        public NewThingsHaveBeenDone(int newThingsDoneCount, int totalThingsDoneCount)
        {
            NewThingsDoneCount = newThingsDoneCount;
            TotalThingsDoneCount = totalThingsDoneCount;
        }
    }
}