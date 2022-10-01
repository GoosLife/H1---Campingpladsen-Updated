<%@ Page Title="Log ind" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CampingpladsenAuthorization.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Add login style -->
    <link rel="stylesheet" href="Content/LoginStyle.css" />

    <!-- Login form -->
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-6 col-md-8 login-box">
                <div class="col-lg-12 login-key">
                    <i class="fa fa-key" aria-hidden="true"></i>
                </div>
                <div class="col-lg-12 login-title">
                    ADMIN PANEL
                </div>

                <div class="col-lg-12 login-form">
                    <div class="col-lg-12 login-form">
                        <div class="form-group">
                            <label class="form-control-label">BRUGERNAVN</label>
                            <input type="text" class="form-control" id="text_username" runat="server">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label">KODEORD</label>
                            <input type="password" class="form-control" id="text_password" runat="server">
                        </div>

                        <div class="col-lg-12 loginbttm">
                            <div class="col-lg-6 login-btm login-text">
                                <!-- Error Message -->
                                <span class="label label-danger" Visible="False" id="lbl_invalidCredentials" runat="server">Forkert kodeord eller brugernavn!</span>
                            </div>
                            <div class="col-lg-6 login-btm login-button">
                                <input type="submit" ID="btn_login" class="btn btn-outline-primary" runat="server" value="Log ind"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-2"></div>
            </div>
        </div>
    </div>
</asp:Content>
