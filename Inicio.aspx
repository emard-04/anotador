<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Anotador.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Inicio - Anotadores</title>

    <!-- Bootstrap CDN -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>

    <style>
        body {
            background-color: #f8f9fa;
        }
        .container {
            max-width: 500px;
            margin-top: 100px;
            background: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            text-align: center;
        }
        .btn-custom {
            width: 100%;
            padding: 15px;
            font-size: 18px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            <h2 class="mb-4">Selecciona un anotador</h2>
            
            <asp:Button ID="btnAnotadorNormal" runat="server" CssClass="btn btn-primary btn-custom mb-3" 
                Text="Anotador Normal" OnClick="btnAnotadorNormal_Click" />

            <asp:Button ID="btnAnotadorTruco" runat="server" CssClass="btn btn-success btn-custom" 
                Text="Anotador de Truco" OnClick="btnAnotadorTruco_Click" />
        </div>
    </form>

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
