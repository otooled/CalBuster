<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addBreaky.aspx.cs" Inherits="webProg.addBreaky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 

    <div id="main"> 
      <h1 class="main-title">Add Food To Breakfast </h1>
        <form id="form1" runat="server"> 
                    <div id="searchForm">
                            <h3 class="secondary-title">Search our food database by name:</h3>
                                <p>
                                    <input autocomplete="on" class="text" id="search" name="search" type="text" value="coco pops"/>		
	                                <input type="submit" class="button" value="Search"/>			
                                </p>
                    </div>
        
        
            <div id ="search_boxes">
                <asp:ListBox ID="lstPicked" runat="server" DataSourceID="EntityDataSource1"
                         DataTextField="name" DataValueField="name"></asp:ListBox>             
                    <asp:TreeView ID="TreeView1" RootNodeStyle-ImageUrl="images/cuts.jpg" runat="server" ImageSet="Arrows"
                        ExpandDepth="0" Font-Italic="True" Font-Size="Medium" >               
                    </asp:TreeView>
                           
                </div>
                <asp:EntityDataSource 
                    ID="EntityDataSource1" runat="server" ConnectionString="name=dbEntities" 
                    DefaultContainerName="dbEntities" EnableFlattening="False" EntitySetName="double_tbl" Select="it.[name]"></asp:EntityDataSource>
            <input type="button" id="goBack" value="click to go back" />   
            </form>
      
    </div>




</asp:Content>
