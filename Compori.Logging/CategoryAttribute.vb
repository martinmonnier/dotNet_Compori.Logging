''' <summary>
''' Attribute that can be applied to a class or a whole assembly to set logging category name
''' </summary>
''' <remarks></remarks>
<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Assembly, Inherited:=True, AllowMultiple:=True)> _
Public Class CategoryAttribute
    Inherits Attribute

    ''' <summary>
    ''' Category names
    ''' </summary>
    ''' <remarks></remarks>
    Private _name As String

    ''' <summary>
    ''' Construct attribute object wird category name
    ''' </summary>
    ''' <param name="name">Name of category</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal name As String)
        _name = name
    End Sub

    ''' <summary>
    ''' Returns the category name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property
End Class
