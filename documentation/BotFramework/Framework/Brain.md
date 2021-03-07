[Go Back](../../REFERENCE.md)

# BotFramework.Framework.Brain

## Intent

Determines what actions to take next. Acts as a facade to all sub-layers, keeping [Bot](#bot) free of a majority of the maintainance logic. Contains a queue of locations to visit and actions to take in each.

## Lifetime Diagram

- Start
  - Get best path through all locations
    - Enqueue PassThrough locations
  - Go to next location
    - Get all AtLocationStart Targets
      - Query Pattern
        - Validate
          - Enqueue

      - For every targeted entity
        - Check all BeforeAll Targets
          - Conditions
            - Query Pattern
              - Validate
                - Travel
                - Execute
                - Continue

        - Pop next action
          - Conditions
            - Travel
            - Execute

        - Check all AfterAll Targets
          - Conditions
            - Query Pattern
              - Validate
                - Travel
                - Execute
                - Continue
