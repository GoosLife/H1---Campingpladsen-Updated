<%@ Page Title="Administratorpanel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="CampingpladsenAuthorization.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <ul class="nav nav-pills">
            <li role="presentation" class="active"><a data-toggle="tab" href="#current-reservations">Nuværende og kommende reservationer</a></li>
            <li role="presentation"><a data-toggle="tab" href="#all-reservations">Alle reservationer</a></li>
        </ul>

        <div class="row" style="margin-top:15px;">
            <div class="tab-content">

                <!-- See current and future reservations -->
                <div id="current-reservations" class="tab-pane fade in active">
                    <asp:GridView ID="gv_currentReservations" runat="server" Class="table table-striped">
                    </asp:GridView>
                </div>

                <!-- See all reservations, past, present and future -->
                <div id="all-reservations" class="tab-pane fade">
                    <asp:GridView ID="gv_allReservations" runat="server" Class="table table-striped">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
