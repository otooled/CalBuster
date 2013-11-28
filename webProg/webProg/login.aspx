<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="webProg.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="LoginSS.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div id="content" >
  <div id="leftcolumn">
        <div>
        <asp:Label ID="lblLoginHeading" runat="server" Text="Login to CalBuster" CssClass="loginHeader"></asp:Label>
        </div>
    <p></p>
    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
    <br />
    <asp:TextBox ID="txtUserName" runat="server" CssClass="highightTextbox"></asp:TextBox>
    <p>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="highightTextbox"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="loginBtn" />
        <asp:Button ID="btnForgotDetails" runat="server" Text="Forgot user name or password?" CssClass="btnRegForgot" />
    </p>
    <asp:Label ID="lblNewUser" runat="server" Text="Not a member yet?  Click on the button below to join."
        CssClass="loginHeader"></asp:Label>

    <p>

        <asp:Button ID="btnJoin" runat="server" Text="Join Now!" CssClass="btnJoin" OnClick="btnJoin_Click" />

    </p>
      
</div>
<%--</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">--%>
   <div id="rightcolumn" >
    <div>


        <asp:Label ID="lblBMIHeader" runat="server" Text="Get your BMI now" CssClass="loginHeader"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblHeight" runat="server" Text="Height:" CssClass="highightTextbox"></asp:Label>
        <asp:TextBox ID="txtHeightFeet" runat="server" placeholder="Feet" CssClass="bmiTextBox" TextMode="Number" Width="50px"></asp:TextBox>
        <asp:TextBox ID="txtHeightInces" runat="server" placeholder="Inches" CssClass="bmiTextBox" TextMode="Number" Width="50px"></asp:TextBox>

        <asp:RangeValidator ID="rvHeightInches" runat="server" ControlToValidate="txtHeightInces" ErrorMessage="RangeValidator" MaximumValue="12" MinimumValue="0" Type="Integer" CssClass="BMIValidator" Display="Dynamic">Inches must be between 0 and 12</asp:RangeValidator>

        <asp:RangeValidator ID="rvHeightFeet" runat="server" ControlToValidate="txtHeightFeet" CssClass="BMIValidator" Display="Dynamic" ErrorMessage="RangeValidator" MaximumValue="7" MinimumValue="4" Type="Integer">Height must be between 4 and 7 </asp:RangeValidator>

        <asp:RequiredFieldValidator ID="rfvHeightInches" runat="server" ControlToValidate="txtHeightInces" CssClass="BMIValidator" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Visible="False"></asp:RequiredFieldValidator>

        <p>&nbsp;</p>
        <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="txtWeight" runat="server" placeholder="Enter weight in pounds" TextMode="Number" CssClass="bmiTextBox"></asp:TextBox>
        <asp:RangeValidator ID="rvWeight" runat="server" ControlToValidate="txtWeight" CssClass="BMIValidator" ErrorMessage="RangeValidator" MaximumValue="500" MinimumValue="50" Type="Integer"></asp:RangeValidator>

        <p>
            <asp:Button ID="btnBmiResult" runat="server" Text="Get your BMI" CssClass="loginBtn" OnClick="btnBmiResult_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="loginBtn" />
        </p>
        <asp:Label ID="lblDisplayBMI" runat="server" Text="Your calculated BMI"></asp:Label>
        <p>&nbsp;</p>

    </div>
    </div>
    </div>
</asp:Content>

