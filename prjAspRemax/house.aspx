<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="prjAspRemax.house" %>

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
        .auto-style8 {
            width: 296px;
        }
        .auto-style10 {
            width: 68px;
        }
        .auto-style4 {
            width: 71px;
            height: 30px;
        }
        .auto-style9 {
            width: 296px;
            height: 30px;
        }
        .auto-style11 {
            width: 68px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div style="text-align:center">
    <div>
        <img src="./pic/remaxLogo.png" alt="LOGO" />
    </div> 
        House management   
    </div>
        <p>
            &nbsp;</p>

    
        <table class="auto-style1" style="background-color:#80ffaa;margin-left:auto;margin-right:auto;width:431px;margin-top:50px;">
            <tr>
                <th colspan="2">
                    Houses
                </th>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtAddress" runat="server" style="margin-left: 0px"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Width="70px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblPostalCode" runat="server" Text="Postal code"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" Width="70px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="70px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblSize" runat="server" Text="Size"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="70px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="70px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:Button ID="btnExit" runat="server" Text="Exit" Width="70px" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFirst" runat="server" OnClick="btnFirst_Click" Text="First" Width="70px" />
                    <asp:Button ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" Text="Previous" Width="70px" />
                    <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" Width="70px" />
                    <asp:Button ID="btnLast" runat="server" OnClick="btnLast_Click" Text="Last" Width="70px" />
                </td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
        </table>

    
        </form>

    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
