<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="UserRegistration.HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>This is the Home Page. Welcome to ASP.NET Tutorial</h1>
        <asp:Button ID="Button1" runat="server" Text="Registration" onClick="Registration"/>
        <asp:Button ID="Button2" runat="server" Text="Login" onClick="Login"/>
    </form>
</body>
</html>
