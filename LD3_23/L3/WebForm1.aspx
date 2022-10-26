<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="L3.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
    <link href="~/styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Pradiniai studentu duomenys"></asp:Label>
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
        <asp:Label ID="Label1" runat="server" Text="Destytoju priziurimu studentų  skaicius nurodyta menesį"></asp:Label>
        <asp:Table ID="Table2" runat="server">
        </asp:Table>
        <asp:Label ID="Label2" runat="server" Text="Destytoju priziurimu studentų skaicius nurodyta menesį (surikiuotas)"></asp:Label>
        <asp:Table ID="Table3" runat="server">
        </asp:Table>
        <asp:Label ID="Label6" runat="server" Text="Destytojų sąrašas"></asp:Label>
        <asp:Table ID="Table4" runat="server">
        </asp:Table>
        <asp:Label ID="Label4" runat="server" Text="Destytoju uzduociu sarasai"></asp:Label>
        <br />
        <div id="tableContainer" runat="server">        
        </div>
        <asp:Label ID="Label5" runat="server" Text="FIltruoti uzduociu sarasai"></asp:Label>
        <div id="secondTableContainer" runat="server">
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
