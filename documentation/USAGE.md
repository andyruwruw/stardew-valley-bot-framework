# BotFramwork Usage

Hello fellow modder, glad to have you here.

The BotFramework mod is built on the idea of extending the classes it provides.

The motiviation for this was the realization that in order to turn my WaterBot into a HarestBot, the majority of the code would have needed to be modified.

Instead, the BotFramework provides a system that is *open to extension, and closed to modification*.

If you are seeing anything past the `BotFramework.Bot` class that you're needing to edit, I did something wrong, so send in an [issue or pull request](https://github.com/andyruwruw/stardew-valley-bot-framework/issues)!

# Creating a Bot

BotFramework is a SMAPI mod! There's a [tutorial here](https://stardewvalleywiki.com/Modding:Modder_Guide/Get_Started) if you're unfamiliar with how to start a new SMAPI mod. On top of creating `ModEntry.cs`, you'll want to repeat the process to create `YourBotName.cs`, naming it whatever you'd like!

To implement the BotFramework in your mod, you need to make a class to represent your bot. This class will [inherit](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance) from the `BotFramework.Bot` class.

```
using BotFramework;

namespace YourProject
{
  class YourBot : Bot
  {

  }
}
```