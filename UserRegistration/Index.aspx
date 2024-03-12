<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UserRegistration.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        h1
        {
            color: aqua;
            text-align: -webkit-center;
            margin: 10px;
            padding: 10px;
        }
        
        #lblUserDetails
        {
            color: #52c7eb;
            text-align: right;
        }
        p
        {
            background: gainsboro;
            padding: 10px;
            margin: 10px;
        }
    </style>
    <title>Index</title>
</head>
<body>
    <form id="form4" runat="server">
    <asp:Label ID="lblUserDetails" runat="server" Text="" style="text-align: right;"></asp:Label>
    <h1>
        Hi Welcome to Dashboard</h1>
    <p>
        Lorem ipsum dolor sit amet. Quo temporibus nostrum et odio rerum ea rerum molestiae
        qui voluptas dolor? Ut libero voluptatem 33 perferendis accusantium est vitae ipsa
        est architecto quaerat! Ut illo iusto est labore consequatur et praesentium repellendus
        ab explicabo consequatur est doloribus dignissimos. Qui fuga dolores est enim earum
        ex labore quaerat.
    </p>
    <div>
        <h2 style="text-align: center;">Product Entry</h2>
        <asp:HiddenField ID="hfProductId" runat="server" />
        <div style="display: ruby-text;">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Product Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Quantity"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style=" display : ruby-text;  margin-bottom: 50px;">
            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ProductId") %>'
                                OnClick="lnk_onClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" style="margin-left: 900px; display: flow;"/>
    </form>
</body>
</html>
