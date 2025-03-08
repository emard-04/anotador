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
            // Verificar si ya existen nombres de jugadores en la sesión
            if (Session["NombresJugadores"] != null)
            {
                // Obtener los nombres de los jugadores desde la sesión
                string[] nombresJugadores = (string[])Session["NombresJugadores"];

                // Agregar una fila para cada jugador
                for (int i = 0; i < nombresJugadores.Length; i++)
                {
                    string jugador = nombresJugadores[i];

                    TableRow row = new TableRow();

                    // Celda para el nombre del jugador
                    TableCell cell1 = new TableCell();
                    Label lblJugador = new Label();
                    lblJugador.Text = jugador; // Nombre del jugador
                    cell1.Controls.Add(lblJugador);
                    row.Cells.Add(cell1);

                    // Celda para el Puntaje 1
                    TableCell cell2 = new TableCell();
                    TextBox txtPuntaje1 = new TextBox();
                    txtPuntaje1.ID = "txtPuntaje1_" + i; // Usamos el índice como parte del ID para hacerlo único
                    txtPuntaje1.CssClass = "form-control"; // Agregar clase de Bootstrap
                    cell2.Controls.Add(txtPuntaje1);
                    row.Cells.Add(cell2);

                    // Celda para el Puntaje 2
                    TableCell cell3 = new TableCell();
                    TextBox txtPuntaje2 = new TextBox();
                    txtPuntaje2.ID = "txtPuntaje2_" + i; // Usamos el índice como parte del ID para hacerlo único
                    txtPuntaje2.CssClass = "form-control"; // Agregar clase de Bootstrap
                    cell3.Controls.Add(txtPuntaje2);
                    row.Cells.Add(cell3);


                    // Celda para el botón de calcular
                    TableCell cell4 = new TableCell();
                    Button btnCalcular = new Button();
                    btnCalcular.Text = "Calcular";
                    btnCalcular.CommandArgument = i.ToString(); // Usamos el índice como argumento para identificar al jugador
                    btnCalcular.CssClass = "btn btn-primary";
                    btnCalcular.Click += btnCalcular_Click;
                    cell4.Controls.Add(btnCalcular);
                    row.Cells.Add(cell4);

                    // Celda para el Resultado
                    TableCell cell5= new TableCell();
                    TextBox txtResultado = new TextBox();
                    txtResultado.ID = "txtResultado_" + i; // Usamos el índice como parte del ID para hacerlo único
                    txtResultado.CssClass = "form-control";
                    txtResultado.ReadOnly = true; // Solo lectura
                    cell5.Controls.Add(txtResultado);
                    row.Cells.Add(cell5);

                    // Agregar la fila a la tabla
                    tblJugadores.Rows.Add(row);
                }
            }
            else
            {
                // Si no hay jugadores en la sesión, redirigir al formulario de entrada de jugadores
                Response.Redirect("AnotadorNormal.aspx");
            }
        }

        // Evento de calcular puntaje por jugador
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int jugadorIndex = int.Parse(btn.CommandArgument); // Obtener el índice del jugador desde CommandArgument

            // Obtener los TextBox correspondientes a Puntaje 1, Puntaje 2 y Resultado
            TextBox txtPuntaje1 = (TextBox)tblJugadores.FindControl("txtPuntaje1_" + jugadorIndex);
            TextBox txtPuntaje2 = (TextBox)tblJugadores.FindControl("txtPuntaje2_" + jugadorIndex);
            TextBox txtResultado = (TextBox)tblJugadores.FindControl("txtResultado_" + jugadorIndex);

            try
            {
                // Sumar los puntajes
                int puntaje1 = int.Parse(txtPuntaje1.Text);
                int puntaje2 = int.Parse(txtPuntaje2.Text);
                int resultado = puntaje1 + puntaje2;

                // Mostrar el resultado en el TextBox de Resultado
                txtResultado.Text = resultado.ToString();
            }
            catch (FormatException)
            {
                // Si no son números válidos, mostrar mensaje de error
                Response.Write("<script>alert('Por favor ingresa puntajes válidos.');</script>");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnotadorNormal.aspx");
        }
    }
}