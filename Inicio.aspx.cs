using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Anotador
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnotadorNormal_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnotadorNormal.aspx"); // Asegúrate de tener esta página creada
        }

        protected void btnAnotadorTruco_Click(object sender, EventArgs e)
        {
            Response.Redirect("Truco.aspx"); // Redirige al anotador del Truco
        }
    }
}