BotFramework works on the (Strategy pattern)[https://en.wikipedia.org/wiki/Strategy_pattern].

The mod author writes Behaviors the bot should undertake. They do this by extending the Behavior class to give it custom functionality.

While mod authors are invited to implement their own solutions, many are provided.

A Behavior has a 
- name: Readable name for the behavior.
- callOrder:
- validator:

when to check
what triggers it
what it does

Complex Behaviors

Mine Solver
At 12:00, to to ladder, right click.
When monster, avoid
when monster close, sword
when monster closish, slingshot
when ore, mine.
When stone in the way, mine.

Water Bot
When out of water, go refill
When waterable spots available, water them
Use complex watering pattern

Behaviors
Trigger: What makes it happen
  Pressing Right click on Water
When to Check: When to query
  New Location
  Before
  
Stimulus - Input from Environment
Cognition - Process acquiring knowledge / The psychological result of perception and reasoning
Operant Conditioning - responses conrolled by consequences
phobia
displacement - the act of taking the position of another
Awareness






Behavior
  Target:
    Type: Tile
    Validator: Tile + Crop + not Watered
    Awareness: Global
    Query: All on Location
    
  Condition: Water in Bucket
    
  