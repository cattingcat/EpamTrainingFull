<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div>
        <% foreach(var p in ViewData["phones"] as IEnumerable<DataAccessors.Entity.Phone>){ %>
        <%= p.ToString() %>
        <form action="/Phone/Delete/<%=p.Id %>" method="post">
            <button type="submit"> Delete </button>
        </form>
        <%} %>
        
    </div>
</body>
</html>
