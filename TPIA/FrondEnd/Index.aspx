﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrondEnd/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TPIA.FrondEnd.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://unpkg.com/masonry-layout@4.0/dist/masonry.pkgd.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#_container').imagesLoaded(function () {
                $('#_container').masonry({
                    itemSelector: '.content_box',
                    columnWidth: 364,
                    singleMode: false,
                    animate: true
                });
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="_container" style="width: 800px; overflow: hidden; margin: 0 auto;">
        <h2>最新消息</h2>
        <asp:GridView ID="GridView1" runat="server" Style="width: 800px; overflow: hidden; margin: 0 auto;" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>   
    </div>
</asp:Content>
