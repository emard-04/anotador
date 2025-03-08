<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnotadorJuego.aspx.cs" Inherits="Anotador.AnotadorJuego" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Anotador Juego</title>

    <!-- Bootstrap CDN -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center mt-5">
            <h2 class="mb-4">Anotador de Juego</h2>

            <!-- Tabla de jugadores -->
            <asp:Table ID="tblJugadores" runat="server" CssClass="table table-bordered table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Jugador</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Puntaje 1</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Puntaje 2</asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell>Resultado</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <!-- Botón de Sumar -->
            <br />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-success" />
        </div>
    </form>

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
