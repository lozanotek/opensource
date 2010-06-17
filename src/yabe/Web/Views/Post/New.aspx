<%@ import namespace="Domain" %>

<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <div>
        <form method="post" action='<%=Url.Action("new") %>'>
        <fieldset>
            <legend>Create New Post</legend>
            <table>
                <tr>
                    <td>
                        <label for="title">
                            Title:</label>
                    </td>
                    <td>
                        <%=Html.TextBox("title", 80)%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="abstract">
                            Contents:</label>
                    </td>
                    <td>
                        <%=Html.TextArea("contents", "",4,79,new{})%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="abstract">
                            Category:</label>
                    </td>
                    <td>
                        <%
                            var categories = ViewData["categories"] as Category[];
                            MultiSelectList list = new MultiSelectList(categories, "Name", "Name");
                        %>
                        <%=Html.ListBox("categoryList", list) %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="button-row">
                            <input type="submit" id="Create" value="Create Post" />
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
</asp:content>
