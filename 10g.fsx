let rng = new System.Random()

type animal(Weight : float, MaxSpeed : float) =
    let mutable Speed = 0.0
    let mutable NeededFood = 0.0

    //// attributes
    member this.weight = Weight
    member this.speed
        with get () = Speed
        and set (value) = Speed <- value
    member this.maxSpeed = MaxSpeed
    member this.neededFood
        with get () = NeededFood
        and set (value) = NeededFood <- value

    //// methods
    //generates random value, and assigns current speed based on value
    member this.setCurrentSpeed() =
        let random = float(rng.Next(0,101)) / 100.0
        this.speed <- this.maxSpeed * random

        printfn "The aminal has eaten %.2f percent of the required food" (random * 100.0)
        printfn "The aminal has eaten %.2f kg of food" (this.neededFood * random)
        printfn "The aminal should have eaten %.2f kg of food" this.neededFood
        printfn "It took the aminal %.0f minutes to run 10 km" ((10.0 / this.speed)*60.0)

    //sets needed food based on weight
    member this.setNeededFood() =
        this.neededFood <- this.weight * 0.5

    //secondary constructor
    new (maxSpeed) =
        let weight = float(rng.Next(70, 301))
        animal(weight, maxSpeed)


type carnivore(Weight : float, _maxSpeed : float) =
    inherit animal(Weight, _maxSpeed)

    member this.setNeededFood() =
        this.neededFood <- this.weight * 0.08

    new (_maxSpeed) =
        let weight = float(rng.Next(70, 301))
        carnivore(weight, _maxSpeed)

type herbivore(Weight : float, _maxSpeed : float) =
    inherit animal(Weight, _maxSpeed)

    member this.setNeededFood() =
        this.neededFood <- this.weight * 0.4

    new (_maxSpeed) =
        let weight = float(rng.Next(70, 301))
        herbivore(weight, _maxSpeed)



let race =
    let cheetah = new carnivore(50.0, 114.0)
    let wildebeest = new herbivore(200.0, 80.0)
    let antelope = new herbivore(50.0, 95.0)

    for i = 0 to 2 do
        printfn "----------\nCheetah:"
        cheetah.setNeededFood()
        cheetah.setCurrentSpeed()

        printfn "----------\nWildebeest:"
        wildebeest.setNeededFood()
        wildebeest.setCurrentSpeed()

        printfn "----------\nAntelope:"
        antelope.setNeededFood()
        antelope.setCurrentSpeed()
