<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication8.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        
        <asp:RegularExpressionValidator runat="server" ErrorMessage="<br><br><strong>Please Enter Correct F0rm</strong>" ControlToValidate="TextBox1"
      ValidationExpression="^[0-9]*(?:\.[0-9]*)?$"></asp:RegularExpressionValidator>

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" onkeydown="TextBox1_KeyPress;" />
    </form>
</body>
</html>
