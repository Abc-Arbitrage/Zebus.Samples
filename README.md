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

### 2. Sending a command
This sample shows you how to deal with commands : it demonstrates how a command is sent, how a peer handles a command and how the command handling can be awaited by the sender. It shows also how to use StructureMap to inject external dependencies in handlers (see the `ThingsDoneCounter` in the Listener's `CommandHandler`). **Important : you must start the listener before the sender(s). If you don't, the sender(s) will throw an `InvalidOperationException` because they are not able to send a command that is not handled by any peer**.

The **Sending.Listener** console application will handle the `CountDoneThingsCommand` command, increment a static counter with the value given in the command and then publish an event (`NewThingsHaveBeenDone`) telling all peer that listen this event the new value of the counter. The command handler will sleep for about 300 ms each time it handles a command in order to demonstrate how sender can actually wait for a command to be processed.

The **Sending.Sender** console application will send a `CountDoneThingsCommand` command and wait until the command is fully handled. This console will also listen for the `NewThingsHaveBeenDone` events and log them.

![](https://github.com/Abc-Arbitrage/Zebus.Samples/raw/master/img/2.1.png)