<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TropicalServer.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="AppThemes/TropicalStyles/Products.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="productCategories">
        <label class="productCategoriesLabel">Product Categories</label>
        <br />
        <br />
        <br />
        <asp:Repeater ID="categoryRpt" runat="server">
           <%-- <a href="Products.aspx"></a>--%>
            <ItemTemplate>
                <tr class="chartItemStyle">
                    <asp:Button CssClass="catbtn" runat="server" Text='<%# Eval("ItemTypeDescription") %>'
                        OnClick="changeCat" />
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="chartdisplay">
        <asp:GridView CssClass="grid" AutoGenerateColumns="False" ID="productsgrid" runat="server" OnPageIndexChanging="prodgrid_PageIndexChanging" AllowPaging="True" PageSize="5">
            <Columns>
                <asp:BoundField DataField="ItemNumber" HeaderText="Item #"></asp:BoundField>
                <asp:BoundField DataField="ItemDescription" HeaderText="Item Description"></asp:BoundField>
                <asp:BoundField DataField="PrePrice" HeaderText="Pre-price"></asp:BoundField>
                <asp:BoundField DataField="Size" HeaderText="Size"></asp:BoundField>
            </Columns>
            <AlternatingRowStyle CssClass="chartAlternatingItemStyle" />
            <RowStyle CssClass="chartItemStyle" />
            <HeaderStyle CssClass="chartHeaderStyle" />
        </asp:GridView>
        <%--<asp:Repeater ID="productsTbl" runat="server">
            <HeaderTemplate>
                <table style="width: 100%">
                    <tr>
                        <th class="chartHeaderStyle" scope="col" style="width: 10%">Item #
                        </th>
                        <th class="chartHeaderStyle" scope="col" style="width: 50%">Item Description
                        </th>
                        <th class="chartHeaderStyle" scope="col" style="width: 10%">Pre-Price
                        </th>
                        <th class="chartHeaderStyle" scope="col" style="width: 100%">Size
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="chartItemStyle">
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("ItemNumber") %>' />
                    </td>

                    <td>
                        <asp:Label runat="server" Text='<%# Eval("ItemDescription") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("PrePrice") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("Size") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="chartAlternatingItemStyle">
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("ItemNumber") %>' />
                    </td>

                    <td>
                        <asp:Label runat="server" Text='<%# Eval("ItemDescription") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("PrePrice") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("Size") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>--%>
    </div>

</asp:Content>
