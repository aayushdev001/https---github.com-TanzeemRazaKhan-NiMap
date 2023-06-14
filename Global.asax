<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="System.Diagnostics" %>
<script RunAt="server">
    public static int Count = 0;
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        Application["myCount"] = Count;
        RouteTable.Routes.EnableFriendlyUrls();
        RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");   // 'Ignores any Resource cache references, used heavily in AJAX interactions.
        RouteTable.Routes.Ignore("{resource}.axd");
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }
    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
    }
    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session["init"] = 0; //For Unique SessionId
        Count = Convert.ToInt32(Application["myCount"]);
        Application["myCount"] = Count + 1;
        Session.Timeout = 50000;
    }
    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
</script>
