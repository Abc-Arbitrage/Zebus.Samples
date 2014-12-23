﻿using System.Threading;
using Abc.Zebus.Core;
using Zebus.Sample.Common;
using Zebus.Sample.Common.Messages.Events;

namespace Zebus.Samples.Publish.Sender
{
    internal class Publisher : SampleBase
    {
        protected override void Run(CancellationToken cancellationToken)
        {
            var busFactory = new BusFactory().WithConfiguration("tcp://localhost:129", "Demo")
                                             .WithPeerId("Publisher.*");

            using (var bus = busFactory.CreateAndStartBus())
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    bus.Publish(new SomethingHappened());

                    Thread.Sleep(500);
                }
            }
        }
    }
}