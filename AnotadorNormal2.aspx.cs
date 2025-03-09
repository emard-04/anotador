using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Anotador
{
    public partial class AnotadorNormal2 : System.Web.UI.Page
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

            // Crear un array para los nombres de los jugadores
            string[] nombresJugadores = new string[numJugadores];
            for (int i = 0; i < numJugadores; i++)
            {
                nombresJugadores[i] = "Jugador " + (i + 1);  // O el nombre que se ingrese
            }

            // Guardar los nombres de los jugadores en la sesión
            Session["NombresJugadores"] = nombresJugadores;

            // Redirigir a Generala.aspx
            Response.Redirect("Generala.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

    }
}