<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CoreWeb.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="instanceId" runat="server" />
            <ol>
                <li>Email Address:
                    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox></li>
                <li>Email Title:
                    <asp:TextBox ID="txtEmailTitle" runat="server"></asp:TextBox></li>
                <li>Email Content:
                    <asp:TextBox ID="txtEmailContent" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox></li>
            </ol>
            <div>
                <asp:Button ID="btnRun" runat="server" OnCommand="RunFlow" Text="Run Flow" />
                <br />
            </div>
            <div>
                <asp:Label ID="result" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" OnCommand="ResumeFlow" Text="Resume Flow" />
                <br />

            </div>
            <div>
                <asp:Label ID="lbFinalResult" runat="server"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
