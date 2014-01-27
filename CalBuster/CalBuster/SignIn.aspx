<%@ Page Title="CalBuster" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CalBuster.WebForm2" %>
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
           
            <asp:RequiredFieldValidator ID="rfvFname" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="First name required" SetFocusOnError="True"></asp:RequiredFieldValidator>
           
            <asp:RegularExpressionValidator ID="rgvFname" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[A-Za-z0-9 ]+$" ErrorMessage="Special characters not allowed"></asp:RegularExpressionValidator>
        
            <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurame" Display="Dynamic" ErrorMessage="Surname required" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rgvSurname" runat="server" ControlToValidate="txtSurame" Display="Dynamic" ErrorMessage="Special characters not allowed" SetFocusOnError="True" ValidationExpression="^[A-Za-z0-9 ]+$"></asp:RegularExpressionValidator>
        
        </p>

        <p>
         <asp:Label ID="lblCreateUserName" runat="server" Text="*Create UserName" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtCreateUserName" runat="server" CssClass="highightTextbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtCreateUserName" Display="Dynamic" ErrorMessage="UserName required" SetFocusOnError="True">UserName required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCreateUserName" ErrorMessage="Letters and numbers only" ValidationExpression="^[a-zA-Z0-9]*$" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
            </p>
        <p>
         <asp:Label ID="lblPassword" runat="server" Text="*Create Password" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtCreatePassword" runat="server" CssClass="highightTextbox" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword1" runat="server" ControlToValidate="txtCreatePassword" Display="Dynamic" ErrorMessage="Password Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </p>
                <p>
         <asp:Label ID="lblConfirmPassword" runat="server" Text="*Confirm Password" CssClass="labels"></asp:Label>
                    
            
            <br/>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="highightTextbox" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConPassword" runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Must re-enter password"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cpvConPassword" runat="server" ControlToCompare="txtCreatePassword" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Passwords do not match" SetFocusOnError="True"></asp:CompareValidator>
            </p>
        <p>
         <asp:Label ID="lblEmail" runat="server" Text="*Email address" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="highightTextbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rxvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Not a valid email address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>
        <p>
         <asp:Label ID="lblConfirmEmail" runat="server" Text="*Re-enter email adress" CssClass="labels"></asp:Label>
            <br/>
            <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="highightTextbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConEmail" runat="server" ControlToValidate="txtConfirmEmail" Display="Dynamic" ErrorMessage="Email confirmation required"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cpvConEmail" runat="server" ControlToCompare="txtEmail" ControlToValidate="txtConfirmEmail" Display="Dynamic" ErrorMessage="Email addresses must match" SetFocusOnError="True"></asp:CompareValidator>
            <asp:RegularExpressionValidator ID="rgvEmailCon" runat="server" ControlToValidate="txtConfirmEmail" Display="Dynamic" ErrorMessage="Not a valid email address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>
        <p>
            <asp:Label ID="lblGender" runat="server" Text="*Gender" CssClass="labels"></asp:Label>
            <asp:RadioButtonList ID="rdlGender" runat="server" CssClass="labels">
                <asp:ListItem Text="Male"></asp:ListItem>
                <asp:ListItem Text="Female"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rdlGender" Display="Dynamic" ErrorMessage="Gender must be selected" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </p>
        
            <p>
         <asp:Label ID="lblDOB" runat="server" Text="*Date of birth" CssClass="labels"></asp:Label>
            <br/>
                
            <asp:TextBox ID="txtDOB" runat="server" placeholder="DD/MM/YYYY" CssClass="highightTextbox" TextMode="Date"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="Date of birth required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="rxvDOB" runat="server" ControlToValidate="txtDOB" ErrorMessage="Date must be DD/MM/YYYY" SetFocusOnError="True" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" Display="Dynamic"></asp:RegularExpressionValidator>
                
                <asp:RangeValidator ID="rgvDob" runat="server" ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="Must be over 18 and less than 80" SetFocusOnError="True"></asp:RangeValidator>
                
            </p>
            <p>
               
                <br/>
                
                <asp:Button ID="btnRegister" runat="server" Text="Register your details" CssClass="btnRegForgot" OnClick="btnRegister_Click"  />
                
            </p>
        <p></p>
            <asp:ValidationSummary ID="valSummary" runat="server" HeaderText="Please ensure the following details are correct" ShowMessageBox="True" ShowModelStateErrors="False" ShowSummary="False" ShowValidationErrors="False" />
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
