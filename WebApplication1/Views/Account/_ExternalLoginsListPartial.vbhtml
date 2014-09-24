@ModelType ExternalLoginListViewModel
@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code
<h4>使用其他服务登录。</h4>
<hr />
@If loginProviders.Count() = 0 Then
    @<div>
        <p>
            未配置外部身份验证服务。请参见<a href="http://go.microsoft.com/fwlink/?LinkId=313242">本文</a>，
            以详细了解如何将此 ASP.NET 应用程序设置为支持通过外部服务登录。
        </p>
    </div>
Else
    @Using Html.BeginForm(Model.Action, "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<div id="socialLoginList">
           <p>
               @For Each p As AuthenticationDescription In loginProviders
                   @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="使用你的 @p.Caption 帐户登录">@p.AuthenticationType</button>
               Next
           </p>
        </div>
    End Using
End If
