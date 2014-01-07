<%@ Page Title="" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="AddMealsToDb.aspx.cs" Inherits="CalBuster.AddMealsToDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="dailyFood.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <div>
    
        <asp:ListBox ID="lstVeg" CssClass="addMealLists" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true"  runat="server" DataSourceID="dsVeg" DataTextField="Name" DataValueField="Item_id"  SelectionMode="Multiple" Rows="10" Width="171px"></asp:ListBox>
        
        <asp:ListBox ID="lstDrygoods" CssClass="addMealLists" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true"  runat="server"  Width="171px" Rows="10" SelectionMode="Multiple" DataSourceID="meatSource" DataTextField="Name" DataValueField="Item_id"></asp:ListBox>
        
        <asp:ListBox ID="lstmeat" CssClass="addMealLists" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true" runat="server" Width="171px" SelectionMode="Multiple" Rows="10" DataSourceID="dryGoodSource" DataTextField="Name" DataValueField="Item_id" ></asp:ListBox>
        <asp:HiddenField ID="hdfSelValue" runat="server" />
        <br/>
        <asp:TextBox ID="txtSelectedItem" runat="server" style="height: 22px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Number of portions"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server" style="height: 22px"></asp:TextBox>
        <asp:Button ID="btnAddMeat" runat="server" OnClick="btnAddItem_Click" Text="Add Selected food item" />
        
        <asp:SqlDataSource ID="dryGoodSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FoodItem_tbl] WHERE ([FoodCatagory] = @FoodCatagory)">
            <SelectParameters>
                <asp:Parameter DefaultValue="DryGood" Name="FoodCatagory" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="meatSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FoodItem_tbl] WHERE ([FoodCatagory] = @FoodCatagory)">
            <SelectParameters>
                <asp:Parameter DefaultValue="meatFish" Name="FoodCatagory" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       <br/>
        <asp:ListBox ID="listToAdd" CssClass="addMealLists2" SelectionMode="Multiple" runat="server" ></asp:ListBox>
        <asp:SqlDataSource ID="dsVeg" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FoodItem_tbl] WHERE ([FoodCatagory] = @FoodCatagory)">
            <SelectParameters>
                <asp:Parameter DefaultValue="veg" Name="FoodCatagory" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Name of Meal"></asp:Label>
        <asp:Button ID="btnAddMeal" runat="server" OnClick="btnAddMeal_Click" Text="Add meal to db" />
    
    </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
