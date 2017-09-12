<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="prjAspRemax.admin" %>
<%var myTest = Request.QueryString["txtUsernameAdmin"];  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 60%;
        }
        .auto-style3 {
            width: 71px;
        }
        .auto-style4 {
            width: 71px;
            height: 30px;
        }
        .auto-style8 {
            width: 296px;
        }
        .auto-style9 {
            width: 296px;
            height: 30px;
        }
        .auto-style10 {
            width: 68px;
        }
        .auto-style11 {
            width: 68px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    <div>
        <img src="./pic/remaxLogo.png" alt="LOGO" />
    </div> 
        Admin management   
    </div>

    
        <table class="auto-style1" style="background-color:#80ffaa;margin-left:auto;margin-right:auto;width:431px;margin-top:100px;">
            <tr>
                <th colspan="2">
                    Agents
                </th>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblFirstName" runat="server" Text="First name"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtFirstName" runat="server" style="margin-left: 0px"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="70px" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblLastName" runat="server" Text="Last name"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="70px" OnClick="btnEdit_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblUsername" runat="server" Text="User name"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClick="btnDelete_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="70px" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtPosition" runat="server" ReadOnly="True">Agent</asp:TextBox>
                </td>
                <td class="auto-style11">
                    <asp:Button ID="btnExit" runat="server" Text="Exit" Width="70px" OnClick="btnExit_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFirst" runat="server" Text="First" Width="80px" OnClick="btnFirst_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" Width="80px" OnClick="btnPrevious_Click" />

                    <asp:Button ID="btnNext" runat="server" Text="Next" Width="80px" OnClick="btnNext_Click"   />

                    <asp:Button ID="btnLast" runat="server" Text="Last" Width="80px" OnClick="btnLast_Click"/>
                </td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    </form>
    
</body>
</html>
