<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="gimnasio.Registro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w-full min-h-screen flex flex-col items-center justify-center bg-gray-100">
        <div class="bg-white shadow-lg rounded-lg p-8 w-full max-w-md">
            <h2 class="text-2xl font-bold text-center mb-6">Registro</h2>
            <form id="formRegistro" runat="server">
                <!-- Campo de Correo -->
                <div class="mb-4">
                    <label for="email" class="block text-gray-700 font-bold mb-2">Correo electrónico:</label>
                    <asp:TextBox 
                        ID="email" 
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                    <asp:Label 
                        ID="errorCorreo" 
                        runat="server" 
                        CssClass="text-red-500 text-sm" />
                </div>
                <!-- Campo de Nombre -->
                <div class="mb-4">
                    <label for="nombre" class="block text-gray-700 font-bold mb-2">Nombre:</label>
                    <asp:TextBox 
                        ID="nombre" 
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>
                <!-- Campo de Apellidos -->
                <div class="mb-4">
                    <label for="apellidos" class="block text-gray-700 font-bold mb-2">Apellidos:</label>
                    <asp:TextBox 
                        ID="apellidos" 
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>
                <!-- Campo de dni -->
                <div class="mb-4">
                    <label for="DNI" class="block text-gray-700 font-bold mb-2">DNI:</label>
                    <asp:TextBox 
                        ID="DNI" 
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>
                <!-- Selección de Tarifa -->
                <div class="mb-4">
                    <label for="tarifa" class="block text-gray-700 font-bold mb-2">Selecciona tu tarifa:</label>
                    <asp:DropDownList 
                        ID="tarifa" 
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500">
                        <asp:ListItem Text="Selecciona una opción" Value="" />
                        <asp:ListItem Text="Estudiante" Value="Estudiante" />
                        <asp:ListItem Text="Jubilado" Value="Jubilado" />
                        <asp:ListItem Text="Standard" Value="Standard" />
                    </asp:DropDownList>
                </div>
                <!-- Campo de password -->
                <div class="mb-4">
                    <label for="contrasena" class="block text-gray-700 font-bold mb-2">Contraseña:</label>
                    <asp:TextBox 
                        ID="contrasena" TextMode="Password"
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>
                <!-- Botón de Registro -->
                <div class="text-center">
                    <asp:Button 
                        ID="btnRegistrar" 
                        runat="server" 
                        Text="Registrarse" 
                        OnClick="btnRegistrar_Click" 
                        CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
