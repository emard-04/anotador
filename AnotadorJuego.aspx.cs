using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Anotador
{
    public partial class AnotadorJuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar los nombres de los jugadores desde la sesión
                string[] nombresJugadores = (string[])Session["NombresJugadores"];

                if (nombresJugadores != null)
                {
                    // Mostrar los nombres de los jugadores en el control lblJugadores
                    for (int i = 0; i < nombresJugadores.Length; i++)
                    {
                        lblJugadores.InnerHtml += $"Jugador {i + 1}: {nombresJugadores[i]}<br/>";
                    }
                }
                else
                {
                    // Si no hay nombres, redirigir al inicio
                    Response.Redirect("Inicio.aspx");
                }

            }
        }
    }
}