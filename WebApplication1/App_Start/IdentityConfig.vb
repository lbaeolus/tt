﻿Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin

' 配置此应用程序中使用的应用程序用户管理器。UserManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
Public Class ApplicationUserManager
    Inherits UserManager(Of ApplicationUser)

    Public Sub New(store As IUserStore(Of ApplicationUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationUserManager), context As IOwinContext)
        Dim manager = New ApplicationUserManager(New UserStore(Of ApplicationUser)(context.Get(Of ApplicationDbContext)()))

        ' 配置用户名的验证逻辑
        manager.UserValidator = New UserValidator(Of ApplicationUser)(manager) With {
            .AllowOnlyAlphanumericUserNames = False,
            .RequireUniqueEmail = True
        }

        ' 配置密码的验证逻辑
        manager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 6,
            .RequireNonLetterOrDigit = True,
            .RequireDigit = True,
            .RequireLowercase = True,
            .RequireUppercase = True
        }

        ' 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
        ' 你可以编写自己的提供程序并在此处插入。
        manager.RegisterTwoFactorProvider("PhoneCode", New PhoneNumberTokenProvider(Of ApplicationUser) With {
                                          .MessageFormat = "Your security code is: {0}"
                                      })
        manager.RegisterTwoFactorProvider("EmailCode", New EmailTokenProvider(Of ApplicationUser) With {
                                          .Subject = "安全代码",
                                          .BodyFormat = "Your security code is: {0}"
                                          })
        manager.EmailService = New EmailService()
        manager.SmsService = New SmsService()
        Dim dataProtectionProvider = options.DataProtectionProvider
        If (dataProtectionProvider IsNot Nothing) Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of ApplicationUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If

        Return manager
    End Function

End Class

Public Class EmailService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' 在此处插入电子邮件服务可发送电子邮件。
        Return Task.FromResult(0)
    End Function
End Class

Public Class SmsService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' 在此处插入短信服务可发送短信。
        Return Task.FromResult(0)
    End Function
End Class
