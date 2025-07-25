﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnotadorNormal2.aspx.cs" Inherits="Anotador.AnotadorNormal2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Anotador Normal</title>

    <!-- Bootstrap CDN -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>

    <style>
        body {
            background-color: #f8f9fa;
        }
        .container {
            max-width: 500px;
            margin-top: 50px;
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            text-align: center;
        }
        .btn-custom {
            width: 100%;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            <h2 class="mb-4">Anotador 2</h2>

            <!-- Paso 1: Ingresar número de jugadores -->
            <div id="step1" runat="server">
                <label for="txtNumJugadores" class="form-label">Número de jugadores:</label>
                <asp:TextBox ID="txtNumJugadores" runat="server" CssClass="form-control" TextMode="Number" Min="2" Max="10"></asp:TextBox>
                <asp:Button ID="btnContinuar" runat="server" CssClass="btn btn-primary btn-custom mt-3" Text="Continuar" OnClick="btnContinuar_Click"/>
            </div>
            <table class="w-100">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>