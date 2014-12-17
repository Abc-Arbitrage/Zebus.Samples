# Zebus Samples
## Getting started 
1. Open src/Zebus.Samples.sln in Visual Studio 2010 or later
2. Restore NuGet packages and build solution
3. Start the 'in memory directory' located in _src\packages\Zebus.Directory.Standalone.[version]\tools\Abc.Zebus.Directory.exe_

## Sample details
### 1. Publishing an event
This sample shows you how to publish an event from a peer, and handle it in another.
The **Publish.Sender** console application will simply publish an event (`SomethingHappened`) every 500ms. 

The **Publish.Listener** console application will listen to this event type and log something every time it receives it.

![](https://github.com/Abc-Arbitrage/Zebus.Samples/raw/master/img/1.1.png)
