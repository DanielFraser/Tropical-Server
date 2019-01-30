<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="TropicalServer.Orders" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="AppThemes/TropicalStyles/Orders.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CriteriaBar">
        <label class="label">Order Date</label>
        <asp:DropDownList ID="dateDL" runat="server" CssClass="Criteria" AutoPostBack="true" OnSelectedIndexChanged="dateDLChange">
            <asp:ListItem Text="Today" Value="0"></asp:ListItem>
            <asp:ListItem Text="Last 7 Days" Value="7"></asp:ListItem>
            <asp:ListItem Text="Last 1 Month" Value="1"></asp:ListItem>
            <asp:ListItem Text="Last 6 Months" Value="6"></asp:ListItem>
            <asp:ListItem Text="Beginning of time" Value="-1"></asp:ListItem>
        </asp:DropDownList>
        <label class="label">Customer ID</label>
        <asp:TextBox AutoPostBack="true" ID="custid" runat="server" CssClass="Criteria" OnTextChanged="custIDChange"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="custIDAC" runat="server"
            TargetControlID="custid" ServiceMethod="GetCustIDs" CompletionSetCount="10"
            MinimumPrefixLength="0">
        </ajaxToolkit:AutoCompleteExtender>
        <label class="label">Customer Name</label>
        <asp:TextBox AutoPostBack="true" ID="custname" runat="server" CssClass="Criteria" OnTextChanged="custNameChange"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
            TargetControlID="custname" ServiceMethod="GetCustNames" CompletionSetCount="10"
            MinimumPrefixLength="0">
        </ajaxToolkit:AutoCompleteExtender>
        <label class="label">Sales Manager</label>
        <asp:DropDownList ID="manager" runat="server" CssClass="Criteria" AutoPostBack="true" OnTextChanged="manNameDLChange">
            <asp:ListItem Text="" Value=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="grid">
        <asp:GridView CssClass="ordersgrid" AutoGenerateColumns="False" OnRowCommand="orderItem_RowCommand"
            ID="ordersgrid" runat="server" OnPageIndexChanging="ordgrid_PageIndexChanging" AllowPaging="True" PageSize="25">
            <Columns>
                <asp:BoundField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="OrderID" HeaderText="OrderID"></asp:BoundField>
                <asp:BoundField DataField="OrderTrackingNumber" HeaderText="Tracking #"></asp:BoundField>
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date"></asp:BoundField>
                <asp:BoundField DataField="CustID" HeaderText="Customer ID"></asp:BoundField>
                <asp:BoundField DataField="CustName" HeaderText="Customer Name"></asp:BoundField>
                <asp:BoundField DataField="CustBillingAddress1" HeaderText="Address"></asp:BoundField>
                <asp:BoundField DataField="OrderRouteNumber" HeaderText="Route #"></asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CssClass="rowLB" ID="viewRow" runat="server" Text="View" />
                        <asp:LinkButton CssClass="rowLB" ID="editRow" runat="server" Text="Edit"
                            CommandName="EditRow" CommandArgument='<%# Eval("OrderID") %>' />
                        <asp:LinkButton CssClass="rowLB" ID="delRow" runat="server" Text="Delete"
                            OnClientClick="return confirm('Do you want to delete this row?');"
                            OnClick="DelOrder" CommandArgument='<%# Eval("OrderID") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("OrderID") %>' CommandName="UpdateRow"
                            runat="server">Update</asp:LinkButton>
                        <asp:LinkButton ID="lbCancel" CommandArgument='<%# Eval("OrderID") %>' CommandName="CancelUpdate"
                            runat="server" CausesValidation="false">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle CssClass="chartAlternatingItemStyle" />
            <RowStyle CssClass="chartItemStyle" />
            <HeaderStyle CssClass="gvOrders" />
        </asp:GridView>
    </div>
</asp:Content>
