Public Class BaseClass
    Implements ISomeInterface

    Public Function GetInt() As Integer Implements ISomeInterface.GetInt
        '  Throw New NotImplementedException
        Return 1
    End Function

    Public Function GetString() As String Implements ISomeInterface.GetString
        '  Throw New NotImplementedException
        Return "aaa"
    End Function

    Public Sub DoSomething() Implements ISomeInterface.DoSomething
        ' Throw New NotImplementedException
    End Sub

    Public Property IntData As Integer Implements ISomeInterface.IntData
    Public Property StringData As String Implements ISomeInterface.StringData
End Class
