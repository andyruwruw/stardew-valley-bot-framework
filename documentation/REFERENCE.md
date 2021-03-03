# BotFramework References

Full descriptions of each class.

# Content

- BotFramework
  - [Bot.cs](#bot)
  - [ModConfig.cs](#modconfig)
  - Framework
    - [Brain.cs](#framework.brain)
    - [Actionable]()
      - [ActionableGroup.cs]()
      - [ActionableLocation.cs]()
      - [ActionableTile.cs]()
    - [Helpers]()
      - [Distance.cs]()
      - [LogProxy.cs]()
    - [Location]()
      - [LocationParser.cs]()
      - [LocationTour.cs]()
      - [Map.cs]()
      - [Tile.cs]()
    - [Pathfinding]()
      - [FillGenerator.cs]()
      - [SearchGenerator.cs]()
      - [TourGenerator.cs]()
    - [PlayerController]()
      - [PlayerController.cs]()
      - [FarmGenerator.cs]()
    - [Validators]()
      - [CharacterValidator.cs]()
      - [ObjectValidator.cs]()
      - [TileValidator.cs]()
    - [World]()
      - [WorldParser.cs]()
      - [WorldTour.cs]()

# Bot

# ModConfig

# Framework.Brain

### Intent

Determines what actions to take next. Acts as a facade to all sub-layers, keeping [Bot](#bot) free of a majority of the maintainance logic. Contains a queue of locations to visit and actions to take in each.

# Framework.Actionable

Data structures for storing the location and order of actions to be taken, whether that means traveling from location to location, or a group of crops to water.

# Framework.Actionable.ActionableGroup

### Intent

A collection of spacially related Tiles, for now by adjacency. Simplifies the number of nodes involved in finding the shortest path through each actionable tile.

# Framework.Actionable.ActionableLocation

### Intent

A location to either pass through or carry out actions. Contains a [LocationParser]() to read the map data and generate [ActionableGroups]() and [ActionableTiles]().

# Framework.Actionable.ActionableTile

### Intent

A place to stand, and a set of tiles to interact with. Takes advantage of the fact that the player can usually interact with four adjacent tiles, sometimes eight, to limit the amount of time spent moving.

# Framework.Helpers

Classes containing static methods used through the Framework and tied to [config.json]() properties.

# Framework.Helpers.Distance

### Intent

A collection of distance formulas.

# Framework.Helpers.LogProxy

### Intent

A proxy for logging to the monitor, filtering out debug messages unless the [config.json]() states otherwise.

# Framework.Location

Data structures to read, store and process location map data.

# Framework.Location.LocationParser

### Intent

Main facade for reading GameLocation objects.

# Framework.Location.LocationTour

### Intent

Implements the [Framework.Pathfinding.TourGenerator]() to find the best path to visit each [ActionableGroup]() in a location.

By default utilizes a greedy approach to the traveling salesman problem, but can be changed in the [config.js]().

# Framework.Location.Map

### Intent

2D Array of [Framework.Location.Tiles]().

# Framework.Location.Tile

### Intent

Main facade for reading a given Tile's data.

# Framework.Pathfinding

A collection of abstract template method classes, specializing in a different form of pathfinding or searching.

# Framework.Pathfinding.FillGenerator

### Intent

Abstract template method class for filling in a set of adjacent tiles. Utilizes depth-first search.

# Framework.Pathfinding.SearchGenerator

### Intent

Abstract template method class for searching for a given node in a graph. Utlizies breadth-first search.

# Framework.Pathfinding.TourGenerator

Abstract template method class for finding the (close to) best path to reach every node in a graph. Utilizes the greedy approach to the traveling salesman problem.

# Framework.PlayerController

Classes handling the character.

# Framework.PlayerController.PlayerController

### Intent

Facade for dealing with character actions, movement and animations.

# Framework.PlayerController.FarmerGenerator

### Intent

Converting characters to the StardewValley.Farmer class for tool animations.

# Framework.Validators

Abstract classes to define selection of actionable objects.

# Framework.Validators.CharacterValidator

### Intent

Abstract class to validate character targets.

# Framework.Validators.ObjectValidator

### Intent

Abstract class to validate object targets.

# Framework.Validators.TileValidator

### Intent

Abstract class to validate tile targets.

# Framework.World

Classes to collect and analyze multi-location actions and determine paths.

# Framework.World.WorldParser

### Intent

Loads StardewValley.GameLocations and creates [ActionableLocations]()

# Framework.World.WorldTour

### Intent

Implements the [Framework.Pathfinding.TourGenerator]() to find the best path to visit each [ActionableLocation]() to complete actions.

By default utilizes a greedy approach to the traveling salesman problem, but can be changed in the [config.js]().
