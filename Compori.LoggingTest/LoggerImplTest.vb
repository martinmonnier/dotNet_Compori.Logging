Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Compori.Logging

'''<summary>
'''Dies ist eine Testklasse für "LoggerImplTest" und soll
'''alle LoggerImplTest Komponententests enthalten.
'''</summary>
<TestClass()> _
Public Class LoggerImplTest


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
    '''Ein Test für "Critical"
    '''</summary>
    <TestMethod()> _
    Public Sub CriticalTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim message() As Object = Nothing ' TODO: Passenden Wert initialisieren
        target.Critical(message)
        Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.")
    End Sub

    '''<summary>
    '''Ein Test für "Error"
    '''</summary>
    <TestMethod()> _
    Public Sub ErrorTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim message() As Object = Nothing ' TODO: Passenden Wert initialisieren
        target.[Error](message)
        Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.")
    End Sub

    '''<summary>
    '''Ein Test für "GetFormattedMessage"
    '''</summary>
    <TestMethod()> _
    Public Sub GetFormattedMessageTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As LoggerImpl = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim message() As Object = Nothing ' TODO: Passenden Wert initialisieren
        Dim expected As String = String.Empty ' TODO: Passenden Wert initialisieren
        Dim actual As String
        actual = target.GetFormattedMessage(message)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "Information"
    '''</summary>
    <TestMethod()> _
    Public Sub InformationTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim message() As Object = Nothing ' TODO: Passenden Wert initialisieren
        target.Information(message)
        Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.")
    End Sub

    '''<summary>
    '''Ein Test für "Verbose"
    '''</summary>
    <TestMethod()> _
    Public Sub VerboseTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim message() As Object = Nothing ' TODO: Passenden Wert initialisieren
        target.Verbose(message)
        Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.")
    End Sub

    '''<summary>
    '''Ein Test für "Warning"
    '''</summary>
    <TestMethod()> _
    Public Sub WarningTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim message() As Object = Nothing ' TODO: Passenden Wert initialisieren
        target.Warning(message)
        Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.")
    End Sub

    '''<summary>
    '''Ein Test für "WithCategories"
    '''</summary>
    <TestMethod()> _
    Public Sub WithCategoriesTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim category() As String = Nothing ' TODO: Passenden Wert initialisieren
        Dim expected As ILogger = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As ILogger
        actual = target.WithCategories(category)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "WithExtendedProperties"
    '''</summary>
    <TestMethod()> _
    Public Sub WithExtendedPropertiesTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim properties As IDictionary(Of String, Object) = Nothing ' TODO: Passenden Wert initialisieren
        Dim expected As ILogger = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As ILogger
        actual = target.WithExtendedProperties(properties)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "WithFormat"
    '''</summary>
    <TestMethod()> _
    Public Sub WithFormatTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim formatProvider As IFormatProvider = Nothing ' TODO: Passenden Wert initialisieren
        Dim format As String = String.Empty ' TODO: Passenden Wert initialisieren
        Dim expected As ILogger = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As ILogger
        actual = target.WithFormat(formatProvider, format)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "WithFormat"
    '''</summary>
    <TestMethod()> _
    Public Sub WithFormatTest1()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim format As String = String.Empty ' TODO: Passenden Wert initialisieren
        Dim expected As ILogger = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As ILogger
        actual = target.WithFormat(format)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "WithPriority"
    '''</summary>
    <TestMethod()> _
    Public Sub WithPriorityTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As ILogger = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim priority As Priority = New Priority() ' TODO: Passenden Wert initialisieren
        Dim expected As ILogger = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As ILogger
        actual = target.WithPriority(priority)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "Categories"
    '''</summary>
    <TestMethod()> _
    Public Sub CategoriesTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As LoggerImpl = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim actual As ICollection(Of String)
        actual = target.Categories
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "ExtendedProperties"
    '''</summary>
    <TestMethod()> _
    Public Sub ExtendedPropertiesTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As LoggerImpl = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim expected As Dictionary(Of String, Object) = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As Dictionary(Of String, Object)
        target.ExtendedProperties = expected
        actual = target.ExtendedProperties
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "Format"
    '''</summary>
    <TestMethod()> _
    Public Sub FormatTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As LoggerImpl = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim expected As String = String.Empty ' TODO: Passenden Wert initialisieren
        Dim actual As String
        target.Format = expected
        actual = target.Format
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "FormatProvider"
    '''</summary>
    <TestMethod()> _
    Public Sub FormatProviderTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As LoggerImpl = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim expected As IFormatProvider = Nothing ' TODO: Passenden Wert initialisieren
        Dim actual As IFormatProvider
        target.FormatProvider = expected
        actual = target.FormatProvider
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub

    '''<summary>
    '''Ein Test für "Priority"
    '''</summary>
    <TestMethod()> _
    Public Sub PriorityTest()
        Dim writer As ILogWriter = Nothing ' TODO: Passenden Wert initialisieren
        Dim target As LoggerImpl = New LoggerImpl(writer) ' TODO: Passenden Wert initialisieren
        Dim expected As Priority = New Priority() ' TODO: Passenden Wert initialisieren
        Dim actual As Priority
        target.Priority = expected
        actual = target.Priority
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.")
    End Sub
End Class
