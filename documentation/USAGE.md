# BotFramwork Usage

Hello fellow modder, glad to have you here.

The BotFramework mod is built on the idea of **extending** the classes it provides.

The motiviation for this was the realization that in order to turn my [WaterBot](https://github.com/andyruwruw/stardew-valley-water-bot) into a HarestBot, the majority of the code would have needed to be modified.

Instead, the BotFramework provides a system that is *open to extension, and closed to modification*. Inheritance is king here.

If you are seeing anything past the `BotFramework.Bot` class that you're needing to edit, I did something wrong, so send in an [issue or pull request](https://github.com/andyruwruw/stardew-valley-bot-framework/issues)!

Help me keep this framework as simple to use by sharing your feedback on the experience!

# Content

- [For Beginners](#for-beginners-or-skip-it)
- Required Steps
  - [Specifying Targets](#specifying-targets)
  - [Creating a Bot](#creating-a-bot)
- Optional Overrides
- Advanced Setups

# For Beginners or [Skip It](#creating-a-bot)

To begin you should have [Stardew Valley running with SMAPI](https://stardewvalleywiki.com/Modding:Player_Guide/Getting_Started).

Follow the [Install]() instructions on the README.md to get the BotFramework and be able to run Stardew Valley with it.

To start your own SMAPI mod, you'll want to start with [this tutorial](https://stardewvalleywiki.com/Modding:Modder_Guide/Get_Started).

On top of creating `ModEntry.cs`, you'll want to create a new file `YourBotName.cs`, naming it whatever you'd like!

# Specifying Targets

To begin you'll need to specify a [Target](./BotFramework/Framework/Targets/Targets.md) or set of Targets.

Targets can be one of the following:
- TileTarget
- Character Target
  - StardewValley.Character
    - StardewValley.Farmer
    - StardewValley.NPC
    - StardewValley.FarmAnimal
    - StardewValley.Monster
    - StardewValley.Pet
- ObjectTarget
  - StardewValley.Object

Targets specify **what** the Bot will find and navigate to, and also the **action** it will perform on said targets.

#### Examples:

```
Targets:
  TileTarget:
    - What: All un-hoed dirt with sprinkler
    - Action: Hoe the tile

Result: Bot hoes all un-hoed dirt under sprinklers.
```
```
Targets: 
  CharacterTarget:
    - What: All NPCs who I have not spoken to
    - Action: Talk to them

Result: Bot talks to every not talked to NPC.
```
```
Targets:
  ObjectTarget:
    - What: All broken fences
    - Action: Break and replace with new fence

Result: Bot replaces all broken fences.
```

You'll find targets give you a lot more control than just those simple examples.

You have the power to not only control **what** is valid, but also **how it is found**, **when it is called**, **condition to be executed**, **actionable range**.

#### Advanced Example:

```
Targets:
  TileTarget:
    - What: Hoed dirt with crop on it that is unwatered
    - QueryBehavior: Do for all
    - Call order: At location start
    - Action: Water tile with Watering Can
    - Actionable range: 1
  TileTarget:
    - What: Refillable water sources
    - Query method: Do for closest
    - Call Order: Before each
    - Condition: Watering can is empty
    - Action: Refill watering can
    - Actionable range: 1
```
```
Targets:
  ObjectTarget:
    - What: 

```

Targets can be of the type `Character`, `Tile`, or `StardewValley.Object`. Creating a target requires you to create an instance of a [CharacterTarget](./BotFramework/Framework/Targets/CharacterTarget.md), [ObjectTarget](./BotFramework/Framework/Targets/ObjectTarget.md) or [TileTarget](./BotFramework/Framework/Targets/TileTarget.md) respectively for each type.

# Creating a Bot

To make your own bot, you'll need to implement the abstract `BotFramework.Bot` class.

```
namespace YourProject
{
  class YourBot : BotFramework.Bot
  {

  }
}
```

There are a few functions you're **required** to override, some you can **optionally**, and some you **really shouldn't** unless you know what you're doing.