Module Strategy_Pattern
    ' Defines a family of algorithms, encapsulates each one,
    ' and makes them interchangeable.
    ' Lets the alogorithm vary independently from the clients that use it.

    Sub Main()
        Console.WriteLine(" Starting ")

        Dim mallard As Duck = New MallardDuck()
        mallard.PerformFly()

        Dim toy As ToyDuck = New ToyDuck()
        toy.PerformFly()

        ' *** what if we need a mallard, born with an injured wing?
        ' code a new flying behavior,  and dim the duck in main. No changes to existing code base.

        Dim injuredMallard As Duck = New MallardDuck()
        injuredMallard.flyBehavior = New FlyNot()
        injuredMallard.PerformFly()

        ' *** what if we need a mallard to go from healthy to injured?
        ' add a line to modify: mallard.flyBehavior = New FlyNot()

        Console.Write("<enter> to quit")
        Console.WriteLine()
        Console.ReadLine()


    End Sub

    Public Class Duck

        ' favor composition over inheritance
        Friend flyBehavior As IFlyBehavior  ' child classes create needed behavior
        Public Sub PerformFly()     ' child classes call when it's time to fly
            flyBehavior.Fly()
        End Sub

    End Class

    Public Class MallardDuck : Inherits Duck

        Public Sub New()
            Console.WriteLine(" . Mallard duck ")
            flyBehavior = New FlyWithWings()
        End Sub

    End Class

    Public Class ToyDuck : Inherits Duck

        Public Sub New()
            Console.WriteLine(" . Toy duck ")
            flyBehavior = New FlyNot()
        End Sub

    End Class

    Public Interface IFlyBehavior
        Sub Fly()   ' all child classes call on the interface method. Resolved at runtime, not compile time.
    End Interface

    Public Class FlyWithWings : Implements IFlyBehavior

        ' again to do this behavior is resolved at runtime, not compile time
        Public Sub Fly() Implements IFlyBehavior.Fly
            Console.WriteLine(" .. flying with wings")
        End Sub

    End Class

    Public Class FlyNot : Implements IFlyBehavior

        ' again to do this behavior is resolved at runtime, not compile time
        Public Sub Fly() Implements IFlyBehavior.Fly
            Console.WriteLine(" .. can't fly")
        End Sub

    End Class

End Module
