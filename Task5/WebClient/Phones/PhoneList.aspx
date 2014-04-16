<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneList.aspx.cs" Inherits="WebClient.Phones.PhoneList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="FormPlaceHolder" runat="server">
        <div class="table-responsive">
        <table class="table table-striped">
            <thead>
            <tr>
                <th>ID</th>
                <th>Number</th>
                <th>Owner id</th>
                <th>Delete</th>
            </tr>
            </thead>
            <tbody runat="server" id="tableBody" enableviewstate="false">                
            </tbody>
        </table>
        <label runat="server" id="elapsedTime"> </label>
        </div>   
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="InsertFieldsPlaceholder" runat="server">
    <h2 class="form-signin-heading">Phone fields</h2>
    <input type="number" class="form-control" placeholder="Id" autofocus="" runat="server" id="idInput"/>
    <input type="text" class="form-control" placeholder="Number" runat="server" id="numInput"/>
    <select class="form-control" id="personSelector" runat="server">        
    </select>
    <button class="btn btn-lg btn-primary btn-block" type="button" runat="server" onserverclick="InsertClick">Insert phone</button>
</asp:Content>
