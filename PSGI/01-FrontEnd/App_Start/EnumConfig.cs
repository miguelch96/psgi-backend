using Common;
using System.IO;
using System.Web;

namespace FrontEnd.App_Start
{
    public class EnumConfig
    {
        public static void Start()
        {
            var currentPath = HttpContext.Current.Server.MapPath("~/assets/js/enums.js");
            var enums = Enums.GetAllEnumsWithChilds();
            var variable = "var Enums = { {childs} };";
            var childs = "";

            foreach (var e in enums)
            {
                childs += e.Name + ": {";

                foreach (var c in e.Childs)
                {
                    childs += c.Name + ": {";

                    childs += $"name: '{c.Name}',";
                    childs += $"description: '{c.Description}',";
                    childs += $"value: {c.Value}";

                    childs += "},";
                }

                childs += "},";
            }

            variable = variable.Replace("{childs}", childs);

            using (var sw = new StreamWriter(currentPath))
            {
                sw.Write(variable);
            }
        }
    }
}