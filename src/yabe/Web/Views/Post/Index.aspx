<%@ import namespace="Domain" %>

<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <%
        Post[] posts = ViewData["posts"] as Post[];

        if (posts != null && posts.Count() > 0)
        { 
    %>
        <% foreach (var post in posts)
        {
        %>
        <div>
            <h3>
                <%= post.Title  %></h3>
            <span>
                <%=post.PostedDate %>
                -- Comments [<%=post.Comments.Count%>]</span>
            <hr />
            <div>
                <%=post.Contents %>
            </div>
            <br />
            <span>Categories:
                <%foreach (var category in post.Categories)
                  {
                %>
                <strong>
                    <%=category.Name %></strong>&nbsp;&nbsp;
                <% } %>
            </span>
        </div>
        <% } %>
    <% } %>
</asp:content>
