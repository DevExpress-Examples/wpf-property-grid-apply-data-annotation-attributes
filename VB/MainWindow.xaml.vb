Imports DevExpress.Mvvm.DataAnnotations
Imports System.ComponentModel.DataAnnotations
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace DXSample

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Dim contact = New Contact With {.FirstName = "Carolyn", .LastName = "Baker", .Email = "carolyn.baker@example.com", .Phone = "(555)349-3010", .Address = "1198 Theresa Cir", .City = "Whitinsville", .State = "MA", .Zip = "01582", .Photo = New BitmapImage(New System.Uri("pack://application:,,,/Images/CarolynBaker.jpg"))}
            DataContext = contact
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class Contact

        <Display(GroupName:="General Info")>
        <Required>
        <MaxLength(25, ErrorMessage:="Value is too long")>
        Public Property FirstName As String

        <Display(GroupName:="General Info")>
        <Required>
        Public Property LastName As String

        <Display(GroupName:="General Info", AutoGenerateField:=False)>
        <DisplayFormat(NullDisplayText:="<empty>")>
        <CreditCard>
        Public Property CreditCardNumber As String

        <Display(GroupName:="Contacts")>
        <DisplayFormat(NullDisplayText:="<empty>")>
        <DataType(DataType.EmailAddress)>
        Public Property Email As String

        <Display(GroupName:="Contacts")>
        <DataType(DataType.PhoneNumber)>
        <DisplayFormat(NullDisplayText:="<empty>")>
        Public Property Phone As String

        <Display(GroupName:="Address")>
        <DisplayFormat(NullDisplayText:="<empty>")>
        Public Property Address As String

        <Display(GroupName:="Address")>
        <DisplayFormat(NullDisplayText:="<empty>")>
        <RegExMask(Mask:="\w{1,25}", UseAsDisplayFormat:=True, ShowPlaceHolders:=False)>
        Public Property City As String

        <Display(GroupName:="Address")>
        <DisplayFormat(NullDisplayText:="<empty>")>
        <CustomValidation(GetType(ContactValidator), "ValidateString")>
        Public Property State As String

        <Display(GroupName:="Address")>
        <DisplayFormat(NullDisplayText:="<empty>")>
        Public Property Zip As String

        <Display(GroupName:="General Info")>
        <PropertyGridEditor(TemplateKey:="ImageTemplate")>
        Public Property Photo As ImageSource
    End Class

    Public Class ContactValidator

        Public Shared Function ValidateString(ByVal value As Object) As ValidationResult
            If value Is Nothing OrElse value.ToString().Length > 25 Then Return New ValidationResult("Value is too long")
            Return ValidationResult.Success
        End Function
    End Class
End Namespace
