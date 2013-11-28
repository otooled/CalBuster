<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webProg.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
        <br />
        <br />
        <br />
        <br />
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt1"></ajaxToolkit:CalendarExtender>


        <asp:Button ID="Button1" runat="server" Text="&lt;&lt;" />
        <asp:Label ID="Label1" runat="server" Text="26 November 2013"></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="&gt;&gt;" />


    </div>
    </form>
</body>
</html>
