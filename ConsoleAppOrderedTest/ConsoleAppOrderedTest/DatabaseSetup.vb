Imports System
Imports System.Configuration
Imports System.Data.Common
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Data.Schema.UnitTesting

<TestClass()>
Public Class DatabaseSetup

    <AssemblyInitialize()>
    Public Shared Sub InitializeAssembly(ByVal ctx As TestContext)
        ' Setup the test database based on setting in the
        ' configuration file
        DatabaseTestClass.TestService.DeployDatabaseProject()
        DatabaseTestClass.TestService.GenerateData()
    End Sub

End Class
