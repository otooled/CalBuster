<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addMeals.aspx.cs" Inherits="webProg.addMeals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="lstVeg" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true"  runat="server" DataSourceID="dsVeg" DataTextField="Name" DataValueField="Item_id"  SelectionMode="Multiple" Rows="10" Width="171px"></asp:ListBox>
        <br />
        <asp:ListBox ID="lstDrygoods" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true"  runat="server"  Width="171px" Rows="10" SelectionMode="Multiple" DataSourceID="meatSource" DataTextField="Name" DataValueField="Item_id"></asp:ListBox><asp:TextBox ID="txtSelectedItem" runat="server" style="height: 22px"></asp:TextBox><asp:TextBox ID="txtQuantity" runat="server" style="height: 22px"></asp:TextBox>
        <br />
        <asp:ListBox ID="lstmeat" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true" runat="server" Width="171px" SelectionMode="Multiple" Rows="10" DataSourceID="dryGoodSource" DataTextField="Name" DataValueField="Item_id" ></asp:ListBox><asp:Button ID="btnAddMeat" runat="server" OnClick="btnAddItem_Click" Text="Add Selected food item" />
        <br />
        <asp:HiddenField ID="hdfSelValue" runat="server" />
        
        <asp:SqlDataSource ID="dryGoodSource" runat="server" ConnectionString="<%$ ConnectionStrings:Cal_BusterConnectionString %>" SelectCommand="SELECT * FROM [FoodItem_tbl] WHERE ([FoodCatagory] = @FoodCatagory)">
            <SelectParameters>
                <asp:Parameter DefaultValue="DryGood" Name="FoodCatagory" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="meatSource" runat="server" ConnectionString="<%$ ConnectionStrings:Cal_BusterConnectionString %>" SelectCommand="SELECT * FROM [FoodItem_tbl] WHERE ([FoodCatagory] = @FoodCatagory)">
            <SelectParameters>
                <asp:Parameter DefaultValue="meatFish" Name="FoodCatagory" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        
        <br />
        
        <asp:ListBox ID="listToAdd" SelectionMode="Multiple" runat="server" ></asp:ListBox>
        <asp:SqlDataSource ID="dsVeg" runat="server" ConnectionString="<%$ ConnectionStrings:Cal_BusterConnectionString %>" SelectCommand="SELECT * FROM [FoodItem_tbl] WHERE ([FoodCatagory] = @FoodCatagory)">
            <SelectParameters>
                <asp:Parameter DefaultValue="veg" Name="FoodCatagory" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:ListBox ID="lst1" runat="server"></asp:ListBox>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAddMeal" runat="server" OnClick="btnAddMeal_Click" Text="Add meal to db" />
    
    </div>
    </form>
</body>
</html>
