<%@ Page language="c#" Codebehind="activeusers.aspx.cs" AutoEventWireup="false" Inherits="yaf.activeusers" %>

<form runat=server>

<p class="navlinks">
	<asp:hyperlink runat="server" id="HomeLink"/>
	&#187; <asp:hyperlink runat="server" id="ThisLink"/>
</p>

<table class=content width=100% cellspacing=1 cellpadding=0>
<tr>
	<td class=header1 colspan=6><%= GetText("title") %></td>
</tr>
<tr>
	<td class=header2><%= GetText("username") %></td>
	<td class=header2><%= GetText("logged_in") %></td>
	<td class=header2><%= GetText("last_active") %></td>
	<td class=header2><%= GetText("active") %></td>
	<td class=header2><%= GetText("browser") %></td>
	<td class=header2><%= GetText("platform") %></td>
</tr>

<asp:repeater id=UserList runat=server>
<ItemTemplate>
<tr>
	<td class=post><%# DataBinder.Eval(Container.DataItem,"Name") %></td>
	<td class=post><%# FormatTime((DateTime)((System.Data.DataRowView)Container.DataItem)["Login"]) %></td>
	<td class=post><%# FormatTime((DateTime)((System.Data.DataRowView)Container.DataItem)["LastActive"]) %></td>
	<td class=post><%# String.Format(GetText("minutes"),((System.Data.DataRowView)Container.DataItem)["Active"]) %></td>
	<td class=post><%# DataBinder.Eval(Container.DataItem,"Browser") %></td>
	<td class=post><%# DataBinder.Eval(Container.DataItem,"Platform") %></td>
</tr>
</ItemTemplate>
</asp:repeater>

</table>

</form>
