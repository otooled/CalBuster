<%@ Page Title="" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="ForgottenDetails.aspx.cs" Inherits="CalBuster.ForgottenDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="dailyFood.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div id="forgotUserName" runat="server">
        <div id="headerrr"><asp:Label ID="Label1"  runat="server" Text="Label">Please enter your email address:</asp:Label></div><br/>
        <asp:TextBox ID="txtEmail" CssClass="emailtxt" runat="server"></asp:TextBox>
        <asp:Button ID="btnSendEmail" CssClass="alt" runat="server" Text="Send For Details" OnClick="btnSendEmail_Click" />
    </div>
    <div id="changePassword" runat="server">       
        <div id="passTxts">
            <asp:TextBox ID="txtFirstPassword" runat="server"></asp:TextBox><br/>    
            <asp:TextBox ID="txtSecondPassword" runat="server"></asp:TextBox>
        </div>
        <div id="passLabels">
         <div id="pLabels"><asp:Label ID="Label2"  runat="server" Text="Please type in your new password"></asp:Label></div><br/>
            <asp:Label ID="Label3" runat="server" Text="Please type in your password again"></asp:Label>
        </div>
        <div id="subBtn"><asp:Button ID="btnChangePassword" CssClass="submitBtn" runat="server" Text="Submit" OnClick="btnChangePassword_Click" /></div>
    </div>
     
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
