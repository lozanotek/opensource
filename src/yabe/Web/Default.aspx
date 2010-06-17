<%@ page language="C#" autoeventwireup="true" inherits="System.Web.UI.Page" %>

<%-- Please do not delete this file. It is used to ensure that ASP.NET MVC is activated by IIS when a user makes a "/" request to the server. --%>

<script runat="server" language="c#">
    public void Page_Load(object sender, System.EventArgs e)
    {
        HttpContext.Current.RewritePath(Request.ApplicationPath);
        IHttpHandler httpHandler = new MvcHttpHandler();
        httpHandler.ProcessRequest(HttpContext.Current);
    }
</script>

