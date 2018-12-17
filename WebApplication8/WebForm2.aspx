<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication8.WebForm2" %>

<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>แปลงตัวเลข</title>

</head>

<body class="text-center" >   
    
    <form id="form1" runat="server" align="center" class="bg-dark">
        <div class="container-fluid">
            <header class="masthead mb-auto"></header>
                <div class="cover-container d-flex h-100 p-3 mx-auto flex-column">
                    <div class="inner"><h3 class="masthead-brand text-white">โปรแกรมแปลงตัวเลขเป็นตัวอักษร และ ตัวอักษรเป็นตัวเลข (2 in 1)</h3></div>
                            
                        <asp:TextBox  ID="TextBox1" runat="server"></asp:TextBox>
          
                            <div class="container">
        <br>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ตกลง" type="button" class="btn btn-ln btn-primary" />
        </div>
                    </div>
        </div>
    </form>
                <footer class="footer">By >>>Kreetha Toey Sintawee<<<</footer>
</body>
</html>
`