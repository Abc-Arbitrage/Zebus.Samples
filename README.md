# Zebus Samples
## Getting started 
1. Open src/Zebus.Samples.sln in Visual Studio 2010 or later
2. Restore NuGet packages and build solution
3. Start the 'in memory directory' located in _src\packages\Zebus.Directory.Standalone.[version]\tools\Abc.Zebus.Directory.exe_

## Sample details
### 1. Publish event
This sample shows you how to publish an event from a peer, and listen to it in another.
The _Zebus.Samples.Publish.Sender_ console application will simply publish an event (SomethingHappened) every 500ms. The _Zebus.Samples.Publish.Listener_ console application will listen for this event type and log something every time it receives it.

![](https://github.com/Abc-Arbitrage/Zebus.Samples/raw/master/img/1.1.png)
