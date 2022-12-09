<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Final.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 441px; width: 1202px">
    <form id="form1" runat="server">
        <div>
        </div>
        <p style="height: 102px; width: 1197px">
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCok" runat="server" Text="Çok Satanlar" Width="100px" OnClick="btnCok_Click" OnPreRender="btnCok_PreRender" />
        &nbsp;&nbsp;
            <asp:Button ID="btnCocuk" runat="server" OnClick="btnCocuk_Click" Text="Çocuk Kitapları" Width="122px" />
        &nbsp;&nbsp;
            <asp:Button ID="btnEdebiyat" runat="server" Text="Edebiyat ve Kurgu" Width="153px" OnClick="btnEdebiyat_Click" />
        &nbsp;&nbsp;
            <asp:Button ID="btnSiyaset" runat="server" Text="Siyaset ve Felsefe" Width="150px" OnClick="btnSiyaset_Click" />
        &nbsp;&nbsp;
            <asp:Button ID="btnYabanci" runat="server" Text="Yabancı Dilde Kitaplar" Width="173px" OnClick="btnYabanci_Click" />
        &nbsp;&nbsp;
            <asp:Button ID="btnHepsi" runat="server" OnClick="btnHepsi_Click" Text="Hepsi" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Height="61px" Width="138px" ImageUrl="~/Pictures/shop.jpg" PostBackUrl="~/Cart.aspx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LogoutBtn" runat="server" OnClick="LogoutBtn_Click" Text="Logout" OnPreRender="LogoutBtn_PreRender" Width="92px" />
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="437px" style="margin-left: 0px" Width="1195px">
        </asp:Panel>
        <p style="height: 46px; width: 1197px">
            &nbsp;<asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/App_Data/reklam.xml" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p style="width: 132px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
