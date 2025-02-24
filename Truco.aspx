<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Truco.aspx.cs" Inherits="Anotador.Truco" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Anotador de Truco</title>

    <!-- Bootstrap CDN -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>

    <style>
        body {
            background-color: #f8f9fa;
        }
        .container {
            max-width: 600px;
            margin-top: 50px;
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        .score {
            font-size: 24px;
            font-weight: bold;
        }
        .btn-custom {
            width: 100px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container text-center">
            <h2 class="mb-4">Anotador de Truco</h2>

            <div class="row mb-3">
                <div class="col">
                    <h4>Nosotros</h4>
                    <span class="score text-primary">
                        <asp:Label ID="PuntosNos" runat="server" Text="0"></asp:Label>
                    </span>
                </div>
                <div class="col">
                    <h4>Ellos</h4>
                    <span class="score text-danger">
                        <asp:Label ID="PuntosEll" runat="server" Text="0"></asp:Label>
                    </span>
                </div>
            </div>

            <div class="row mb-2">
                <div class="col">
                    <asp:Button ID="sum1" runat="server" CssClass="btn btn-success btn-custom" Text="+1" OnClick="sum1_Click" />
                    <asp:Button ID="res1" runat="server" CssClass="btn btn-danger btn-custom mt-2" Text="-1" OnClick="res1_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="sum2" runat="server" CssClass="btn btn-success btn-custom" Text="+1" OnClick="sum2_Click" />
                    <asp:Button ID="res2" runat="server" CssClass="btn btn-danger btn-custom mt-2" Text="-1" OnClick="res2_Click" />
                </div>
            </div>

            <!-- Aquí es donde he actualizado los botones "Reiniciar" y "Volver" -->
            <asp:Button 
                ID="btnReiniciar" 
                runat="server" 
                CssClass="btn btn-secondary mt-3 w-100" 
                Text="Reiniciar" 
                OnClick="btnReiniciar_Click" />

            <asp:Button 
                ID="volver" 
                runat="server" 
                CssClass="btn btn-secondary mt-3 w-100" 
                OnClick="volver_Click" 
                Text="Volver" />
        </div>
    </form>

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>