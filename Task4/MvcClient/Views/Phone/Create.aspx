<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
</head>
<body>
    <div>
        <form method="post">
            <input type="text" name="id" />
            <input type="text" name="num" />
            <input type="text" name="owner" />
            <button type="submit"> Submit </button> 
        </form>
    </div>
</body>
</html>
