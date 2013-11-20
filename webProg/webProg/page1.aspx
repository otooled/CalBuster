<%@ Page Title="" Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="webProg.page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    <link href="dailyFood.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    <div id="content">
    <div id="title" runat="server" >  <h2>bla bla bla </h2>    </div>
    <%--<form id="form1" runat="server">--%>
    <div id="searchForMeal" runat="server"  > 
        
      <h1 id="keepTop" class="main-title">Add Food To Breakfast </h1>
        
                    <div>
                            <h3 class="secondary-title">Search our food database by name:</h3>
                                <p>
              <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>                                   
              <asp:Button ID="btnSubmit" runat="server"  Text="Search"   OnClick="btnSubmit_Click"   />                                			
                                </p>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                 <div id ="search_boxes">
                     <asp:TextBox ID="txtNme" runat="server"></asp:TextBox>
                     <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                     <asp:ListBox  class="listb" ID="lstPicked" runat="server" DataTextField="description"></asp:ListBox>
                    <asp:TreeView class="treeV" ID="TreeView1" OnSelectedNodeChanged="TreeV_SelectedNodeChanged" RootNodeStyle-ImageUrl="images/cuts.jpg" runat="server" ImageSet="Arrows"
                        ExpandDepth="0" Font-Italic="True" Font-Size="Medium" >               
                    </asp:TreeView>                                      
                </div>
            <asp:EntityDataSource 
                    ID="EntityDataSource1" runat="server" ConnectionString="name=dbEntities" 
                    DefaultContainerName="dbEntities" EnableFlattening="False" EntitySetName="double_tbl" Select="it.[name]"></asp:EntityDataSource>
            
            <asp:Button ID="goBack" runat="server"  Text="click to add selected meal"   OnClick="goBack_Click"   />
           </div>  
        
        <asp:Table ID="tblAdded" runat="server"> 
              
               <asp:TableHeaderRow>
                  <asp:TableCell  runat="server" class="lSide" />
                  <asp:TableCell  runat="server" class="rSide" />
                  <asp:TableCell  runat="server" class="rSide" />
                  <asp:TableCell  runat="server" class="rSide" />
                  <asp:TableCell  runat="server" class="rSide" />
                  <asp:TableCell  runat="server" class="rSide" />
              </asp:TableHeaderRow>
            
                <asp:TableRow ID="TableRow1" runat="server" class="meal_header" >   
                    <asp:TableCell ID="TableCell1" class="firstalt" runat="server">Breakfast</asp:TableCell>
                    <asp:TableCell ID="TableCell2" class="alt" runat="server">Calories</asp:TableCell>
                    <asp:TableCell ID="TableCell3" class="alt" runat="server">Carbs</asp:TableCell>
                    <asp:TableCell ID="TableCell4" class="alt" runat="server">Fat</asp:TableCell>
                    <asp:TableCell ID="TableCell5" class="alt" runat="server">Protein</asp:TableCell>
                    <asp:TableCell ID="TableCell6" class="alt" runat="server">Sugar</asp:TableCell>
                </asp:TableRow>

            
                <asp:TableRow runat="server"  >
                    <asp:TableCell runat="server" class="addLink"><asp:LinkButton ID="lnkBtnBreakfast" OnClick="btnAdd_Click" runat="server" TabIndex="0">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server"  >
                    <asp:TableCell ID="TableCell7" runat="server" class="firstalt">Lunch</asp:TableCell>                       
                    <asp:TableCell ID="TableCell8" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell9" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell10" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell11" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell12" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
           

        
                <asp:TableRow runat="server"  >
                    <asp:TableCell ID="TableCell13" runat="server" class="addLink"><asp:LinkButton ID="lnkBtnLunch" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell14" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell15" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell16" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell17" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell18" runat="server" class="alt2"></asp:TableCell>
              </asp:TableRow>
                <asp:TableRow runat="server"  >
                    <asp:TableCell ID="TableCell19" runat="server" class="firstalt">Dinner</asp:TableCell>                       
                    <asp:TableCell ID="TableCell20" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell21" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell22" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell23" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell24" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server"  >
                    <asp:TableCell ID="TableCell31" runat="server" class="addLink"><asp:LinkButton ID="LinkButton2" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell32" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell33" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell34" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell35" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell36" runat="server" class="alt2"></asp:TableCell>
              </asp:TableRow>
                <asp:TableRow runat="server"  >
                    <asp:TableCell ID="TableCell25" runat="server" class="firstalt">Snacks</asp:TableCell>                       
                    <asp:TableCell ID="TableCell26" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell27" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell28" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell29" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell30" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server"  >
                    <asp:TableCell ID="TableCell37" runat="server" class="addLink"><asp:LinkButton ID="LinkButton4" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell38" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell39" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell40" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell41" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell42" runat="server" class="alt2"></asp:TableCell>
              </asp:TableRow>
        </asp:Table>
         
       <%-- </form>--%>
    
</div>
    <script type="text/javascript">
        function startUp() {         
            $("#searchForMeal").hide();
        }
        function addMeal() {
            $("#aaa").click(function () {
                $("#searchForMeal").show();
                $("#title").hide();
            });
            $("#goBack").click(function () {
                $("#searchForMeal").hide();
                $("#title").show();
            });
        }
        
    </script>
    
</asp:Content>
