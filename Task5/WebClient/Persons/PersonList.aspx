<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="WebClient.PersonList" %>

<asp:Content ID="HeadPlaceholder" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="FormPlaceholder" ContentPlaceHolderID="FormPlaceHolder" runat="server">
    <div class="table-responsive">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Last name</th>
                    <th>Date of birth</th>
                    <th>Delete</th>
                    <th>Phones</th>
                </tr>
            </thead>
            <tbody runat="server" id="tableBody" enableviewstate="false">
            </tbody>
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="InsertFieldsPlaceholder" runat="server">
    <h2 class="form-signin-heading">Person fields</h2>
    <input type="number" class="form-control" placeholder="Id" autofocus="" runat="server" id="idInput" />
    <input type="text" class="form-control" placeholder="Name" runat="server" id="nameInput" />
    <input type="text" class="form-control" placeholder="Last Name" runat="server" id="lastNameInput" />
    <input type="date" class="form-control" placeholder="Day of birth" runat="server" id="dateInput" />
    <button class="btn btn-lg btn-primary btn-block" type="button" runat="server" onserverclick="InsertClick">Insert person</button>
</asp:Content>
