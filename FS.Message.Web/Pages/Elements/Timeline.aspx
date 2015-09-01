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
                <form action="#" method="get" class="sidebar-form">
                    <div class="input-group">
                        <input type="text" name="q" class="form-control" placeholder="Search..." />
                        <span class="input-group-btn">
                            <button type='submit' name='seach' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
                        </span>
                    </div>
                </form>
                <ul class="sidebar-menu">
                    <li class="active">
                        <a href="/default.aspx">
                            <i class="fa fa-dashboard"></i><span>Dashboard</span>
                        </a>
                    </li>
                    <li>
                        <a href="pages/widgets.html">
                            <i class="fa fa-th"></i><span>Widgets</span> <small class="badge pull-right bg-green">new</small>
                        </a>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-bar-chart-o"></i>
                            <span>Charts</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="pages/charts/morris.html"><i class="fa fa-angle-double-right"></i>Morris</a></li>
                            <li><a href="pages/charts/flot.html"><i class="fa fa-angle-double-right"></i>Flot</a></li>
                            <li><a href="pages/charts/inline.html"><i class="fa fa-angle-double-right"></i>Inline charts</a></li>
                        </ul>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-laptop"></i>
                            <span>UI Elements</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="pages/UI/general.html"><i class="fa fa-angle-double-right"></i>General</a></li>
                            <li><a href="pages/UI/icons.html"><i class="fa fa-angle-double-right"></i>Icons</a></li>
                            <li><a href="pages/UI/buttons.html"><i class="fa fa-angle-double-right"></i>Buttons</a></li>
                            <li><a href="pages/UI/sliders.html"><i class="fa fa-angle-double-right"></i>Sliders</a></li>
                            <li><a href="pages/UI/timeline.html"><i class="fa fa-angle-double-right"></i>Timeline</a></li>
                        </ul>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-edit"></i><span>表单</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="/Pages/Forms/AgencyForm.aspx"><i class="fa fa-angle-double-right"></i>旅行社表单</a></li>
                            <li><a href="/Pages/Forms/TravelItemForm.aspx"><i class="fa fa-angle-double-right"></i>订单表单</a></li>
                            <li><a href="pages/forms/editors.html"><i class="fa fa-angle-double-right"></i>Editors</a></li>
                        </ul>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-table"></i><span>Tables</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="pages/tables/simple.html"><i class="fa fa-angle-double-right"></i>Simple tables</a></li>
                            <li><a href="pages/tables/data.html"><i class="fa fa-angle-double-right"></i>Data tables</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="pages/calendar.html">
                            <i class="fa fa-calendar"></i><span>Calendar</span>
                            <small class="badge pull-right bg-red">3</small>
                        </a>
                    </li>
                    <li>
                        <a href="pages/mailbox.html">
                            <i class="fa fa-envelope"></i><span>Mailbox</span>
                            <small class="badge pull-right bg-yellow">12</small>
                        </a>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-folder"></i><span>Examples</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="pages/examples/invoice.html"><i class="fa fa-angle-double-right"></i>Invoice</a></li>
                            <li><a href="pages/examples/login.html"><i class="fa fa-angle-double-right"></i>Login</a></li>
                            <li><a href="pages/examples/register.html"><i class="fa fa-angle-double-right"></i>Register</a></li>
                            <li><a href="pages/examples/lockscreen.html"><i class="fa fa-angle-double-right"></i>Lockscreen</a></li>
                            <li><a href="pages/examples/404.html"><i class="fa fa-angle-double-right"></i>404 Error</a></li>
                            <li><a href="pages/examples/500.html"><i class="fa fa-angle-double-right"></i>500 Error</a></li>
                            <li><a href="pages/examples/blank.html"><i class="fa fa-angle-double-right"></i>Blank Page</a></li>
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
                <h1>Order Timeline
                    <small>Preview</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Priview</a></li>
                    <li class="active">Timeline</li>
                </ol>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <ul class="timeline" data-bind="foreach: Level">
                            <li class="time-label">索引<span class="bg-red" data-bind="text: $index">
                            </span>
                            </li>
                        </ul>
                        <ul class="timeline">
                            <li class="time-label">
                                <span class="bg-red">10 Feb. 2014
                                </span>
                            </li>
                            <li>
                                <i class="fa fa-envelope bg-blue"></i>
                                <div class="timeline-item">
                                    <span class="time"><i class="fa fa-clock-o"></i>12:05</span>
                                    <h3 class="timeline-header"><a href="#">Support Team</a> sent you an email</h3>
                                    <div class="timeline-body">
                                        Etsy doostang zoodles disqus groupon greplin oooj voxy zoodles,
                      weebly ning heekya handango imeem plugg dopplr jibjab, movity
                      jajah plickers sifteo edmodo ifttt zimbra. Babblely odeo kaboodle
                      quora plaxo ideeli hulu weebly balihoo...
                                    </div>
                                    <div class="timeline-footer">
                                        <a class="btn btn-primary btn-xs">Read more</a>
                                        <a class="btn btn-danger btn-xs">Delete</a>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <i class="fa fa-user bg-aqua"></i>
                                <div class="timeline-item">
                                    <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                    <h3 class="timeline-header no-border"><a href="#">Sarah Young</a> accepted your friend request</h3>
                                </div>
                            </li>
                            <li>
                                <i class="fa fa-comments bg-yellow"></i>
                                <div class="timeline-item">
                                    <span class="time"><i class="fa fa-clock-o"></i>27 mins ago</span>
                                    <h3 class="timeline-header"><a href="#">Jay White</a> commented on your post</h3>
                                    <div class="timeline-body">
                                        Take me to your leader!
                      Switzerland is small and neutral!
                      We are more like Germany, ambitious and misunderstood!
                                    </div>
                                    <div class="timeline-footer">
                                        <a class="btn btn-warning btn-flat btn-xs">View comment</a>
                                    </div>
                                </div>
                            </li>
                            <li class="time-label">
                                <span class="bg-green">3 Jan. 2014
                                </span>
                            </li>
                            <li>
                                <i class="fa fa-camera bg-purple"></i>
                                <div class="timeline-item">
                                    <span class="time"><i class="fa fa-clock-o"></i>2 days ago</span>
                                    <h3 class="timeline-header"><a href="#">Mina Lee</a> uploaded new photos</h3>
                                    <div class="timeline-body">
                                        <img src="http://placehold.it/150x100" alt="..." class="margin">
                                        <img src="http://placehold.it/150x100" alt="..." class="margin">
                                        <img src="http://placehold.it/150x100" alt="..." class="margin">
                                        <img src="http://placehold.it/150x100" alt="..." class="margin">
                                    </div>
                                </div>
                            </li>
                            <li>
                                <i class="fa fa-video-camera bg-maroon"></i>
                                <div class="timeline-item">
                                    <span class="time"><i class="fa fa-clock-o"></i>5 days ago</span>
                                    <h3 class="timeline-header"><a href="#">Mr. Doe</a> shared a video</h3>
                                    <div class="timeline-body">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/tMWkeBIohBs" frameborder="0" allowfullscreen></iframe>
                                        </div>
                                    </div>
                                    <div class="timeline-footer">
                                        <a href="#" class="btn btn-xs bg-maroon">See comments</a>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <i class="fa fa-clock-o bg-gray"></i>
                            </li>
                        </ul>
                    </div>
                </div>
            </section>
        </aside>
    </div>
    <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <script src="../../js/AdminLTE/app.js" type="text/javascript"></script>
    <script src="/js/knockout-3.3.0.js" type="text/javascript"></script>
    <%--<script src="/js/knockout.simpleGrid.3.0.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        var Demo = function () {
            var self = this;
            self.Level = [10, 20, 30, 40, 50];
        }

        ko.applyBindings(new Demo());
    </script>
</asp:Content>
