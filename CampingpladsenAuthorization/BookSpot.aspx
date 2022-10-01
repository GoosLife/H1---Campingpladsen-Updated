<%@ Page Title="Book plads" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookSpot.aspx.cs" Inherits="CampingpladsenAuthorization.BookSpot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Demonstration that I can get and display all data from this booking -->
    <asp:DataList ID="datalist_spotToBook" runat="server">
        <ItemTemplate>
            <%# Eval("spot_name") %>
            <%# Eval("spot_type") %>
            <%# Eval("spot_price") %>
        </ItemTemplate>
    </asp:DataList>
    Navn:
    <input type="text" id="text_customerName" runat="server"/>
    Adresse:
    <input type="text" id="text_customerAddress" runat="server"/>
    Telefonnummer:
    <input type="tel" id="text_customerPhone" runat="server"/>
    Email:
    <input type="email" id="text_customerEmail" runat="server" />
    Voksne:
    <input type="number" min="0" max="6" value="0" runat="server" id="number_adults"/>
    Børn:
    <input type="number" min="0" max="6" value="0" runat="server" id="number_children" />
    Hunde:
    <input type="number" min="0" value="0" runat="server" id="number_dogs" />
    Sengelinned:
    <input type="checkbox" runat="server" id="cb_bedLinen" />
    Slutrengøring:
    <input type="checkbox" runat="server" id="cb_exitCleaning"/>
    Cykelleje antal:
    <input type="number" min="0" max="12" value="0" runat="server" id="number_bikes" />
    Cykelleje dage:
    <input type="number" min="0" max="7" value="0" runat="server" id="number_bikeDays" />
    Adgang til badeland, voksne:
    <input type="number" min="0" max="6" value="0" runat="server" id="number_waterParkPassAdults" />
    Adgang til badeland, børn:
    <input type="number" min="0" max="6" value="0" runat="server" id="number_waterParkPassChildren" />

    <asp:Button ID="btn_makeReservation" class="btn btn-success" runat="server" Text="Reservér" OnClick="btn_makeReservation_Click" />
    <asp:Label runat="server" ID="lbl_invalidForm" class="alert-danger" Visible="false">FEJL - Udfyld venligst hele formen.</asp:Label>
</asp:Content>
