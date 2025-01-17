<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" Inherits="gimnasio.Actividades" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Calendario de Actividades</title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.0.0/dist/tailwind.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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

    <!-- Contenedor principal -->
    <div class="container mx-auto mt-8 px-4">
        <form id="formRegistro" runat="server" class="bg-white p-6 rounded-lg shadow-md w-full">
            <h3 class="text-2xl font-bold mb-4">Actividades Impartidas</h3>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-red-500"></asp:Label>

            <asp:GridView 
                ID="gvActividadesImpartidas" 
                runat="server" 
                CssClass="w-full border border-gray-300 mt-4 text-left text-sm"
                HeaderStyle-CssClass="bg-blue-500 text-white text-left font-bold"
                RowStyle-CssClass="border-t border-gray-300"
                AlternatingRowStyle-CssClass="bg-gray-100"
                AutoGenerateColumns="False" 
                OnRowCommand="gvActividadesImpartidas_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdActividad" HeaderText="ID Actividad" />
                    <asp:BoundField DataField="CorreoMonitor" HeaderText="Correo Monitor" />
                    <asp:BoundField DataField="NombreActividad" HeaderText="Nombre Actividad" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button 
                                ID="btnInscribir" 
                                runat="server" 
                                CommandName="Inscribir" 
                                CommandArgument='<%# Eval("IdActividad") + "|" + Eval("CorreoMonitor") + "|" + Eval("Fecha", "{0:yyyy-MM-dd}") %>' 
                                Text="Inscribirse" 
                                CssClass="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-700"
                                OnClientClick="return confirm('¿Estás seguro de que deseas inscribirte a esta actividad?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </div>

</body>

</html>
