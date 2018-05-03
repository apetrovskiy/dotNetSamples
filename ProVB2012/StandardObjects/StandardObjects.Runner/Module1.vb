Module Module1

    Sub Main()
        Dim baseClass As BaseClass = New BaseClass
        Dim childClass as ChildClass = New ChildClass()
        Console.WriteLine(String.Format("Base Class output: {0}", baseClass.GetString()))
        Console.WriteLine(String.Format("Child Class output: {0}", childClass.GetString()))

        Console.ReadKey()
    End Sub

End Module
