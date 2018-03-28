Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        'AppDomain.CurrentDomain.SetData("DataDirectory", Server.MapPath("~/App_Data/"))
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class