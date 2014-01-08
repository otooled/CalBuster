<%@ Page Title="" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CalBuster.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="SignIn.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signInHeader">
        <asp:Label ID="lblSignInHeader" runat="server" Text="Enter your details to join CalBuster" CssClass="loginHeader"></asp:Label>
    </div>
    <div id="signIn">
        <div id="innerSignIn">
        <p><asp:Label ID="lblFirstName" runat="server" Text="*First name:" CssClass="labels"></asp:Label>
            <asp:Label ID="lblSurname" runat="server" Text="*Surname:" CssClass="surnameLbl"></asp:Label>
            <br/>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="highightTextbox"></asp:TextBox>
            <asp:TextBox ID="txtSurame" runat="server" CssClass="highightTextbox"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFirstName" CssClass="texVal" Display="Dynamic" ErrorMessage="First name must be letters">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurame" CssClass="texVal" Display="Dynamic" ErrorMessage="A surname is required">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cpvSurname" runat="server" ControlToValidate="txtSurame" CssClass="texVal" Display="Dynamic" ErrorMessage="Surname can only have letters">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" CssClass="texVal" Display="Dynamic" ErrorMessage="First Name"> *</asp:RequiredFieldValidator>
        </p>
        <p>
         <asp:Label ID="lblCreateUserName" runat="server" Text="*Create UserName" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtCreateUserName" runat="server" CssClass="highightTextbox"></asp:TextBox>
            </p>
        <p>
         <asp:Label ID="lblPassword" runat="server" Text="*Create Password" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtCreatePassword" runat="server" CssClass="highightTextbox"></asp:TextBox>
            </p>
                <p>
         <asp:Label ID="lblConfirmPassword" runat="server" Text="*Confirm Password" CssClass="labels"></asp:Label>
                    
            
            <br/>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="highightTextbox"></asp:TextBox>
            </p>
        <p>
         <asp:Label ID="lblEmail" runat="server" Text="*Email adress" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="highightTextbox"></asp:TextBox>
            </p>
        <p>
         <asp:Label ID="lblConfirmEmail" runat="server" Text="*Re-enter email adress" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="highightTextbox"></asp:TextBox>
            </p>
        <p>
            <asp:Label ID="lblGender" runat="server" Text="*Gender" CssClass="labels"></asp:Label>
            <asp:RadioButtonList ID="rdlGender" runat="server" CssClass="labels">
                <asp:ListItem Text="Male"></asp:ListItem>
                <asp:ListItem Text="Female"></asp:ListItem>
            </asp:RadioButtonList>
        </p>
        
            <p>
         <asp:Label ID="lblDOB" runat="server" Text="*Date of birh" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtDay" runat="server" placeholder="Day" CssClass="highightTextbox"></asp:TextBox>
                 <asp:TextBox ID="txtMonth" runat="server" placeholder="Month" CssClass="highightTextbox"></asp:TextBox>
                 <asp:TextBox ID="txtYear" runat="server" placeholder="Year" CssClass="highightTextbox"></asp:TextBox>
            </p>
            <p>
                
                <br/>
                
                <asp:Button ID="btnRegister" runat="server" Text="Register your details" CssClass="btnRegForgot" OnClick="btnRegister_Click"  />
                
            </p>
        <p></p>
            <asp:ValidationSummary ID="valSummary" runat="server" HeaderText="Please ensure the following details are correct" ShowMessageBox="True" ShowModelStateErrors="False" />
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
