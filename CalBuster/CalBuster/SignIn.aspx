<%@ Page Title="" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CalBuster.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="LoginSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signInHeader">
        <asp:Label ID="lblSignInHeader" runat="server" Text="Enter your details to join CalBuster" CssClass="loginHeader"></asp:Label>
    </div>
    <div id="signIn">
        
        <p><asp:Label ID="lblFirstName" runat="server" Text="*First name:" CssClass="SignInTBandLab"></asp:Label>
            <asp:Label ID="lblSurname" runat="server" Text="*Surname:" CssClass="signInLabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="SignInTBandLab"></asp:TextBox>
            <asp:TextBox ID="txtSurame" runat="server" CssClass="signInTextBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" CssClass="registerVal"></asp:RequiredFieldValidator>
        </p>
        <p>
         <asp:Label ID="lblCreateUserName" runat="server" Text="*Create UserName" CssClass="SignInTBandLab"></asp:Label>
            <br/>
            <asp:TextBox ID="txtCreateUserName" runat="server" CssClass="SignInTBandLab"></asp:TextBox>
            </p>
        <p>
         <asp:Label ID="lblPassword" runat="server" Text="Create Password" CssClass="SignInTBandLab"></asp:Label>
            <br/>
            <asp:TextBox ID="txtCreatePassword" runat="server" CssClass="SignInTBandLab"></asp:TextBox>
            </p>
                <p>
         <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="SignInTBandLab"></asp:Label>
            <br/>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="SignInTBandLab"></asp:TextBox>
            </p>
        <p>
         <asp:Label ID="lblEmail" runat="server" Text="*Email adress" CssClass="SignInTBandLab"></asp:Label>
            <br/>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="SignInTBandLab"></asp:TextBox>
            </p>
        <p>
         <asp:Label ID="lblConfirmEmail" runat="server" Text="*Re-enter email adress" CssClass="SignInTBandLab"></asp:Label>
            <br/>
            <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="SignInTBandLab"></asp:TextBox>
            </p>
        <p>
            <asp:Label ID="lblGender" runat="server" Text="*Gender" CssClass="SignInTBandLab"></asp:Label>
            <asp:RadioButtonList ID="rdlGender" runat="server" CssClass="SignInTBandLab">
                <asp:ListItem Text="Male"></asp:ListItem>
                <asp:ListItem Text="Female"></asp:ListItem>
            </asp:RadioButtonList>
        </p>
        
            <p>
         <asp:Label ID="lblDOB" runat="server" Text="*Date of birh" CssClass="SignInTBandLab"></asp:Label>
            <br/>
            <asp:TextBox ID="txtDay" runat="server" placeholder="Day" CssClass="SignInTBandLab"></asp:TextBox>
                 <asp:TextBox ID="txtMonth" runat="server" placeholder="Month" CssClass="SignInTBandLab"></asp:TextBox>
                 <asp:TextBox ID="Year" runat="server" placeholder="Year" CssClass="SignInTBandLab"></asp:TextBox>
            </p>
            <p>
                <br/>
                
                <asp:Button ID="btnRegister" runat="server" Text="Register your details" CssClass="btnRegForgot" OnClick="btnRegister_Click"  />
                
            </p>
        <p></p>
            <asp:ValidationSummary ID="vsRequiredFields" HeaderText="You must enter a value in the following fields:" runat="server" ShowMessageBox="True" ShowModelStateErrors="False" ShowSummary="False" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
