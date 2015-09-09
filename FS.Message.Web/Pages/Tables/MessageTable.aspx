<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageTable.aspx.cs" Inherits="FS.Message.Web.Pages.Tables.MessageTable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <aside class="left-side sidebar-offcanvas">
                <section class="sidebar">
                    <!-- Sidebar user panel -->
                    <div class="user-panel">
                        <div class="pull-left image">
                            <img src="../../img/avatar3.png" class="img-circle" alt="User Image" />
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
                        <li>
                            <a href="../../index.html">
                                <i class="fa fa-dashboard"></i><span>仪表盘</span>
                            </a>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-th"></i><span>工具</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="../Widgets/CacheInfo.aspx"><i class="fa fa-angle-double-right"></i>缓存</a></li>
                            </ul>
                        </li>
                        <li class="treeview active">
                            <a href="#">
                                <i class="fa fa-table"></i><span>表格</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li class="active"><a href="MessageTable.aspx"><i class="fa fa-angle-double-right"></i>报文</a></li>
                            </ul>
                        </li>
                    </ul>
                </section>
            </aside>
            <aside class="right-side">
                <section class="content-header">
                    <h1>报文
                    <small>报文预览</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="/Default"><i class="fa fa-dashboard">主页</i></a></li>
                        <li><a href="#">表格</a></li>
                        <li class="active">报文</li>
                    </ol>
                </section>
                <section class="content">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box">
                                <div class="box-header">
                                    <h3 class="box-title">报文表格</h3>
                                </div>
                                <div class="box-header">
                                    <div class="row">
                                        <div class="col-sm-2">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-bullseye"></i>
                                                </div>
                                                <input id="ui_orderNoText" type="text" class="form-control input-sm" placeholder="定单号" />
                                            </div>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="input-group pull-right">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-truck"></i>
                                                </div>
                                                <input id="ui_logisticsNoText" type="text" class="form-control input-sm" placeholder="运单号" />
                                            </div>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="input-group pull-right">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <input id="ui_startText" type="text" class="form-control input-sm" placeholder="开始时间" data-inputmask="'alias': 'yyyy/mm/dd'" data-mask />
                                            </div>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <input id="ui_endText" type="text" class="form-control input-sm" placeholder="截止时间" data-inputmask="'alias': 'yyyy/mm/dd'" data-mask />
                                            </div>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="input-group">
                                                <select class="form-control input-sm" id="ui_isFinish">
                                                    <option>False</option>
                                                    <option>All</option>
                                                    <option>True</option>
                                                </select>
                                                <span class="input-group-addon"><a href="#" id="ui_searchBtn"><i class="fa fa-search"></i></a></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-body table-responsive no-padding">
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>订单号</th>
                                                <th>运单号</th>
                                                <th>进度</th>
                                                <th>完成</th>
                                                <th>操作</th>
                                            </tr>
                                        </thead>
                                        <tbody data-bind="foreach: messages">
                                            <tr>
                                                <td>
                                                    <span data-bind="text: $data.OrderNo"></span>
                                                </td>
                                                <td>
                                                    <span data-bind="text: $data.LogisticsNo"></span>
                                                </td>
                                                <td>
                                                    <span data-bind="text: $data.Schedule"></span>
                                                </td>
                                                <td>
                                                    <span data-bind="text: $data.IsFinished"></span>
                                                </td>
                                                <td>
                                                    <div class="btn btn-block btn-info" data-bind="click: $root.view">预览</div>
                                                </td>
                                            </tr>
                                        </tbody>
                                        <tfoot>
                                        </tfoot>
                                    </table>
                                </div>
                                <%--       <div class="box-footer clearfix">
                                <ul class="pagination pagination-sm no-margin pull-right">
                                    <li><a href="#">&laquo;</a></li>
                                    <li><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">&raquo;</a></li>
                                </ul>
                            </div>--%>
                            </div>
                        </div>
                    </div>
                </section>
            </aside>
        </div>
        <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
        <script src="/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="/js/plugins/input-mask/jquery.inputmask.js" type="text/javascript"></script>
        <script src="/js/plugins/input-mask/jquery.inputmask.date.extensions.js" type="text/javascript"></script>
        <script src="/js/plugins/input-mask/jquery.inputmask.extensions.js" type="text/javascript"></script>
        <script src="/js/AdminLTE/app.js" type="text/javascript"></script>
        <script src="/js/knockout-3.3.0.js" type="text/javascript"></script>
        <script src="/js/knockout.simpleGrid.3.0.js" type="text/javascript"></script>
        <script src="/js/Pages/Page.MessageTable.js" type="text/javascript"></script>
    </form>
</asp:Content>
