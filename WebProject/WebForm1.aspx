﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style ="font-family : Arial">
    <form id="form1" runat="server">
       <asp:FileUpload ID ="FileUpload1" runat="server" Text="Upload" />
        <br />
        <br />
         <asp:Button ID ="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        <br />
        <br />
        <asp:Label ID="LabelMessege" runat="server"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="hyperlink" runat="server">View Upload Image</asp:HyperLink>
    </form>
</body>
</html>
