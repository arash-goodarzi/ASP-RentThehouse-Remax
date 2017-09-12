<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="prjAspRemax.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         .button{
            display: inline-block;
            padding: 10px 10px;
            font-size: 10px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            outline: none;
            color: white;
            background-color: red;
            border: none;
            border-radius: 15px;
            box-shadow: 0 5px #000000;
            margin:40px;
            width:70px;
            margin-top:5px;
        }
         .table{
             float:left;
             margin-left:250px;
             margin-top:100px;
         }
    </style>
</head>
<body>
    
    <div style="text-align:center">
    <div>
        <img src="./pic/remaxLogo.png" alt="LOGO" />
    </div>
        <form method="get" action="admin.aspx">
            <table class="table">
                <tr>
                    <td colspan="2" style="background-color:red;color:white;border-radius: 15px;">Admin</td>
                
                </tr>
                <tr>
                    <td>username:</td>
                    <td>
                        <input type="text" name="txtUsernameAdmin"  />
                    </td>
                </tr>
                <tr>
                    <td>password</td>
                    <td>
                        <input type="text" name="txtPasswordAdmin"  />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" value="Sign in"  class="button" />
                    </td>
                    <td>
                        <input type="reset" value="Clear"  class="button" />
                    </td>
                </tr>
            </table>
        </form>
        <form action="agent.aspx" method="get">
            <table class="table">
                <tr>
                    <td colspan="2" style="background-color:red;color:white;border-radius: 15px;">Agent</td>
                
                </tr>
                <tr>
                    <td>username:</td>
                    <td>
                        <input type="text" name="txtUsernameAgent"  />
                    </td>
                </tr>
                <tr>
                    <td>password</td>
                    <td>
                        <input type="text" name="txtPasswordAgent"  />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" value="Sign in"  class="button" />
                    </td>
                    <td>
                        <input type="reset" value="Clear"  class="button" />
                    </td>
                </tr>
            </table> 
        </form>   
    </div>
</body>
</html>
