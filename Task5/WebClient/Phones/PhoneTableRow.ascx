<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoneTableRow.ascx.cs" Inherits="WebClient.Phones.PhoneTableRow" %>

<tr>
    <td> <%= this.Item.Id %> </td>
    <td> <%= this.Item.Number %> </td>
    <td> <%= this.Item.PersonId %></td>
    <td>
        <button type="submit" value="<%= this.Item.Id %>" name="delete" class="btn btn-xs btn-danger">Delete</button>
    </td>
</tr>