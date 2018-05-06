Imports Microsoft.EntityFrameworkCore

Namespace MovieLib
    Public Class MovieContext
        Inherits DBContext

        Public Property Movie As DbSet(Of MovieLib.Movie)

        Public Sub New(options As DbContextOptions)
            MyBase.New(options)
        End Sub
    End Class
End Namespace