Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Compori.Logging

'''<summary>
''' Dies ist eine Testklasse für "LogTest" und soll alle LogTest Komponententests enthalten.
'''</summary>
<TestClass()> _
Public Class LogTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Ruft den Testkontext auf, der Informationen
    '''über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Zusätzliche Testattribute"
    '
    'Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
    '
    'Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

    '''<summary>
    ''' Tests for "TypeContext"
    '''</summary>
    <TestMethod()> _
    Public Sub TypeContextTest()
        Dim target As Log = Log.For(GetType(TestClassWithCategory))
        Dim actual As Type = target.TypeContext
        Dim expected As Type = GetType(TestClassWithCategory)
        Assert.AreEqual(expected, actual)

        target = Log.For(Nothing)
        expected = GetType(Log)
        actual = target.TypeContext
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    ''' Tests for "Categories"
    '''</summary>
    <TestMethod()> _
    Public Sub CategoriesTest()

        Dim target As Log = Log.For(GetType(TestClassWithCategory))

        Dim actual() As String
        actual = target.Categories
        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual("TestCategory", actual(0))

    End Sub

    '''<summary>
    '''Ein Test für "For"
    '''</summary>
    <TestMethod()> _
    Public Sub ForTest()

        ' Log for nothing is default log!
        Dim target As Log = Log.For(Nothing)
        Assert.AreSame(Log.Default, target)

        ' Logging for same type is same
        Dim target1 As Log = Log.For(GetType(TestClassWithCategory))
        Dim target2 As Log = Log.For(GetType(TestClassWithCategory))
        Assert.AreNotSame(Log.Default, target1)
        Assert.AreNotSame(Log.Default, target2)
        Assert.AreSame(target1, target2)

        ' logging on objects
        Dim target3 As Log = Log.For(New TestClassWithCategory())
        Assert.AreNotSame(Log.Default, target3)
        Assert.AreSame(target1, target3)

        ' logging on objects
        Dim target4 As Log = Log.For(New TestClassWithCategory())
        Dim target5 As Log = Log.For(New TestClassWithCategory())
        Assert.AreNotSame(Log.Default, target4)
        Assert.AreNotSame(Log.Default, target5)
        Assert.AreSame(target4, target5)
    End Sub

End Class
