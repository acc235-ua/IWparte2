<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerActividades.aspx.cs" Inherits="gimnasio.VerActividades" %>

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
    <div class="container mx-auto py-8">
        <h2 class="text-3xl font-bold text-center mb-6">Registrar Actividad Impartida</h2>
        <form id="formRegistro" runat="server" class="max-w-lg mx-auto bg-white p-6 rounded-lg shadow-md">
            <!-- Campo Id_Actividad -->
            <div class="mb-4">
                <label for="Id_Actividad" class="block text-gray-700 font-semibold mb-2">Actividad</label>
                <asp:DropDownList ID="ddlIdActividad" runat="server" CssClass="w-full px-3 py-2 border rounded-lg">
                </asp:DropDownList>
            </div>

            <!-- Campo Correo_Monitor -->
            <div class="mb-4">
                <label for="Correo_Monitor" class="block text-gray-700 font-semibold mb-2">Correo del Monitor</label>
                <asp:DropDownList ID="ddlCorreoMonitor" runat="server" CssClass="w-full px-3 py-2 border rounded-lg">
                </asp:DropDownList>
            </div>

            <!-- Campo Fecha -->
            <div class="mb-4">
                <label for="Fecha" class="block text-gray-700 font-semibold mb-2">Fecha</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="w-full px-3 py-2 border rounded-lg" placeholder="Formato: YYYY-MM-DD"></asp:TextBox>
            </div>

            <!-- Campo Hora_Inicio -->
            <div class="mb-4">
                <label for="Hora_Inicio" class="block text-gray-700 font-semibold mb-2">Hora de Inicio</label>
                <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="w-full px-3 py-2 border rounded-lg" placeholder="Formato: HH:MM"></asp:TextBox>
            </div>

            <!-- Campo Hora_Fin -->
            <div class="mb-4">
                <label for="Hora_Fin" class="block text-gray-700 font-semibold mb-2">Hora de Fin</label>
                <asp:TextBox ID="txtHoraFin" runat="server" CssClass="w-full px-3 py-2 border rounded-lg" placeholder="Formato: HH:MM"></asp:TextBox>
            </div>

            <!-- Campo Huecos -->
            <div class="mb-4">
                <label for="Huecos" class="block text-gray-700 font-semibold mb-2">Huecos</label>
                <asp:TextBox ID="txtHuecos" runat="server" CssClass="w-full px-3 py-2 border rounded-lg"></asp:TextBox>
            </div>

            <!-- Campo Precio -->
            <div class="mb-4">
                <label for="Precio" class="block text-gray-700 font-semibold mb-2">Precio (€)</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="w-full px-3 py-2 border rounded-lg"></asp:TextBox>
            </div>

            <!-- Botón de Registro -->
            <div class="text-center">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Actividad" CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600" OnClick="btnRegistrar_Click" />
            </div>
            <asp:HiddenField ID="hiddenIdActividad" runat="server" />
<asp:HiddenField ID="hiddenCorreoMonitor" runat="server" />
<asp:HiddenField ID="hiddenFecha" runat="server" />

            <h3 class="text-2xl font-bold mb-4">Actividades Impartidas</h3>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-red-500"></asp:Label>

           <asp:GridView ID="gvActividadesImpartidas" runat="server" CssClass="table-auto w-full border-collapse border border-gray-300 mt-4" AutoGenerateColumns="False" OnRowCommand="gvActividadesImpartidas_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdActividad" HeaderText="ID Actividad" />
        <asp:BoundField DataField="NombreActividad" HeaderText="Nombre Actividad" />
        <asp:BoundField DataField="CorreoMonitor" HeaderText="Correo Monitor" />
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" 
                    CommandArgument='<%# Eval("IdActividad") + "|" + Eval("CorreoMonitor") + "|" + Eval("Fecha", "{0:yyyy-MM-dd}") %>' 
                    Text="Editar" CssClass="btn btn-primary" />
                <asp:Button ID="btnBorrar" runat="server" CommandName="Borrar" 
                    CommandArgument='<%# Eval("IdActividad") + "|" + Eval("CorreoMonitor") + "|" + Eval("Fecha", "{0:yyyy-MM-dd}") %>' 
                    Text="Borrar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta actividad?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


        </form>
    </div>
    
</body>
</html>
