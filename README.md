[![License][License-Image]][License-URL] [![NuGet][NuGet-Image]][NuGet-Link]
# handcash-csharp

C# Library for HandCash's API @ http://handcash.io/api-docs

## Installation

#### With NuGet :
>**Install-Package handcash-csharp** 

See the [NuGet Package](https://www.nuget.org/packages/handcash-csharp/) for more information.

### Dependencies
Utilising [RestSharp](https://github.com/restsharp/RestSharp) | [Nuget Package](https://www.nuget.org/packages/RestSharp/)

## Usage

#### using statement
```c#
using HandCash;
```
#### Retrieve Address from $handle by specifying Handle.Network
```c#
string cashAddr = Handle.GetCashAddr("rjseibane", Handle.Network.MainNet);
Console.WriteLine(cashAddr);

string legacyAddr = Handle.GetLegacyAddr("rjseibane", Handle.Network.MainNet);
Console.WriteLine(legacyAddr);
```
#### Retrieve Public Key from $handle by specifying Handle.Network
```c#
string publicKey = Handle.GetPublicKey("rjseibane", Handle.Network.MainNet);
Console.WriteLine(publicKey);
```
#### Async Support
```c#
string cashAddr = await Handle.GetCashAddrAsync("rjseibane", Handle.Network.MainNet);
Console.WriteLine(cashAddr);
```
#### Get returns HandleObject Class
```c#
var handleObject = Handle.Get("rjseibane", Handle.Network.MainNet);
```
```c#
public class HandleObject
{
    public string ReceivingAddress { get; set; }
    public string CashAddr { get; set; }
    public string PublicKey { get; set; }
}
```
## Special Thanks

To the [HandCash](http://handcash.io/) devs for building a clean, quick and feature rich Bitcoin Cash Wallet with simple, user-friendly $handles !

To [zquestz](https://github.com/zquestz) for the inspiration to write and publish my first library and respository!
May be small and simple but you gotta start somewhere :)

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/stiffpoo/handcash-csharp.

## License

This library is available as open source under the terms of the [MIT License](https://opensource.org/licenses/MIT).

[License-URL]: http://opensource.org/licenses/MIT
[License-Image]: https://img.shields.io/github/license/mashape/apistatus.svg
[NuGet-Image]: https://img.shields.io/badge/nuget-v4.7.0-blue.svg
[NuGet-Link]: https://www.nuget.org/packages/handcash-csharp/
