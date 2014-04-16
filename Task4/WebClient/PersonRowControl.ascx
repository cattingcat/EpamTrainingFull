<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonRowControl.ascx.cs" Inherits="WebClient.PersonRowControl" EnableViewState="false" %>
<tr>
    <td> <%= this.Item.ID %> </td>
    <td> <%= this.Item.Name %> </td>
    <td> <%= this.Item.LastName %> </td>
    <td> <%= this.Item.DayOfBirth.ToString() %></td>
    <td>
        <button type="submit" value="<%= this.Item.ID %>" name="delete" class="btn btn-xs btn-danger">Delete</button>
    </td>
</tr>