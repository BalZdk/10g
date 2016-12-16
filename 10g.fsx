let rng = new System.Random()

type animal(Weight : float, MaxSpeed : float) =
    let mutable Speed = 0.0
    let mutable NeededFood = 0.0

    member this.weight = Weight
    member this.speed
        with get () = Speed
        and set (value) = Speed <- value
    member this.maxSpeed = MaxSpeed
    member this.neededFood
        with get () = NeededFood
        and set (value) = NeededFood <- value

    member setCurrentSpeed()

    member setNeededFood()


    new (MaxSpeed) =
        let weight = float(rng.Next(70, 301))
        animal(weight, MaxSpeed)
