# BotFramework For Developers

Hello fellow modder, glad to have you here. The BotFramework mod is built on the idea of **inheritance** and **extending** the classes it provides.

The motiviation for this framework was the realization that in order to turn my [WaterBot](https://github.com/andyruwruw/stardew-valley-water-bot) into a **HarestBot** or **MiningBot**, the majority of the code would have needed to be modified despite their simularities.

Instead, the BotFramework provides a system that is **open to extension, and closed to modification**. Any need to modify the underlying methods should be seen as a mistake and submitted as an [issue](https://github.com/andyruwruw/stardew-valley-bot-framework/issues). Inheritance is king here.

Help me keep this framework as simple to use by sharing your feedback on the experience! I'll be making quite a few bots from the framework and will update it according to my usage.

# Table of Contents

- [Prerequisites and Features](#prerequisites-and-features)
- [Beginners Setup Guide](#beginners-setup-guide)
  - [SMAPI and Downloading BotFramework](#smapi-and-downloading-botframework)
  - [Creating your Mod](#creating-your-mod)
  - [Referencing to BotFramework](#referencing-to-botframework)
- [How a Bot Works](#how-a-bot-works)
  - [Bot Character](#bot-character)
  - [Bot States](#bot-states)
  - [State Behaviors](#state-behaviors)
  - [Behavior Types](#behavior-types)
    - [I. Behavior Type: Reaction](#i-behavior-type-reaction)
    - [II. Behavior Types: Task](#ii-behavior-type-task)
  - [Behavior Targets](#behavior-targets)
  - [Resolving Multiple Behaviors](#resolving-multiple-behaviors)

# Prerequisites and Features

You should have some experience with the following:

- Coding in any Language
  - Classes and Objects
  - Inheritance & Abstract Classes
- Some Experience with Stardew Valley Code

What Bot Framework takes care of for you:

- Running and Optimizing Tasks
- Managing States and Behaviors
- Combining Behaviors into Procedures
- Pathfinding and Query Algorithms
- Controlling the Character
- Most of the Interaction with Stardew Valley Code.

# Beginners Setup Guide

## SMAPI and Downloading BotFramework

To begin you should have Stardew Valley running with SMAPI. Here's a [link to the tutorial](https://stardewvalleywiki.com/Modding:Player_Guide/Getting_Started). 

You'll then need to follow the players guide for installing the BotFramework, found on the [BotFramework README.md](../README.md#installation) or NexusMods page, and add the mod to your Stardew Valley mods folder.

## Creating your Mod

Working with BotFramework requires that you create your own C# SMAPI mod. You'll want to start with [this tutorial](https://stardewvalleywiki.com/Modding:Modder_Guide/Get_Started). Hopefully in the future we can introduce some ways to work with BotFramework using JSON.

## Referencing to BotFramework

You'll also need to add a reference to the framework in your `<project-name>.csproj`. This will allow you to access BotFramework from your code.

```
<Project>
  ...
  <ItemGroup>
    <Reference Include="BotFramework">
      <HintPath>$(GamePath)\Mods\BotFramework\BotFramework.dll</HintPath>
      <Private>False</Private>
    </Reference>
  </ItemGroup>
</Project>
```

You should also add the BotFramework as a dependency to your `manifest.json`. This ensures those who try to use your mod know it requires BotFramework as well.

```
{
  "Name": ...
  "Dependencies": [
    { "UniqueID": "andyruwruw.BotFramework" },
  ],
}
```

You should now be able to access BotFramework by adding the namespace to the top your files like such.

```
using BotFramework;
using BotFramework.Behaviors;
using BotFramework.Targets;
...
```

# How a Bot Works

## Bot Character

Bots in BotFramework are attatched to an instance of `StardewValley.Character`.

This extends to `StardewValley.Farmer`, `StardewValley.NPC`, `StardewValley.Pet`, `StardewValley.Monster` and all other classes inheriting from `StardewValley.Character`.

As a example, we'll be building out a `WaterBot`, which controls the `StardewValley.Farmer` to water every crop on his / her farm.


```
WaterBot:

  description:
  - Waters all your crops.

  character:
  - StardewValley.Farmer
```

## Bot States

Bots contain a set of `BotFramework.States.State`. You can think of States as modes, or moods the bot is in. 

```
WaterBot:

  description:
  - Waters all your crops.

  character:
  - StardewValley.Farmer

  states:
  - Ready to Water
  - No Water in Can
  - Too Tired to Water
```

Each state has an `public boolean isActive` method to determine which single state should be active at any given time.

```
WaterBot:

  description:
  - Waters all your crops.

  character:
  - StardewValley.Farmer

  states:
  - Ready to Water
    condition:
    - watering-can is not empty && farmer has energy

  - No Water in Can
    condition:
    - watering-can is empty && farmer has energy

  - Too Tired to Water
    condition:
    - farmer does not have energy
```

## State Behaviors

States contain a set of `BotFramework.Behaviors.Behavior`, which define how the Bot should react to it's environment, and tasks it should pursue.

Behaviors can have their own conditions, but Behaviors can be computationally complex.

States give the Bot a way to cut down on the number of Behaviors to be checked by grouping Behaviors under broader conditions.

```
WaterBot:

  description:
  - Waters all your crops.

  character:
  - StardewValley.Farmer

  states:
  - Ready to Water
    condition:
    - watering-can is not empty && farmer has energy
    behaviors:
    - Task: Water every unwatered crop

  - No Water in Can
    condition:
    - watering-can is empty && farmer has energy
    behaviors:
    - Task: Refill watering can at closest water

  - Too Tired to Water
    condition:
    - farmer does not have energy
    behaviors:
    - Stop bot
```

## Behavior Types

Behaviors themselves can be a `BehaviorType.Reaction` or `BehaviorType.Task`.

### I. Behavior Type: Reaction

Reactions are dependent on the environment, therefore a query is required prior to checking if the Behavior is active.

For example, a Behavior Reaction could be:

```
Behavior: Avoid Monsters
  description:
    Runs away from monster if closer than 5 meters.

  type:
    BehaviorType.Reaction

  target:
    StardewValley.Monster

  query:
    Find closest <target> in StardewValley.GameLocation.

  condition:
    <query> is closer than 5 meters.

  intent:
    Walk in the opposite direction of <query>.
```

Before the Bot can check if it needs to **Avoid Monsters**, it first must run a query of all monsters around the player.

### II. Behavior Types: Task

In contrast, `BehaviorType.Task` runs a query after it has been determined that the Bot should run that Behavior.

For example, a Behavior Task could be:

```
Behavior: Water Crops
  description:
    Waters all unwatered crops.

  type:
    BehaviorType.Task

  target:
    Unwatered Crops

  query:
    Find all reachable <target> in StardewValley.GameLocation.

  condition:

  intent:
    Walk to each <query>, water <query>.
```

## Behavior Targets

All Behaviors have a `BotFramework.Target`. This Target determines what external object the Behavior relates to.

Targets can query one of the following types:

- Buildings: `StardewValley.Building`
- Characters: `StardewValley.Character`
- Locations: `StardewValley.GameLocation`
- Doors: `StardewValley.InteriorDoor`
- Objects: `StardewValley.Object`
- Projectiles: `StardewValley.Projectiles.Projectile`
- TerrainFeatures: `StardewValley.TerrainFeatures.TerrainFeature`
- Tiles: `XTile.Tiles.Tile`
- Warps: `StardewValley.Warp`
- Condition: `boolean`

Which is defined in the enum `BotFramework.TargetType`. This should give you full access to query most objects in Stardew Valley.

If we wanted to find every `StardewValley.Monster` in the player's current location, we'd define a Target with the following condition:

```
Target: Monsters
  description:
    Targets StardewValley.Monster.
  
  type:
    BotFramework.TargetType.Character

  validator:
    StardewValley.Character is StardewValley.Monster
```

Targets are passed objects based on their type. This target with the type `BotFramework.TargetType.Character`, will be passed `StardewValley.Character` objects, but it specifically wants `StardewValley.Monster`. 

The `validator`, or `public boolean Validate(T object)` assists in validating targets and determining if they fit the Target.

## Resolving Multiple Behaviors

In the end, the Bot will recieve `BotFramework.Intent` from each Behavior, and combine these Intents into a `BotFramework.Procedure`, which will be run by the character controller.
