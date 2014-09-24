@Code
    ViewBag.Title = "ConfirmAccount"
End Code

<h2>@ViewBag.Title。</h2>
<div>
    <p>
        感谢你确认帐户。请 @Html.ActionLink("单击此处登录", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
