<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MbWeb.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>

