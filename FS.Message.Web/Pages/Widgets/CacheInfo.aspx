<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CacheInfo.aspx.cs" Inherits="FS.Message.Web.Pages.Widgets.CacheInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <aside class="left-side sidebar-offcanvas">
            <section class="sidebar">
                <div class="user-panel">
                    <div class="pull-left image">
                        <img src="img/avatar3.png" class="img-circle" alt="User Image" />
                    </div>
                    <div class="pull-left info">
                        <p>Hello, Jane</p>
                        <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
                    </div>
                </div>
                <div class="input-group">
                    <input type="text" name="q" class="form-control" placeholder="Search..." />
                    <span class="input-group-btn">
                        <button type='submit' name='seach' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
                    </span>
                </div>
                <ul class="sidebar-menu">
                    <li class="active">
                        <a href="/default.aspx">
                            <i class="fa fa-dashboard"></i><span>仪表盘</span>
                        </a>
                    </li>
                    <li class="treeview active">
                        <a href="#">
                            <i class="fa fa-th"></i><span>工具</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="CacheInfo.aspx"><i class="fa fa-angle-double-right"></i>缓存</a></li>
                        </ul>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-table"></i><span>表格</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="/Pages/Tables/MessageTable.aspx"><i class="fa fa-angle-double-right"></i>报文</a></li>
                        </ul>
                    </li>
                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>
        <aside class="right-side">
            <section class="content-header">
                <h1>报文缓存
                    <small>预览</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default"><i class="fa fa-dashboard"></i>主页</a></li>
                    <li><a href="#">工具</a></li>
                    <li class="active">缓存</li>
                </ol>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-header">
                                <h3 class="box-title">缓存表</h3>
                                <%--<div class="box-tools">
                                    <div class="input-group" style="width: 150px;">
                                        <input type="text" name="table_search" class="form-control input-sm pull-right" placeholder="Search">
                                        <div class="input-group-btn">
                                            <button class="btn btn-sm btn-default"><i class="fa fa-search"></i></button>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="box-body table-responsive no-padding">
                                <table class="table table-hover">
                                    <tr>
                                        <th>缓存</th>
                                        <th>数量</th>
                                    </tr>
                                    <tr>
                                        <td>601报文缓存</td>
                                        <td><span data-bind="text: cache601"></span></td>
                                    </tr>
                                    <tr>
                                        <td>文件缓存</td>
                                        <td><span data-bind="text: cacheQueue"></span></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </aside>
    </div>
    <script type="text/javascript">
        var PageInfo = <% =a_result %>;
    </script>
    <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="/js/AdminLTE/app.js" type="text/javascript"></script>
    <script src="/js/knockout-3.3.0.js" type="text/javascript"></script>
    <script src="/js/knockout.simpleGrid.3.0.js" type="text/javascript"></script>
    <script src="/js/Pages/Page.CacheInfo.js" type="text/javascript"></script>
</asp:Content>
