<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="UserRegistration.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form3" runat="server">
    <div>
        <asp:HiddenField ID="hfUserID" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label Text="First Name" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtFirstName" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Last Name" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtLastName" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Email" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmail" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Mobile Number" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtMobileNumber" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Gender" runat="server" />
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlGender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Address" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" />
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label  Text="User Name" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtUserName" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Password" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label Text="Confirm Password" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" />
                </td>
            </tr>

            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Button Text="Submit" runat="server" onclick="Unnamed9_Click" />
                </td>
            </tr>

            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Label ID="lblSuccessMessage" Text="" runat="server"  ForeColor="Green"/>
                </td>
            </tr>

            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Label ID="lblErrorMessage" Text="" runat="server"  ForeColor="Red"/>
                </td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
