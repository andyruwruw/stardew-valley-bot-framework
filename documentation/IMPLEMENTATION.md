
Bot
    makes Brain
    makes CharacterController

    sets Targets
    sets GameLocations

    Start()
        call Bot.Start()

Brain
    creates Target Lists
    creates Action Queue

    Start()
        if Queues empty
            world.GetActions(AtLocationStart Targets, CallOrder.ActLocationStart)
        if Last AtLocationStart
            world.GetActions(AfterEach Targets, CallOrder.AfterEach)
        if Last AfterEach and AfterEach Queue empty
            world.GetActions(BeforeEach Targets, CallOrder.BeforeEach)
        
        if AfterEach Queue not empty
            return dequeue AfterEach Queue
        if BeforeEach Queue not empty
            return dequeue AfterEach Queue
        if AtLocationStart Queue not empty
            return dequeue AfterEach Queue

        return "Bot Finished"

World
    