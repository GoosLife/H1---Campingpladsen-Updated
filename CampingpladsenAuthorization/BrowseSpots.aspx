<%@ Page Title="Se pladser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseSpots.aspx.cs" Inherits="CampingpladsenAuthorization.BrowseSpots" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div runat="server" id="hideContentWhileLoading">
        <div class="row">
            <div class="panel panel-primary">
                <!-- Panel to customize search criteria -->
                <div class="panel-heading">Søgekriterier</div>
                <!-- Calendar - choose which dates you're planning to book for -->
                <div class="panel-body">
                    <div class="col-xs-6">
                        Udrejse
                    <asp:Calendar runat="server" type="date" ID="calendar_dateStart" SelectedDate="<%# DateTime.Today %>" />
                    </div>
                    <div class="col-xs-6">
                        Hjemrejse
                    <asp:Calendar runat="server" type="date" ID="calendar_dateEnd" SelectedDate="<%# DateTime.Today.AddDays(7) %>" />
                    </div>
                </div>
                <!-- Dropdown menu to choose the types of spots you're looking to book -->
                <div class="panel-body">
                    <div class="col-xs-12">
                            <asp:CheckBoxList ID="cbl_spotTypes" runat="server" OnSelectedIndexChanged="cbl_spotTypes_SelectedIndexChanged" AutoPostBack="True">
                            </asp:CheckBoxList>
                    </div>
                </div>
            </div>
        </div>

        <!-- Datalist displaying all the available spots for the selected dates -->
        <asp:DataList ID="datalist_spots" runat="server" RepeatColumns="4">
            <ItemTemplate>
                <div class="list-group">
                    <a href="/BookSpot?id=<%# Eval("spot_id") %>&startDate=<%=calendar_dateStart.SelectedDate %>&endDate=<%= calendar_dateEnd.SelectedDate %>" class="list-group-item">
                        <%# Eval("spot_name") %><br />
                        <%# Eval("spot_type") %>
                    </a>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
