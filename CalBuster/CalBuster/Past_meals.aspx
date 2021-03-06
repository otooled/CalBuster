﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CalBuster.Master" AutoEventWireup="true" CodeBehind="Past_meals.aspx.cs" Inherits="CalBuster.Past_meals" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow ID="TableRow4" runat="server" class="meal_header">

            <asp:TableCell ID="TableCell1" VerticalAlign="Top" class="firstalt" runat="server">Select a Date</asp:TableCell>
            <asp:TableCell ID="TableCell2" VerticalAlign="Top" class="firstalt" runat="server">Summary</asp:TableCell>
            <asp:TableCell ID="TableCell3" VerticalAlign="Top" class="firstalt" runat="server">Plot previous 7 days</asp:TableCell>

        </asp:TableRow>

        <asp:TableRow ID="TableRow3" runat="server" class="meal_header">
            <asp:TableCell ID="tcCalendar" VerticalAlign="Top" class="firstalt" runat="server">

                <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"  OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar></asp:TableCell>

             <asp:TableCell ID="tcSummary" VerticalAlign="Top" class="firstalt" runat="server">

                
                <!--<br />-->
                <asp:TextBox ID="tbx_Meal" runat="server" Height="170px" TextMode="MultiLine" Width="265px"></asp:TextBox>
                <!--<br />-->

            </asp:TableCell>

            <asp:TableCell VerticalAlign="Top" runat="server">
               
                
                <asp:Button ID="btnPlotCalories" runat="server" OnClick="btnPlotCalories_Click" Text="Calories" />
               <asp:Button ID="btnPlotCarbs" runat="server" OnClick="btnPlotCarbs_Click" Text="Carbs" />
               <asp:Button ID="Button2" runat="server" OnClick="btnPlotFat_Click" Text="Fat" />
               <asp:Button ID="btnPlotProtein" runat="server" OnClick="btnPlotProtein_Click" Text="Protein" />
               <asp:Button ID="btnPlotSugar" runat="server" OnClick="btnPlotSugar_Click" Text="Sugar" />


                <asp:Chart ID="Chart1" runat="server">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

            </asp:TableCell>

        </asp:TableRow>


    </asp:Table>
    <br />

    <br />
    <br />

    <link href="dailyFood.css" rel="stylesheet" />



    <asp:Table ID="Past_Meals_Table" runat="server" Height="74px">
        <asp:TableRow ID="TableRow1" runat="server" class="meal_header">
            <asp:TableCell ID="TableCell7" class="firstalt" runat="server">Total</asp:TableCell>
            <asp:TableCell ID="TableCell8" class="alt" runat="server">Calories</asp:TableCell>
            <asp:TableCell ID="TableCell9" class="alt" runat="server">Carbs</asp:TableCell>
            <asp:TableCell ID="TableCell10" class="alt" runat="server">Fat</asp:TableCell>
            <asp:TableCell ID="TableCell11" class="alt" runat="server">Protein</asp:TableCell>
            <asp:TableCell ID="TableCell12" class="alt" runat="server">Sugar</asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCellTotal" runat="server" class="alt2"></asp:TableCell>
            <asp:TableCell ID="tcTotalCal" runat="server" class="alt2"></asp:TableCell>
            <asp:TableCell ID="tcTotalCarb" runat="server" class="alt2"></asp:TableCell>
            <asp:TableCell ID="tcTotalFat" runat="server" class="alt2"></asp:TableCell>
            <asp:TableCell ID="tcTotalProt" runat="server" class="alt2"></asp:TableCell>
            <asp:TableCell ID="tcTotalSug" runat="server" class="alt2"></asp:TableCell>
        </asp:TableRow>

    </asp:Table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
