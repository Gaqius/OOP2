<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LD5_23.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="ErrorLabel1" runat="server" Font-Strikeout="False" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Užsakymo riba"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Pradiniai duomenys" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Skaičiavimai" OnClick="Button2_Click" />
        <br />
        <div id="ResultsDiv" runat="server">
        </div>
    </form>
</body>
</html>
