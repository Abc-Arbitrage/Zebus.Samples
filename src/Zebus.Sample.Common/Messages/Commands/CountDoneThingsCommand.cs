using Abc.Zebus;
using ProtoBuf;

namespace Zebus.Sample.Common.Messages.Commands
{
    [ProtoContract]
    public class CountDoneThingsCommand : ICommand
    {
        [ProtoMember(1,IsRequired = true)]
        public readonly int ThingsDoneCount;

        public CountDoneThingsCommand(int thingsDoneCount)
        {
            ThingsDoneCount = thingsDoneCount;
        }
    }
}