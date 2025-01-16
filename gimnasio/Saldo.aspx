<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Saldo.aspx.cs" Inherits="gimnasio.Saldo" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.0.0/dist/tailwind.min.css" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet">
</head>
<body class="bg-gray-100">
    <!-- Menú -->
    <header class="bg-blue-500 text-white p-4">
        <div class="container mx-auto flex flex-col md:flex-row justify-between items-center">
            <h1 class="text-2xl md:text-3xl font-bold mb-2 md:mb-0">Fit Gym</h1>
            <nav>
                <ul class="flex flex-col md:flex-row space-y-2 md:space-y-0 md:space-x-4">
                    <li><a href="Actividades.aspx" class="hover:text-gray-300">Actividades</a></li>
                    <li><a href="Saldo.aspx" class="hover:text-gray-300">Saldo</a></li>
                    <li><a href="Inicio.aspx" class="hover:text-gray-300">Cerrar Sesión</a></li>
                </ul>
            </nav>
        </div>
    </header>

    <!-- Contenido -->
    <main class="flex flex-col items-center justify-center min-h-screen bg-gray-100">
    <!-- Mostrar saldo -->
    <div class="bg-white p-6 rounded shadow-md w-96 text-center">
        <h2 class="text-xl font-semibold mb-4">Tu Saldo</h2>
        <asp:Label ID="lblSaldo" runat="server" CssClass="text-lg font-medium text-gray-700"></asp:Label>
    </div>

    <!-- Formulario de recarga -->
    <div class="bg-white p-6 rounded shadow-md w-96 mt-6">
        <h2 class="text-xl font-semibold mb-4 text-center">Recargar Saldo</h2>
        <asp:Label ID="lblRecargaMensaje" runat="server" CssClass="text-red-500 font-medium text-center block"></asp:Label>
        <form id="formRecarga" runat="server" class="space-y-4">
            <div>
                <label for="txtImporte" class="block text-gray-700 font-medium">Importe (€):</label>
                <asp:TextBox ID="txtImporte" runat="server" CssClass="mt-1 block w-full rounded border-gray-300 shadow-sm"></asp:TextBox>
            </div>
            <div>
                <label for="txtTarjeta" class="block text-gray-700 font-medium">Número de Tarjeta:</label>
                <asp:TextBox ID="txtTarjeta" runat="server" CssClass="mt-1 block w-full rounded border-gray-300 shadow-sm"></asp:TextBox>
            </div>
            <div>
                <label for="txtFechaCaducidad" class="block text-gray-700 font-medium">Fecha de Caducidad (MM/AA):</label>
                <asp:TextBox ID="txtFechaCaducidad" runat="server" CssClass="mt-1 block w-full rounded border-gray-300 shadow-sm"></asp:TextBox>
            </div>
            <div>
                <label for="txtCVV" class="block text-gray-700 font-medium">CVV:</label>
                <asp:TextBox ID="txtCVV" runat="server" CssClass="mt-1 block w-full rounded border-gray-300 shadow-sm"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnRecargar" runat="server" Text="Recargar" CssClass="bg-blue-500 text-white px-4 py-2 rounded shadow-md hover:bg-blue-600 w-full" OnClick="btnRecargar_Click" />
            </div>
        </form>
    </div>
</main>
 <!-- Footer -->
    <footer class="bg-blue-500 text-white text-center py-4">
        <p>&copy; 2025 Fit Gym. Todos los derechos reservados.</p>
    </footer>
</body>

</html>
