<%@ import namespace="Domain" %>

<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <p>
        <%=Html.ActionLink("Create New Category","new")%></p>
    <%
        Category[] categories = ViewData["categories"] as Category[];

        if (categories != null && categories.Count() > 0)
        { 
    %>
    <% foreach (var category in categories)
       {
    %>
    <div>
        <h3>
            <%= category.Name  %></h3>
        <span>
            <%=category.Description %></span>
        <hr />
    </div>
    <% } %>
    <% } %>
</asp:content>
