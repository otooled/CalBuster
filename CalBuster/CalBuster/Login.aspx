<%@ Page Title="CalBuster" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CalBuster.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="LoginSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="siteDetails">Recommended daily calorie intake varies from person to person, but there are guidelines for 
        calorie requirements you can use as a starting point.
       
    <p></p>
        CalBuster can help you track your daily calorie in-take to help you keep a healthy and balanced diet.
        <p></p>  Login or join us now!
    </div>
    <p></p>
    <div>
        <asp:Label ID="lblLoginHeading" runat="server" Text="Login to CalBuster" CssClass="loginHeader"></asp:Label>
    </div>
    <p></p>
    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
    <br />
    <asp:TextBox ID="txtUserName" runat="server" CssClass="highightTextbox"></asp:TextBox>
    
    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Username required" SetFocusOnError="True" ValidationGroup="valLogin"></asp:RequiredFieldValidator>
    
    <p>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="highightTextbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password required" SetFocusOnError="True" ValidationGroup="valLogin"></asp:RequiredFieldValidator>
    </p>
 
    <p>

        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="loginBtn" OnClick="btnLogin_Click" ValidationGroup="valLogin" />
        </p>
        <label>Forgot your <asp:HyperLink ID="hypUserName" runat="server" NavigateUrl="~/ForgottenDetails.aspx?purpose=userName">UserName</asp:HyperLink></label>
        <label> or <asp:HyperLink ID="hypPassword" runat="server" NavigateUrl="~/ForgottenDetails.aspx?purpose=password">Password?</asp:HyperLink></label>
    <p>
        
    
    </p>
    
    <asp:Label ID="lblNewUser" runat="server" Text="Not a member yet?  Click on the button below to join."
        CssClass="loginHeader"></asp:Label>
    
    <p>
        <asp:Button ID="btnJoin" runat="server" Text="Join Now!" CssClass="btnJoin" OnClick="btnJoin_Click" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="bmiDiv">


        <asp:Label ID="lblBMIHeader" runat="server" Text="Get your BMI now" CssClass="loginHeader"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblHeight" runat="server" Text="Height:" CssClass="highightTextbox"></asp:Label>
        <asp:TextBox ID="txtHeightFeet" runat="server" placeholder="Feet" CssClass="bmiTextBox" TextMode="Number" Width="50px"></asp:TextBox>
        <asp:TextBox ID="txtHeightInces" runat="server" placeholder="Inches" CssClass="bmiTextBox" TextMode="Number" Width="50px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="rfvHeight" runat="server" ControlToValidate="txtHeightFeet" Display="Dynamic" ErrorMessage="Feet required" SetFocusOnError="True" ValidationGroup="valBmi"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvHeightIns" runat="server" ControlToValidate="txtHeightInces" Display="Dynamic" ErrorMessage="Inches required" SetFocusOnError="True" ValidationGroup="valBmi"></asp:RequiredFieldValidator>

        <asp:RangeValidator ID="rvHeightInches" runat="server" ControlToValidate="txtHeightInces" ErrorMessage="RangeValidator" MaximumValue="12" MinimumValue="0" Type="Integer" CssClass="BMIValidator" Display="Dynamic">Inches must be between 0 and 12</asp:RangeValidator>

        <asp:RangeValidator ID="rvHeightFeet" runat="server" ControlToValidate="txtHeightFeet" CssClass="BMIValidator" Display="Dynamic" ErrorMessage="RangeValidator" MaximumValue="7" MinimumValue="4" Type="Integer">Feet must be between 4 and 7 </asp:RangeValidator>

        <p></p>
        <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="txtWeight" runat="server" placeholder="Enter weight in pounds" TextMode="Number" CssClass="bmiTextBox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvWeight" runat="server" ControlToValidate="txtWeight" Display="Dynamic" ErrorMessage="Weight required" SetFocusOnError="True" ValidationGroup="valBmi"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvWeight" runat="server" ControlToValidate="txtWeight" CssClass="BMIValidator" ErrorMessage="RangeValidator" MaximumValue="500" MinimumValue="50" Type="Integer" Display="Dynamic"></asp:RangeValidator>

        <p>
            <asp:Button ID="btnBmiResult" runat="server" Text="Get your BMI" CssClass="loginBtn" OnClick="btnBmiResult_Click" ValidationGroup="valBmi" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="loginBtn" />
        </p>
        <asp:Label ID="lblDisplayBMI" runat="server" Text="Your calculated BMI"></asp:Label>
        <p>&nbsp;</p>

    </div>
</asp:Content>


