<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div>
        <%foreach( var p in this.ViewData["persons"] as IEnumerable<DataAccessors.Entity.Person>){ %>
        <%=p.ToString() %>
        <form action="/Person/Delete/<%=p.Id %>" method="post">
            <button type="submit"> Delete </button>
        </form>
        
        <br />
        <%} %>
    </div>
</body>
</html>
