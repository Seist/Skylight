Everybody Edits Software Development Kit by TakoMan02<br>

[![Build Status](https://travis-ci.org/Decagon/Skylight.svg?branch=master)](https://travis-ci.org/Decagon/Skylight)

http://www.everybodyedits.com/</br>

Skylight is designed to make your EE-based bot much easier to develop and understand.<br>

Special thanks to:<br>
<ul>
<li>@Jojatekok: Adding extra login features.</li>
<li>@kevin-brown: Providing a system for parsing init message; other OnMessage documentation.</li>
<li>@BuzzerBee: Finding bugs.</li>
<li>gustav9797: Porting physics engine to C#.</li>
<li>@Decagon (Hexagon): Many improvements.</li>
</ul>


Getting started with Skylight is easy. To connect, simply type:
```csharp
using PlayerIOClient;
using Rabbit;
using Skylight;
var myBot = new Bot(new Room("roomid"), "Email or token", "Password if applicable");
// delegates would be initialized here
myBot.Join();
```

The room id can be entered in as a full everybody edits url or just directly.
