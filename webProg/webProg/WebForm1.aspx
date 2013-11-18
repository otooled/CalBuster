<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webProg.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <form id="form1" runat="server">

        <asp:Table ID="tblAdded" runat="server">             
                   <asp:TableHeaderRow>
                      <asp:TableCell ID="TableCell1"  runat="server" class="lSide" />
                      <asp:TableCell ID="TableCell2"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell3"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell4"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell5"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell6"  runat="server" class="rSide" />
                  </asp:TableHeaderRow>
            
                <asp:TableRow ID="TableRow1" runat="server" class="meal_header" >   
                    <asp:TableCell ID="TableCell7" class="firstalt" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell8" class="alt" runat="server">Calories</asp:TableCell>
                    <asp:TableCell ID="TableCell9" class="alt" runat="server">Calories</asp:TableCell>
                    <asp:TableCell ID="TableCell10" class="alt" runat="server">Fat</asp:TableCell>
                    <asp:TableCell ID="TableCell11" class="alt" runat="server">Protein</asp:TableCell>
                    <asp:TableCell ID="TableCell12" class="alt" runat="server">Sugar</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow9" runat="server"  >
                    <asp:TableCell ID="TableCell55" runat="server" class="firstalt">Beakfast</asp:TableCell>                       
                    <asp:TableCell ID="TableCell56" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell57" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell58" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell59" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell60" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
        </asp:Table>
        
        <asp:Table runat="server">  
            <asp:TableHeaderRow>
                      <asp:TableCell ID="TableCell61"  runat="server" class="lSide" />
                      <asp:TableCell ID="TableCell62"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell63"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell64"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell65"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell66"  runat="server" class="rSide" />
                  </asp:TableHeaderRow>  
                <asp:TableRow ID="TableRow2" runat="server"  >
                    <asp:TableCell ID="TableCell13" runat="server" class="addLink"><asp:LinkButton ID="LinkButton2" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell14" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell15" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell16" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell17" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell18" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow3" runat="server"  >
                    <asp:TableCell ID="TableCell19" runat="server" class="firstalt">Lunch</asp:TableCell>                       
                    <asp:TableCell ID="TableCell20" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell21" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell22" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell23" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell24" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
        </asp:Table>

        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                      <asp:TableCell ID="TableCell67"  runat="server" class="lSide" />
                      <asp:TableCell ID="TableCell68"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell69"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell70"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell71"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell72"  runat="server" class="rSide" />
                  </asp:TableHeaderRow>
                <asp:TableRow ID="TableRow4" runat="server"  >
                    <asp:TableCell ID="TableCell25" runat="server" class="addLink"><asp:LinkButton ID="LinkButton3" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell26" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell27" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell28" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell29" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell30" runat="server" class="alt2"></asp:TableCell>
              </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server"  >
                    <asp:TableCell ID="TableCell31" runat="server" class="firstalt">Dinner</asp:TableCell>                       
                    <asp:TableCell ID="TableCell32" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell33" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell34" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell35" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell36" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table ID="Table2" runat="server">
                <asp:TableHeaderRow>
                      <asp:TableCell ID="TableCell73"  runat="server" class="lSide" />
                      <asp:TableCell ID="TableCell74"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell75"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell76"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell77"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell78"  runat="server" class="rSide" />
                  </asp:TableHeaderRow>
                <asp:TableRow ID="TableRow6" runat="server"  >
                    <asp:TableCell ID="TableCell37" runat="server" class="addLink"><asp:LinkButton ID="LinkButton4" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell38" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell39" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell40" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell41" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell42" runat="server" class="alt2"></asp:TableCell>
              </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server"  >
                    <asp:TableCell ID="TableCell43" runat="server" class="firstalt">Snacks</asp:TableCell>                       
                    <asp:TableCell ID="TableCell44" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell45" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell46" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell47" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell48" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table runat="server">
                <asp:TableHeaderRow>
                      <asp:TableCell ID="TableCell79"  runat="server" class="lSide" />
                      <asp:TableCell ID="TableCell80"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell81"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell82"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell83"  runat="server" class="rSide" />
                      <asp:TableCell ID="TableCell84"  runat="server" class="rSide" />
                  </asp:TableHeaderRow>
                <asp:TableRow ID="TableRow8" runat="server"  >
                    <asp:TableCell ID="TableCell49" runat="server" class="addLink"><asp:LinkButton ID="LinkButton5" OnClick="btnAdd_Click" runat="server">Add Meal</asp:LinkButton></asp:TableCell>                       
                    <asp:TableCell ID="TableCell50" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell51" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell52" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell53" runat="server" class="alt2"></asp:TableCell>
                    <asp:TableCell ID="TableCell54" runat="server" class="alt2"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>


        <asp:TextBox ID="txtbox" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" onClick="Button1_Click" Text="Button" />
        <br />
        <div id="ddd" runat="server"><h1>gggggggggg</h1></div>
        <asp:Table  runat="server" id="aaa" >
            <asp:TableRow runat="server"  >
                <asp:TableCell runat="server" id="g"><asp:LinkButton ID="btnAdd" runat="server" Text="" OnClick="btnAdd_Click" />
                      oneee </asp:TableCell>
                <asp:TableCell runat="server">two</asp:TableCell>
                <asp:TableCell runat="server">three</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">hain</asp:TableCell>
                <asp:TableCell runat="server"  >
                    <asp:LinkButton ID="LinkButton1" OnClick="btnAdd_Click" runat="server">jjjj</asp:LinkButton></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:ListBox ID="lstbox" runat="server"></asp:ListBox>
    </form>

    <script type="text/javascript">
        function startUp() {
            $("#d").hide();
        }
    function addMeal() {
        $("#aaa").click(function () {
                $("#d").show();
                $("#title").hide();
            });
            $("#goBack").click(function () {
                $("#ddd").hide();
                $("#title").show();
            });
        }
    </script>

</asp:Content>
