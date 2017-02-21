﻿<%@ Page
    Title="Browse"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Browse.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Browse" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <style>
        td {
            padding: 0;
        }

        img {
            width: 100%;
            height: 240px;
            object-fit: contain;
        }

        .card-title,
        .card-action {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:ListView
                ID="BrowseDishesListView" runat="server"
                ItemType="WhenItsDone.Data.EntityDataSourceContainer.Dishes"
                SelectMethod="BrowseDishesListViewGetData"
                DataKeyNames="Id">

                <LayoutTemplate>
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </div>

                    <asp:DataPager runat="server" PageSize="5" QueryStringField="Id">
                        <Fields>
                            <asp:NextPreviousPagerField />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="row">
                        <div class="col s12 m6">
                            <div class="card blue-grey darken-1">
                                <div class="card-content white-text">
                                    <span class="card-title"><%#: Item.Recipes.Name %></span>
                                    <p>
                                        <img src="<%#: Item.PhotoItems.FirstOrDefault().Url %>" alt="<%#: Item.Recipes.Name %>" />
                                    </p>
                                </div>
                                <div class="card-action">
                                    <a href="/details?itemid=<%#: Item.Id %>">More info</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:ListView>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
