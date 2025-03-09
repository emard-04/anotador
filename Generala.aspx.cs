using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Anotador
{
    public partial class Generala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el número de jugadores de la sesión
                int numJugadores = (int)Session["NumJugadores"];

                // Crear encabezados de la tabla para los jugadores
                TableHeaderRow headerRow = new TableHeaderRow();

                // Agregar la celda "NOMBRES" en el encabezado
                TableHeaderCell nombreHeaderCell = new TableHeaderCell();
                nombreHeaderCell.Text = "NOMBRES";
                headerRow.Cells.Add(nombreHeaderCell); // Agregar la celda "NOMBRES"

                // Agregar los TextBox vacíos para los nombres de los jugadores
                for (int i = 0; i < numJugadores; i++)
                {
                    TableHeaderCell playerHeaderCell = new TableHeaderCell();
                    TextBox playerTextBox = new TextBox();
                    playerTextBox.ID = "txtJugador_" + i;  // ID dinámico para cada jugador
                    playerTextBox.CssClass = "form-control";
                    playerHeaderCell.Controls.Add(playerTextBox);  // Agregar el TextBox a la celda
                    headerRow.Cells.Add(playerHeaderCell); // Agregar la celda con el TextBox al encabezado
                }

                tblGenerala.Rows.Add(headerRow); // Agregar la fila de encabezado

                // Categorías de puntaje
                string[] categorias = new string[]
                {
            "1", "2", "3", "4", "5", "6", "Escalera", "Full", "Póker", "Generala", "Doble Generala"
                };

                // Agregar filas con las categorías y celdas para puntajes
                foreach (var categoria in categorias)
                {
                    TableRow row = new TableRow();
                    TableCell categoryCell = new TableCell();
                    categoryCell.Text = categoria;
                    row.Cells.Add(categoryCell);

                    // Crear las celdas con TextBox para cada jugador
                    for (int j = 0; j < numJugadores; j++)
                    {
                        TableCell scoreCell = new TableCell();
                        TextBox scoreTextBox = new TextBox();
                        scoreTextBox.ID = "txtPuntaje_" + categoria + "_" + j;
                        scoreTextBox.CssClass = "form-control";
                        scoreCell.Controls.Add(scoreTextBox);
                        row.Cells.Add(scoreCell); // Agregar la celda con TextBox
                    }

                    // Agregar la fila con las celdas de puntajes a la tabla
                    tblGenerala.Rows.Add(row);
                }
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            // Obtener el número de jugadores de la sesión
            int numJugadores = (int)Session["NumJugadores"];
            string[] categorias = new string[] { "1", "2", "3", "4", "5", "6", "Escalera", "Full", "Póker", "Generala", "Doble Generala" };

            // Limpiar la lista de resultados
            resultadoLista.Controls.Clear();

            // Recorrer cada jugador
            for (int j = 0; j < numJugadores; j++)
            {
                int totalPuntaje = 0;
                string jugadorNombre = ((TextBox)tblGenerala.FindControl("txtJugador_" + j)).Text;

                // Recorrer cada categoría y sumar el puntaje
                foreach (var categoria in categorias)
                {
                    TextBox txtPuntaje = (TextBox)tblGenerala.FindControl("txtPuntaje_" + categoria + "_" + j);
                    if (txtPuntaje != null && !string.IsNullOrEmpty(txtPuntaje.Text))
                    {
                        int puntaje;
                        if (int.TryParse(txtPuntaje.Text, out puntaje))
                        {
                            totalPuntaje += puntaje; // Sumar el puntaje
                        }
                    }
                }

                // Crear un Literal para mostrar el resultado de este jugador
                Literal resultadoItem = new Literal();
                resultadoItem.Text = $"<li class='list-group-item'>{jugadorNombre} - Total: {totalPuntaje}</li>";

                // Añadir el resultado al ul (lista) en el HTML
                resultadoLista.Controls.Add(resultadoItem);
            }
        }




    }
}