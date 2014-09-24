Imports System.ComponentModel.DataAnnotations

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <EmailAddress> _
    <Display(Name:="电子邮件")>
    Public Property Email As String
End Class

Public Class ExternalLoginListViewModel
    Public Property Action As String
    Public Property ReturnUrl As String
End Class

Public Class ManageUserViewModel
    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="当前密码")>
    Public Property OldPassword As String

    <Required>
    <StringLength(100, ErrorMessage:="{0} 必须至少包含 {2} 个字符。", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="新密码")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name:="确认新密码")>
    <Compare("NewPassword", ErrorMessage:="新密码和确认密码不匹配。")>
    Public Property ConfirmPassword As String
End Class

Public Class LoginViewModel
    <Required>
    <EmailAddress> _
    <Display(Name:="电子邮件")>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="密码")>
    Public Property Password As String

    <Display(Name:="记住我?")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel
    <Required>
    <EmailAddress> _
    <Display(Name:="电子邮件")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage:="{0} 必须至少包含 {2} 个字符。", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="密码")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="确认密码")>
    <Compare("Password", ErrorMessage:="密码和确认密码不匹配。")>
    Public Property ConfirmPassword As String
End Class

Public Class ResetPasswordViewModel
    <Required> _
    <EmailAddress> _
    <Display(Name:="电子邮件")> _
    Public Property Email() As String

    <Required> _
    <StringLength(100, ErrorMessage:="{0} 必须至少包含 {2} 个字符。", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(Name:="密码")> _
    Public Property Password() As String

    <DataType(DataType.Password)> _
    <Display(Name:="确认密码")> _
    <Compare("Password", ErrorMessage:="密码和确认密码不匹配。")> _
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required> _
    <EmailAddress> _
    <Display(Name:="电子邮件")> _
    Public Property Email() As String
End Class
