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
                CargarJugadores();
            }
        }

        private void CargarJugadores()
        {
            string[] nombresJugadores = (string[])Session["NombresJugadores"];

            if (nombresJugadores == null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            // Crear encabezados de la tabla
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell { Text = "Jugador", CssClass = "fw-bold" });
            headerRow.Cells.Add(new TableCell { Text = "Puntaje 1", CssClass = "fw-bold" });
            headerRow.Cells.Add(new TableCell { Text = "Puntaje 2", CssClass = "fw-bold" });
            headerRow.Cells.Add(new TableCell { Text = "Suma Manual", CssClass = "fw-bold" });
            headerRow.Cells.Add(new TableCell { Text = "Total", CssClass = "fw-bold" });
            headerRow.Cells.Add(new TableCell { Text = "Acción", CssClass = "fw-bold" });

            tblJugadores.Rows.Add(headerRow);

            // Agregar jugadores a la tabla
            for (int i = 0; i < nombresJugadores.Length; i++)
            {
                TableRow row = new TableRow();

                // Nombre del jugador
                row.Cells.Add(new TableCell { Text = nombresJugadores[i] });

                // Caja de texto para puntaje 1
                TextBox txtPuntaje1 = new TextBox { ID = $"txtPuntaje1_{i}", CssClass = "form-control", TextMode = TextBoxMode.Number };
                row.Cells.Add(new TableCell { Controls = { txtPuntaje1 } });

                // Caja de texto para puntaje 2
                TextBox txtPuntaje2 = new TextBox { ID = $"txtPuntaje2_{i}", CssClass = "form-control", TextMode = TextBoxMode.Number };
                row.Cells.Add(new TableCell { Controls = { txtPuntaje2 } });

                // Caja de texto para suma manual
                TextBox txtSumaManual = new TextBox { ID = $"txtSumaManual_{i}", CssClass = "form-control", TextMode = TextBoxMode.Number };
                row.Cells.Add(new TableCell { Controls = { txtSumaManual } });

                // Label para mostrar total
                Label lblTotal = new Label { ID = $"lblTotal_{i}", CssClass = "fw-bold text-primary" };
                row.Cells.Add(new TableCell { Controls = { lblTotal } });

                // Botón para calcular el puntaje individualmente
                Button btnCalcular = new Button
                {
                    ID = $"btnCalcular_{i}",
                    Text = "Calcular",
                    CssClass = "btn btn-success"
                };
                btnCalcular.Click += CalcularPuntaje;
                row.Cells.Add(new TableCell { Controls = { btnCalcular } });

                tblJugadores.Rows.Add(row);
            }
        }

        protected void CalcularPuntaje(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.ID.Split('_')[1]);

            TextBox txtPuntaje1 = (TextBox)tblJugadores.Rows[index + 1].Cells[1].Controls[0];
            TextBox txtPuntaje2 = (TextBox)tblJugadores.Rows[index + 1].Cells[2].Controls[0];
            TextBox txtSumaManual = (TextBox)tblJugadores.Rows[index + 1].Cells[3].Controls[0];
            Label lblTotal = (Label)tblJugadores.Rows[index + 1].Cells[4].Controls[0];

            int puntaje1 = string.IsNullOrEmpty(txtPuntaje1.Text) ? 0 : int.Parse(txtPuntaje1.Text);
            int puntaje2 = string.IsNullOrEmpty(txtPuntaje2.Text) ? 0 : int.Parse(txtPuntaje2.Text);
            int sumaManual = string.IsNullOrEmpty(txtSumaManual.Text) ? 0 : int.Parse(txtSumaManual.Text);

            lblTotal.Text = (puntaje1 + puntaje2 + sumaManual).ToString();
        }
    }
}