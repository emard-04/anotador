<<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generala.aspx.cs" Inherits="Anotador.Generala" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Generala - Anotador</title>

    <!-- Bootstrap CDN -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>

    <style>
        body {
            background-color: #f8f9fa;
        }
        .container {
            max-width: 800px;
            margin-top: 50px;
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            text-align: center;
        }
        table {
            width: 100%;
        }
        .btn-custom {
            width: 100%;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            <h2 class="mb-4">Generala - Anotador</h2>

            <asp:Table ID="tblGenerala" runat="server" class="table table-bordered">
              
            </asp:Table>

           
            <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btn btn-primary btn-custom mt-3" OnClick="btnCalcular_Click" />

           
            <div id="resultadoContainer" class="mt-3">
                <h4>Resultado Final:</h4>
                
                <ul id="resultadoLista" runat="server" class="list-group">
                </ul>
            </div>
        </div>
    </form>

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>

</html>
