//test
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
    member this.setCurrentSpeed(percent) =
        let random = float(rng.Next(1,101)) / 100.0
        if (this.maxSpeed * percent > this.maxSpeed) then
            this.speed <- this.maxSpeed
        else
            this.speed <- this.maxSpeed * percent
        ()


    //sets needed food based on weight
    abstract member setNeededFood : unit -> unit
    default this.setNeededFood() =
        this.neededFood <- this.weight * 0.5

    //secondary constructor
    new (maxSpeed) =
        let weight = float(rng.Next(70, 301))
        animal(weight, maxSpeed)


type carnivore(Weight : float, _maxSpeed : float) =
    inherit animal(Weight, _maxSpeed)

    override this.setNeededFood() = this.neededFood <- this.weight * 0.08

    new (_maxSpeed) =
        let weight = float(rng.Next(70, 301))
        carnivore(weight, _maxSpeed)

type herbivore(Weight : float, _maxSpeed : float) =
    inherit animal(Weight, _maxSpeed)

    override this.setNeededFood() = this.neededFood <- this.weight * 0.4

    new (_maxSpeed) =
        let weight = float(rng.Next(70, 301))
        herbivore(weight, _maxSpeed)



let race() =
    let cheetah = new carnivore(50.0, 114.0)
    let wildebeest = new herbivore(200.0, 95.0)
    let antelope = new herbivore(50.0, 80.0)

    let mutable cheetah_wins = 0
    let mutable wildebeest_wins = 0
    let mutable antelope_wins = 0
    let mutable draw = 0
    let mutable random = 0.0


    for i = 0 to 2 do
        random <- float(rng.Next(1,101)) / 100.0
        cheetah.setNeededFood()
        cheetah.setCurrentSpeed(random)
        printfn "Cheetah:"
        printfn "Percent generated: %.2f" (random*100.0)
        printfn "Food eaten: %A" (cheetah.neededFood * random)
        printfn "Food needed: %A" (cheetah.neededFood)
        printfn "Time to run 10Km: %.2f" ((10.0/cheetah.speed)*60.0)



        random <- float(rng.Next(1,101)) / 100.0
        wildebeest.setNeededFood()
        wildebeest.setCurrentSpeed(random)
        printfn "WildeBeest:"
        printfn "Percent generated: %.2f" (random*100.0)
        printfn "Food eaten: %A" (wildebeest.neededFood * random)
        printfn "Food needed: %A" (wildebeest.neededFood)
        printfn "Time to run 10Km: %.2f" ((10.0/wildebeest.speed)*60.0)


        random <- float(rng.Next(1,101)) / 100.0
        antelope.setNeededFood()
        antelope.setCurrentSpeed(random)
        printfn "Antelope:"
        printfn "Percent generated: %.2f" (random*100.0)
        printfn "Food eaten: %A" (antelope.neededFood * random)
        printfn "Food needed: %A" (antelope.neededFood)
        printfn "Time to run 10Km: %.2f" ((10.0/antelope.speed)*60.0)

        // check who won each race
        if cheetah.speed > wildebeest.speed && cheetah.speed > antelope.speed then
          cheetah_wins <- cheetah_wins + 1

        elif wildebeest.speed > cheetah.speed && wildebeest.speed > antelope.speed then
            wildebeest_wins <- wildebeest_wins + 1
        elif antelope.speed > cheetah.speed && antelope.speed > wildebeest.speed then
            antelope_wins <- antelope_wins + 1
        else
            draw <- draw + 1
        printfn ""
    // print results
    printfn ""
    printfn "Wins:\n Cheetah: %A\n Wildebeest: %A\n Antelope: %A\n Draw: %A " cheetah_wins wildebeest_wins antelope_wins draw

race()

//// Tests (Not really that much to test here, to be honest...)
printfn "\n\n"
printfn "Aminal testing for fun and profit\n---------------------------------"
let testAminal = new animal(100.0, 20.0)
//neededFood
testAminal.setNeededFood()
printfn "neededFood        | Test 1:  %b" (testAminal.neededFood = 50.0)
printfn ""
//setCurrentSpeed
testAminal.setCurrentSpeed(1.0)
printfn "currentSpeed      | Test 1:  %b" (testAminal.speed = 20.0)
testAminal.setCurrentSpeed(0.5)
printfn "currentSpeed      | Test 2:  %b" (testAminal.speed = 10.0)
testAminal.setCurrentSpeed(0.0)
printfn "currentSpeed      | Test 3:  %b" (testAminal.speed = 0.0)
testAminal.setCurrentSpeed(2.0)
printfn "currentSpeed      | Test 4:  %b" (testAminal.speed = 20.0)
