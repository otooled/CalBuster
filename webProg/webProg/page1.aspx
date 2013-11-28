<%@ Page Title="" Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="webProg.page1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    <link href="dailyFood.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    <div id="content" >

        <div id="titleDiv" runat="server" >  <h2>Daily Calorie Tracker </h2>
            <div class="calendar"  >
                <asp:Button ID="Button1" runat="server" Text="&lt;&lt;" />
                <%--<asp:Label ID="lblDate" runat="server" Text="26 November 2013"></asp:Label>--%>
                <asp:TextBox ID="lblDate" runat="server" Width="220px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="&gt;&gt;" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="lblDate"></asp:CalendarExtender>
            </div>
        </div>
            <%-- </form>--%>
        <div id="searchForMeal" class="searchForMeal" runat="server"  >         
                <%--<h1 id="keepTop" class="main-title">Add Food To Breakfast </h1>--%>
                <asp:Label ID="lblTitle" CssClass="titled" runat="server" ></asp:Label>
        <div>      
                <h4>Search our food database by name:</h4>
                <p>
                  <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>                                   
                  <asp:Button ID="btnSubmit" runat="server"  Text="Search"   OnClick="btnSubmit_Click"   />                                			
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearch" ServiceMethod="GetCompletionList" UseContextKey="True" ></asp:AutoCompleteExtender>
                </p>
                
            </div>
            <div id="portionSection" >
                <div class="potionLabel" > <h3>Please select a portion </h3></div>
                <%--<asp:Label class="potionLabel" runat="server" Text="Please select a portion"></asp:Label>--%>
               
                <asp:TextBox ID="txtPortions" runat="server" class="txtPortions" >1</asp:TextBox>
                <asp:Label ID="lblSevings" CssClass="lblSevings"  runat="server" Text="Serving of "></asp:Label>
                <asp:Label ID="lblSelectedItem" CssClass="lblSelectedItem" runat="server"></asp:Label><br />
                <asp:Button ID="goBack" runat="server"  Text="click to add selected meal"   OnClick="goBack_Click" CssClass="addButton"   />
            </div>
                 <div id ="search_boxes">
                    <asp:TreeView class="treeV" ID="TreeView1" OnSelectedNodeChanged="TreeV_SelectedNodeChanged" RootNodeStyle-ImageUrl="images/cuts.jpg" runat="server" ImageSet="Arrows"
                        ExpandDepth="0" Font-Italic="True" Font-Size="Medium" >               
                    </asp:TreeView>                                      
                </div>
            <asp:EntityDataSource 
                    ID="EntityDataSource1" runat="server" ConnectionString="name=Cal_BusterEntities1" 
                    DefaultContainerName="Cal_BusterEntities1" EnableFlattening="False" EntitySetName="FoodItem_tbl"></asp:EntityDataSource>           
            <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hidFoodId" runat="server" />
        </div>  <%-- </form>--%>
        
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
                    <asp:TableCell ID="TableCell31" runat="server" class="addLink"><asp:LinkButton ID="lnkBtnDinner" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
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
                    <asp:TableCell ID="TableCell37" runat="server" class="addLink"><asp:LinkButton ID="LnkBtnSnacks" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell38" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell39" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell40" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell41" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell42" runat="server" class="alt2"></asp:TableCell>
              </asp:TableRow>
            <asp:TableRow ID="TotalsRow" runat="server"  >
                    <asp:TableCell ID="TableCell43" runat="server" class="firstalt">Totals</asp:TableCell>                       
                    <asp:TableCell ID="TableCell44" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell45" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell46" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell47" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell48" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
        </asp:Table>
         
        <asp:Button ID="btnAddAllToDb" OnClick="btnAddAllToDb_Click" CssClass="addAllButton" runat="server" Text="Save All" />

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
