<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="FS.Message.Web.Pages.Elements.Timeline" %>

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
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-th"></i><span>工具</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="../Widgets/CacheInfo.aspx"><i class="fa fa-angle-double-right"></i>缓存</a></li>
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

        <!-- Right side column. Contains the navbar and content of the page -->
        <aside class="right-side">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>定单时间轴
                    <small>预览</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default"><i class="fa fa-dashboard"></i>主页</a></li>
                    <li><a href="#">预览</a></li>
                    <li class="active">时间轴</li>
                </ol>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <ul class="timeline">
                            <li class="time-label">
                                <span class="bg-red">301
                                </span>
                            </li>
                            <li data-bind="foreach: Entry301s">
                                <i class="fa fa-paperclip bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time" data-bind="text: $data.CreateTime"><i class="fa fa-clock-o"></i></span>
                                    <h3 class="timeline-header"><a href="#">订单号: </a><span data-bind="text: item.OrderNo"></span></h3>
                                    <div class="timeline-body" data-bind="text: $data.FilePath">
                                    </div>
                                </div>
                            </li>
                            <li class="time-label">
                                <span class="bg-fuchsia">302
                                </span>
                            </li>
                            <li data-bind="foreach: Entry302s">
                                <i class="fa fa-paperclip bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time" data-bind="text: $data.ReturnTime"><i class="fa fa-clock-o"></i></span>
                                    <h3 class="timeline-header"><a href="#">状态: </a><span data-bind="text: $data.Status"></span></h3>
                                    <div class="timeline-body" data-bind="text: $data.FilePath">
                                    </div>
                                    <div class="timeline-body" data-bind="text: $data.ReturnInfo">
                                    </div>
                                </div>
                                <%--                                <div class="timeline-footer">
                                        <a class="btn btn-primary btn-xs">Read more</a>
                                        <a class="btn btn-danger btn-xs">Delete</a>
                                    </div>--%>
                            </li>
                            <li class="time-label">
                                <span class="bg-gray">501
                                </span>
                            </li>
                            <li data-bind="foreach: Entry501s">
                                <i class="fa fa-paperclip bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time" data-bind="text: $data.CreateTime"><i class="fa fa-clock-o"></i></span>
                                    <div class="timeline-body" data-bind="text: $data.FilePath">
                                    </div>
                                </div>
                            </li>
                            <li class="time-label">
                                <span class="bg-light-blue">502
                                </span>
                            </li>
                            <li data-bind="foreach: Entry502s">
                                <i class="fa fa-paperclip bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time" data-bind="text: $data.ReturnTime"><i class="fa fa-clock-o"></i></span>
                                    <h3 class="timeline-header"><a href="#">状态: </a><span data-bind="text: $data.Status"></span></h3>
                                    <div class="timeline-body" data-bind="text: $data.FilePath">
                                    </div>
                                    <div class="timeline-body" data-bind="text: $data.ReturnInfo">
                                    </div>
                                </div>
                                <%--                                <div class="timeline-footer">
                                        <a class="btn btn-primary btn-xs">Read more</a>
                                        <a class="btn btn-danger btn-xs">Delete</a>
                                    </div>--%>
                            </li>
                            <li class="time-label">
                                <span class="bg-yellow">601
                                </span>
                            </li>
                            <li data-bind="foreach: Entry601s">
                                <i class="fa fa-paperclip bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time" data-bind="text: $data.CreateTime"><i class="fa fa-clock-o"></i></span>
                                    <div class="timeline-body" data-bind="text: $data.FilePath">
                                    </div>
                                </div>
                            </li>
                            <li class="time-label">
                                <span class="bg-green">602
                                </span>
                            </li>
                            <li data-bind="foreach: Entry602s">
                                <i class="fa fa-paperclip bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time" data-bind="text: $data.ReturnTime"><i class="fa fa-clock-o"></i></span>
                                    <h3 class="timeline-header"><a href="#">状态: </a><span data-bind="text: $data.Status"></span></h3>
                                    <div class="timeline-body" data-bind="text: $data.FilePath">
                                    </div>
                                    <div class="timeline-body" data-bind="text: $data.ReturnInfo">
                                    </div>
                                </div>
                                <%--                                <div class="timeline-footer">
                                        <a class="btn btn-primary btn-xs">Read more</a>
                                        <a class="btn btn-danger btn-xs">Delete</a>
                                    </div>--%>
                            </li>
                        </ul>
                    </div>
                </div>
            </section>
        </aside>
    </div>
    <script type="text/javascript">
        var item = <% =a_result %>;
    </script>
    <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="/js/AdminLTE/app.js" type="text/javascript"></script>
    <script src="/js/knockout-3.3.0.js" type="text/javascript"></script>
    <script src="/js/knockout.simpleGrid.3.0.js" type="text/javascript"></script>
    <script src="/js/Pages/Page.Timeline.js" type="text/javascript"></script>
</asp:Content>
