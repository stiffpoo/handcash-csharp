[![License][License-Image]][License-URL] [![NuGet](https://img.shields.io/nuget/v/NBitcoin.svg)](https://www.nuget.org/packages/NBitcoin)
# handcash-csharp

C# Library for HandCash's API @ http://handcash.io/api-docs

## Installation

With NuGet :
>**Install-Package handcash-csharp** 

See the [NuGet Package](https://www.nuget.org/packages/handcash-csharp/) for more information.

### Dependencies
Utilising [RestSharp](https://github.com/restsharp/RestSharp) | [Nuget Package](https://www.nuget.org/packages/RestSharp/)

## Usage

using statement
```c#
using HandCash;
```
GetReceivingAddress from $handle by specifying Handcash.Network
```c#
string receivingAddress = HandCash.GetReceivingAddress("rjseibane", HandCash.Network.MainNet);
Console.WriteLine(receivingAddress);
```
GetPublicKey from $handle by specifying Handcash.Network
```c#
string publicKey = HandCash.GetPublicKey("rjseibane", HandCash.Network.MainNet);
Console.WriteLine(publicKey);
```
GetObject returns HandleObject Class
```c#
var handleObject = HandCash.GetObject("rjseibane", HandCash.Network.MainNet);
```
```c#
public class HandleObject
{
    public string ReceivingAddress { get; set; }
    public string PublicKey { get; set; }
}
```
## Special Thanks

To the [HandCash](http://handcash.io/) devs for building a clean, quick and feature rich Bitcoin Cash Wallet with simple, user-friendly $handles !

To [zquestz](https://github.com/zquestz) for the inspiration to write and publish my first library and respository!
May be small and simple but you know what they say, "you'll always remember your first" :)

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/stiffpoo/handcash-csharp.

## License

This library is available as open source under the terms of the [MIT License](https://opensource.org/licenses/MIT).

[License-URL]: http://opensource.org/licenses/MIT
[License-Image]: https://img.shields.io/npm/l/express.svg
