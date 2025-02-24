using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Anotador
{
    public partial class Truco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReiniciarPuntajes();
            }
        }

        protected void sum1_Click(object sender, EventArgs e)
        {
            if ((int)Session["puntosNos"] < 30 && (int)Session["puntosEll"] < 30)
            {
                Session["puntosNos"] = (int)Session["puntosNos"] + 1;
                VerificarGanador();
            }
        }

        protected void res1_Click(object sender, EventArgs e)
        {
            if ((int)Session["puntosNos"] > 0)
            {
                Session["puntosNos"] = (int)Session["puntosNos"] - 1;
                ActualizarPuntajes();
            }
        }

        protected void sum2_Click(object sender, EventArgs e)
        {
            if ((int)Session["puntosNos"] < 30 && (int)Session["puntosEll"] < 30)
            {
                Session["puntosEll"] = (int)Session["puntosEll"] + 1;
                VerificarGanador();
            }
        }

        protected void res2_Click(object sender, EventArgs e)
        {
            if ((int)Session["puntosEll"] > 0)
            {
                Session["puntosEll"] = (int)Session["puntosEll"] - 1;
                ActualizarPuntajes();
            }
        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciarPuntajes();
        }

        private void VerificarGanador()
        {
            if ((int)Session["puntosNos"] >= 30)
            {
                MostrarMensaje("¡Nosotros ganamos!");
            }
            else if ((int)Session["puntosEll"] >= 30)
            {
                MostrarMensaje("¡Ellos ganaron!");
            }

            ActualizarPuntajes();
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "Ganador", script, true);
            ReiniciarPuntajes();
        }

        private void ReiniciarPuntajes()
        {
            Session["puntosNos"] = 0;
            Session["puntosEll"] = 0;
            ActualizarPuntajes();
        }

        private void ActualizarPuntajes()
        {
            PuntosNos.Text = Session["puntosNos"].ToString();
            PuntosEll.Text = Session["puntosEll"].ToString();
        }

        protected void volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}