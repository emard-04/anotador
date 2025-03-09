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
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["NumJugadores"] != null)
            {
                int numJugadores = (int)Session["NumJugadores"];

                for (int i = 0; i < numJugadores; i++)
                {
                    TableRow row = new TableRow();

                    // Celda para el nombre del jugador
                    TableCell cell1 = new TableCell();
                    TextBox txtNombre = new TextBox
                    {
                        ID = "txtNombre_" + i,
                        CssClass = "form-control"
                    };
                    txtNombre.Attributes.Add("placeholder", "Nombre del jugador " + (i + 1));
                    cell1.Controls.Add(txtNombre);
                    row.Cells.Add(cell1);

                    // Celda para Puntaje 1
                    TableCell cell2 = new TableCell();
                    TextBox txtPuntaje1 = new TextBox { ID = "txtPuntaje1_" + i, CssClass = "form-control" };
                    cell2.Controls.Add(txtPuntaje1);
                    row.Cells.Add(cell2);

                    // Celda para Puntaje 2
                    TableCell cell3 = new TableCell();
                    TextBox txtPuntaje2 = new TextBox { ID = "txtPuntaje2_" + i, CssClass = "form-control" };
                    cell3.Controls.Add(txtPuntaje2);
                    row.Cells.Add(cell3);

                    // Celda para Botón Calcular
                    TableCell cell4 = new TableCell();
                    Button btnCalcular = new Button
                    {
                        Text = "Calcular",
                        CommandArgument = i.ToString(),
                        CssClass = "btn btn-primary"
                    };
                    btnCalcular.Click += btnCalcular_Click; // Asegurar que el evento se asigne en cada postback
                    cell4.Controls.Add(btnCalcular);
                    row.Cells.Add(cell4);

                    // Celda para Resultado
                    TableCell cell5 = new TableCell();
                    TextBox txtResultado = new TextBox { ID = "txtResultado_" + i, CssClass = "form-control", ReadOnly = true };
                    cell5.Controls.Add(txtResultado);
                    row.Cells.Add(cell5);

                    // Agregar la fila a la tabla
                    tblJugadores.Rows.Add(row);
                }
            }
            else
            {
                Response.Redirect("AnotadorNormal.aspx");
            }
        }

        // Evento de calcular puntaje por jugador
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int jugadorIndex = int.Parse(btn.CommandArgument);

            // Buscar los controles en la tabla
            TextBox txtPuntaje1 = (TextBox)tblJugadores.FindControl("txtPuntaje1_" + jugadorIndex);
            TextBox txtPuntaje2 = (TextBox)tblJugadores.FindControl("txtPuntaje2_" + jugadorIndex);
            TextBox txtResultado = (TextBox)tblJugadores.FindControl("txtResultado_" + jugadorIndex);

            if (txtPuntaje1 != null && txtPuntaje2 != null && txtResultado != null)
            {
                try
                {
                    int puntaje1 = int.Parse(txtPuntaje1.Text);
                    int puntaje2 = int.Parse(txtPuntaje2.Text);
                    int resultado = puntaje1 + puntaje2;

                    txtResultado.Text = resultado.ToString(); // Mostrar el resultado
                }
                catch (FormatException)
                {
                    Response.Write("<script>alert('Por favor ingresa puntajes válidos.');</script>");
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnotadorNormal.aspx");
        }
    }
}