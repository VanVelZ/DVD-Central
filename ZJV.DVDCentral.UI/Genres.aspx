<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Genres.aspx.cs" Inherits="ZJV.DVDCentral.UI.Genres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
            <div class="header rounded-top">
        <h3>Maintain Genres</h3>
    </div>
    <p></p>


    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="label1" runat="server" Text="Genre:"></asp:Label>

        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlExisting"
                              runat="server"
                              CssClass="form-control"
                              AutoPostBack="true"
                              OnSelectedIndexChanged="ddlExisting_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>

        </div>
        <div class="control-label col-md-3">
            <asp:TextBox ID="txtDescription" 
                         runat="server"
                         CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group mt-2 ml-5">
    <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-primary btn-med ml-3" Text="Insert" OnClick="btnInsert_Click" />
    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-med ml-3" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary btn-med ml-3" Text="Delete" OnClick="btnDelete_Click" />
    </div>
        </div>
</asp:Content>
