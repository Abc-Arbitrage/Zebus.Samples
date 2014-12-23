using System;
using System.Diagnostics;
using System.Threading;
using Abc.Zebus.Core;
using log4net;
using Zebus.Sample.Common;
using Zebus.Sample.Common.Messages.Commands;

namespace Zebus.Sample.Sending.Sender
{
    public class Publisher : SampleBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Publisher));
        private readonly Random _random = new Random(DateTime.UtcNow.Second);
        private readonly Stopwatch _stopwatch = new Stopwatch();

        protected override void Run(CancellationToken cancellationToken)
        {
            var busFactory = new BusFactory().WithScan()
                                             .WithConfiguration("tcp://localhost:129", "Demo")
                                             .WithPeerId("Publisher.*");

            using (var bus = busFactory.CreateAndStartBus())
            while (!cancellationToken.IsCancellationRequested)
            {
                _stopwatch.Restart();
                bus.Send(new CountDoneThingsCommand(_random.Next(1, 100)))
                   .Wait(cancellationToken); // wait until the command has been fully handled
                _stopwatch.Stop();

                _log.InfoFormat("The command has been handled in {0}", _stopwatch.Elapsed);
            }
        }
    }
}