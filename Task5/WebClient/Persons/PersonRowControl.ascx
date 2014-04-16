<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonRowControl.ascx.cs" Inherits="WebClient.PersonRowControl" EnableViewState="false" %>
<tr>
    <td> <%= this.Item.Id %> </td>
    <td> <%= this.Item.Name %> </td>
    <td> <%= this.Item.LastName %> </td>
    <td> <%= this.Item.DayOfBirth.ToString("d MMM yyyy") %></td>
    <td>
        <button type="submit" value="<%= this.Item.Id %>" name="delete" class="btn btn-xs btn-danger">Delete</button>
    </td>
    <td>
        <a href="/PhoneList?ownerId=<%= this.Item.Id %>" class="btn btn-xs btn-outline" role="button">Phones</a>
    </td>
</tr>