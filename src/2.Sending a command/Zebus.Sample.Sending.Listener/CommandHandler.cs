using System;
using System.Threading;
using Abc.Zebus;
using log4net;
using Zebus.Sample.Common.Messages.Commands;
using Zebus.Sample.Common.Messages.Events;

namespace Zebus.Sample.Sending.Listener
{
    public class CommandHandler : ICommandHandler<CountDoneThingsCommand>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CommandHandler));
        private readonly IBus _bus;
        private readonly ThingsDoneCounter _counter;
        private readonly MessageContext _messageContext;

        public CommandHandler(IBus bus, ThingsDoneCounter counter, MessageContext messageContext)
        {
            _bus = bus;
            _counter = counter;
            _messageContext = messageContext;
        }

        public void Handle(CountDoneThingsCommand message)
        {
            // this is a seriously heavy processing
            Thread.Sleep(TimeSpan.FromMilliseconds(300));

            _counter.ThingsDoneSinceStartup += message.ThingsDoneCount;
            _log.InfoFormat("From peer {0}, handled in thread id {1} : {2} done things added, we've now done {3} things",
                            _messageContext.SenderId,
                            Thread.CurrentThread.ManagedThreadId,
                            message.ThingsDoneCount,
                            _counter.ThingsDoneSinceStartup);

            _bus.Publish(new NewThingsHaveBeenDone(message.ThingsDoneCount, _counter.ThingsDoneSinceStartup));
        }
    }
}