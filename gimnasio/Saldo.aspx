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
</body>
</html>
