<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="gimnasio.VerUsuarios" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.0.0/dist/tailwind.min.css" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet">
    <title></title>
</head>
<body class="bg-gray-100">
<!-- Menú -->
<header class="bg-blue-500 text-white p-4">
    <div class="container mx-auto flex flex-col md:flex-row justify-between items-center">
        <!-- Logo y botón Cobrar alineados a la izquierda -->
        <div class="flex items-center space-x-4">
            <h1 class="text-2xl md:text-3xl font-bold mb-2 md:mb-0">Fit Gym</h1>
            <button id="btnCobrar" class="bg-blue-500 text-white px-6 py-2 rounded-lg font-semibold transition-all duration-300 hover:bg-white hover:text-blue-500">
                Cobrar
            </button>
        </div>
        <!-- Menú de navegación -->
        <nav>
            <ul class="flex flex-col md:flex-row space-y-2 md:space-y-0 md:space-x-4">
                <li><a href="VerActividades.aspx" class="hover:text-gray-300">Actividades</a></li>
                <li><a href="VerUsuarios.aspx" class="hover:text-gray-300">Usuarios</a></li>
                <li><a href="Inicio.aspx" class="hover:text-gray-300">Cerrar Sesión</a></li>
            </ul>
        </nav>
    </div>
</header>
</body>
</html>
