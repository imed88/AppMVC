using System.Web;
using System.Web.Optimization;

namespace WebApplication4
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/Js").Include(
                    "~/Content/plugins/jQuery/jquery-2.2.3.min.js",
                    "~/Content/bootstrap/js/bootstrap.min.js",
                    "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                    "~/Content/plugins/fastclick/fastclick.js",
                    "~/Content/dist/js/app.min.js",
            "~/Content/dist/js/demo.js"));
            bundles.Add(new StyleBundle("~/Css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css"
                     /* "~/Content/site.css"*/));

            BundleTable.EnableOptimizations = true;
        }
    }
}
