<%@ Page Title="" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="AddMealsToDb.aspx.cs" Inherits="CalBuster.AddMealsToDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="dailyFood.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div>
        <asp:Label ID="Label3" CssClass="label" runat="server" Text="Just 4 easy steps to add your own meal"></asp:Label>
        <br/>
        <div id="steps">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow ID="TableRow1" runat="server" class="meal_header" >   
                    <asp:TableCell ID="TableCell7"  runat="server"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/num1.jpg" Height="60px" /></asp:TableCell>
                    <asp:TableCell ID="TableCell8" CssClass="step" runat="server">Click on an ingregient</asp:TableCell>
                    <asp:TableCell ID="TableCell9"  runat="server"><asp:Image ID="Image2" runat="server" ImageUrl="~/images/num2.jpg" Height="60px" /></asp:TableCell>
                    <asp:TableCell ID="TableCell10" CssClass="step"  runat="server">For each ingredient, add the portion amount</asp:TableCell>
                    <asp:TableCell ID="TableCell11"  runat="server"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/num3.jpg" Height="60px" /></asp:TableCell>
                    <asp:TableCell ID="TableCell12" CssClass="step" runat="server">Name your meal</asp:TableCell>
                    <asp:TableCell ID="TableCell1"  runat="server"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/num4.jpg" Height="60px" /></asp:TableCell>
                    <asp:TableCell ID="TableCell2" CssClass="step"  runat="server">Click Submit !</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/num1.jpg" Height="60px" />
        <div id="step1" >           
            <asp:ListBox ID="lstVeg" CssClass="addMealLists" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1"  runat="server" DataSourceID="dsVeg" DataTextField="Name" DataValueField="Item_id"  SelectionMode="Multiple" Rows="10" Width="171px" AutoPostBack="True"></asp:ListBox>
        
            <asp:ListBox ID="lstDrygoods" CssClass="addMealLists" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true"  runat="server"  Width="171px" Rows="10" SelectionMode="Multiple" DataSourceID="meatSource" DataTextField="Name" DataValueField="Item_id"></asp:ListBox>
        
            <asp:ListBox ID="lstmeat" CssClass="addMealLists" OnSelectedIndexChanged="lstVeg_SelectedIndexChanged1" AutoPostBack="true" runat="server" Width="171px" SelectionMode="Multiple" Rows="10" DataSourceID="dryGoodSource" DataTextField="Name" DataValueField="Item_id" ></asp:ListBox>
        </div>
        <asp:HiddenField ID="hdfSelValue" runat="server" />
        <asp:Image ID="Image6" CssClass="num2" runat="server" ImageUrl="~/images/num2.jpg" Height="60px" />
        <div id="Div1" >  
            <asp:TextBox ID="txtSelectedItem" runat="server" style="height: 22px"></asp:TextBox>
            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Number of portions"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" style="height: 22px"></asp:TextBox>
            <asp:Button ID="btnAddMeat" class="alt" runat="server" OnClick="btnAddItem_Click" Text="Add Selected food item" />
        </div>

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
        <asp:Image ID="Image7" runat="server" ImageUrl="~/images/num3.jpg" Height="60px" />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" CssClass="label" runat="server" Text="Name of Meal"></asp:Label><br/>
        <asp:Image ID="Image8" runat="server" ImageUrl="~/images/num4.jpg" Height="60px" />
        <asp:Button ID="btnAddMeal" runat="server" OnClick="btnAddMeal_Click" class="sendToDb" Text="Submit" />
        <asp:Button ID="btnBackToPlanner" OnClick="btnBackToPlanner_Click" runat="server"  class="sendToDb" Text="Back To Planner" />
    </div>  

    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
