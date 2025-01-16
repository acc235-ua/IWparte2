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
    <div class="container mx-auto p-4">
        <h1 class="text-3xl font-semibold text-center mb-6">Gestión de Usuarios</h1>
        <!-- Formulario para crear y editar usuarios -->
        <h2 class="text-xl mb-4">Editar Usuario</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-red-600"></asp:Label>
        <form id="formRegistro" runat="server" class="max-w-lg mx-auto bg-white p-6 rounded-lg shadow-md">

        <div class="bg-white p-6 rounded shadow-md">
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-input mb-4" Placeholder="Correo Electrónico" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-input mb-4" Placeholder="Nombre" />
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-input mb-4" Placeholder="Apellidos" />
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-input mb-4" Placeholder="DNI" />
            <asp:CheckBox ID="chkEsAdmin" runat="server" Text="Admin" class="mb-4" />
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-input mb-4" Placeholder="Contraseña" TextMode="Password" />
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar Usuario" OnClick="btnGuardar_Click" />
        </div>
        <br />
        <asp:Label ID="Mensaje" runat="server" CssClass="text-red-500"></asp:Label>

        <!-- GridView para mostrar los usuarios -->
        <asp:GridView ID="gvUsuarios" runat="server" CssClass="table-auto w-full border-collapse border border-gray-300 mt-4"
              AutoGenerateColumns="False" OnRowCommand="gvUsuarios_RowCommand">
    <Columns>
        <asp:BoundField DataField="Correo_electronico" HeaderText="Correo Electrónico" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" 
                            CommandArgument='<%# Eval("Correo_electronico") %>' 
                            Text="Editar" CssClass="btn btn-primary" />
                <asp:Button ID="btnBorrar" runat="server" CommandName="Borrar" 
                            CommandArgument='<%# Eval("Correo_electronico") %>' 
                            Text="Borrar" CssClass="btn btn-danger"
                            OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este usuario?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</form>

    </div>
</body>
</html>
