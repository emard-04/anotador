using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Anotador
{
    public partial class AnotadorNormal : System.Web.UI.Page
    {
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            int numJugadores;
            if (!int.TryParse(txtNumJugadores.Text, out numJugadores) || numJugadores < 2 || numJugadores > 10)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor ingresa un número válido de jugadores (entre 2 y 10).');", true);
                return;
            }

            // Guardar el número de jugadores en la sesión
            Session["NumJugadores"] = numJugadores;

            // Redirigir a AnotadorJuego.aspx
            Response.Redirect("AnotadorJuego.aspx");
        }



    }
}