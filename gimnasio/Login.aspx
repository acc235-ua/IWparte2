<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="gimnasio.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w-full min-h-screen flex flex-col items-center justify-center bg-gray-100">
        <div class="bg-white shadow-lg rounded-lg p-8 w-full max-w-md">
            <h2 class="text-2xl font-bold text-center mb-6">Login</h2>
            <form id="formLogin" runat="server">
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
                <!-- Campo de Contraseña -->
                <div class="mb-4">
                    <label for="contrasena" class="block text-gray-700 font-bold mb-2">Contraseña:</label>
                    <asp:TextBox 
                        ID="contrasena" TextMode="Password"
                        runat="server" 
                        CssClass="w-full border rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                    <asp:Label 
                        ID="errorContrasena" 
                        runat="server" 
                        CssClass="text-red-500 text-sm" />
                </div>
                <!-- Botón de Login -->
                <div class="text-center">
                    <asp:Button 
                        ID="btnLogin" 
                        runat="server" 
                        Text="Iniciar sesión" 
                        OnClick="btnLogin_Click" 
                        CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>

