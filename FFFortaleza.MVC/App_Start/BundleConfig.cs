using System.Web.Optimization;

namespace CrdFortes.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.jquery.validate.custom.pt-br.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/assets/vendor/modernizr/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/cssTemplate").Include(
                      "~/Content/assets/vendor/bootstrap/css/bootstrap.css",
                      "~/Content/assets/vendor/bootstrap-datepicker/css/datepicker3.css",
                      "~/Content/assets/stylesheets/theme.css"));

            bundles.Add(new StyleBundle("~/Content/FontAwesome").Include(
                      "~/Content/font-awesome.css"));




             bundles.Add(new ScriptBundle("~/bundles/templatejs").Include(
                        "~/Scripts/jquery-{version}.js",
                      "~/Content/assets/vendor/nanoscroller/nanoscroller.js",
                      "~/Content/assets/vendor/jquery-placeholder/jquery.placeholder.js",
                      "~/Content/assets/javascripts/theme.js",
                      "~/Content/assets/javascripts/theme.init.js",
                      "~/Content/assets/javascripts/jquery.mask.min.js"));

             bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                         "~/Scripts/knockout-3.3.0.js",
                       "~/Scripts/knockout.mapping-latest.js",
                       "~/Scripts/moment.min.js",
                       "~/Scripts/moment-with-locales.js"));

             bundles.Add(new ScriptBundle("~/knockout/receitas").Include(
                          "~/ScriptsKO/receitas.js"));

             bundles.Add(new ScriptBundle("~/knockout/relatorio").Include(
                           "~/ScriptsKO/relatorio.js"));


        }
    }
}
