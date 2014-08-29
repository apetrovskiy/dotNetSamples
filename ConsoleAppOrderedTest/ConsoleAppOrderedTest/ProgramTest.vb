Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ConsoleAppOrderedTest



'''<summary>
'''This is a test class for ProgramTest and is intended
'''to contain all ProgramTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProgramTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for Program Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub ProgramConstructorTest()
        Dim target As Program = New Program()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for Main
    '''</summary>
    <TestMethod(), _
     DeploymentItem("ConsoleAppOrderedTest.exe")> _
    Public Sub MainTest()
        Dim args() As String = Nothing ' TODO: Initialize to an appropriate value
        Program_Accessor.Main(args)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Program Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub ProgramConstructorTest1()
        Dim target As Program = New Program()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
