Imports System

Module App
    Public Class TestClass
        Shared s As String
        Shared d as DateTime

        Public Sub Run()
            Console.WriteLine(If (Nothing = s, "null", s))
            Console.WriteLine(If (Nothing = d, "null", d.ToString()))
            Console.ReadKey()
        End Sub
    End Class

    Public Sub Main()
        Dim testClass As New TestClass()
        testClass.Run()
    End Sub
End Module
