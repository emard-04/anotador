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
            // Obtener la cantidad de jugadores ingresada
            int numJugadores = int.Parse(txtNumJugadores.Text);

            // Validar que el número de jugadores sea válido
            if (numJugadores < 2 || numJugadores > 10)
            {
                // Mostrar un mensaje de error si la cantidad no es válida
                Response.Write("<script>alert('Por favor ingresa entre 2 y 10 jugadores.');</script>");
                return;
            }

            // Ocultar el paso 1 y mostrar el paso 2
            step1.Visible = false;
            step2.Visible = true;

            // Generar los controles para los nombres de los jugadores dinámicamente
            for (int i = 0; i < numJugadores; i++)
            {
                TextBox txtJugador = new TextBox();
                txtJugador.ID = "txtJugador" + (i + 1); // ID dinámico
                txtJugador.CssClass = "form-control mt-2";
                txtJugador.TextMode = TextBoxMode.SingleLine;
                txtJugador.Attributes.Add("placeholder", "Jugador " + (i + 1)); // Usar Attributes para el placeholder

                // Agregar el TextBox al PlaceHolder
                phJugadores.Controls.Add(txtJugador);
                phJugadores.Controls.Add(new LiteralControl("<br/>"));
            }
        }

        protected void btnGuardarNombres_Click(object sender, EventArgs e)
        {
            // Obtener la cantidad de jugadores
            int numJugadores = int.Parse(txtNumJugadores.Text);

            // Crear un arreglo para los nombres de los jugadores
            string[] nombresJugadores = new string[numJugadores];

            // Obtener los nombres de los controles generados dinámicamente
            for (int i = 0; i < numJugadores; i++)
            {
                TextBox txtJugador = (TextBox)phJugadores.FindControl("txtJugador" + (i + 1));
                if (txtJugador != null)
                {
                    nombresJugadores[i] = txtJugador.Text; // Guardar el nombre del jugador
                }
            }

            // Verificar si los nombres están siendo guardados correctamente
            foreach (string nombre in nombresJugadores)
            {
                Response.Write($"Nombre: {nombre}<br/>"); // Imprimir los nombres para depurar
            }

            // Guardar los nombres en la sesión
            Session["NombresJugadores"] = nombresJugadores;

            foreach (string nombre in nombresJugadores)
            {
                Response.Write($"Nombre: {nombre}<br/>"); // Depurar
            }

            // Redirigir al siguiente formulario
            Response.Redirect("AnotadorJuego.aspx");
        }

    }
}