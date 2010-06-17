<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <div>
        <form method="post" action='<%=Url.Action("create")%>'>
        <fieldset>
            <legend>Create New Category</legend>
            <table>
                <tr>
                    <td>
                        <label for="title">
                            Name:</label>
                    </td>
                    <td>
                        <%=Html.TextBox("name") %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="abstract">
                            Description:</label>
                    </td>
                    <td>
                        <%=Html.TextArea("description", "",4,79,new{})%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="button-row">
                            <input type="submit" id="Create" value="Create Category" />
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
        </form>
    </div>
</asp:content>
