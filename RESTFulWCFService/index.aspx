<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RESTFulWCFService.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 30%; margin: 50px auto 0 auto">
            <tr>
                <td>
                    <span>Name</span>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvName" runat="server" ErrorMessage="Name can't be empty"
                        ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Age</span>
                </td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Salary</span>
                </td>
                <td>
                    <asp:TextBox ID="txtSalary" runat="server" MaxLength="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Designation</span>
                </td>
                <td>
                    <asp:TextBox ID="txtDesignation" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
    <div style="margin: 50px auto 0 auto; width: 400px;">
        <asp:GridView ID="gvEmployee" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
