﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Tarifas.aspx.cs" Inherits="gimnasio.Tarifas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container mx-auto py-8">
    <h2 class="text-3xl font-bold text-center mb-6">Los mejores precios</h2>
        <div class="flex justify-center space-x-6">
             <!-- Card Estudiante -->
            <div class="border rounded-lg p-6 shadow-lg flex flex-col items-center">
                <h3 class="text-xl font-semibold mb-4">Estudiante</h3>
                <ul class="list-disc pl-5 text-left text-gray-700 mb-6">
                    <li>Acceso a las instalaciones</li>
                    <li>Acceso a vestuario</li>
                    <li>Taquilla</li>
                    <li>Clases dirigidas (pago extra)</li>
                </ul>
                <button class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 mt-4">Comprar</button>
            </div>

            <!-- Card Standard -->
            <div class="border rounded-lg p-6 shadow-lg flex flex-col items-center">
                <h3 class="text-xl font-semibold mb-4">Standard</h3>
                    <ul class="list-disc pl-5 text-left text-gray-700 mb-6">
                        <li>Acceso a las instalaciones</li>
                        <li>Acceso a vestuario</li>
                        <li>Taquilla</li>
                        <li>Clases dirigidas (pago extra)</li>
                   </ul>
                   <button class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 mt-4">Comprar</button>
            </div>

            <!-- Card Jubilados -->
            <div class="border rounded-lg p-6 shadow-lg flex flex-col items-center">
                 <h3 class="text-xl font-semibold mb-4">Jubilados</h3>
                     <ul class="list-disc pl-5 text-left text-gray-700 mb-6">
                        <li>Acceso a las instalaciones</li>
                        <li>Acceso a vestuario</li>
                        <li>Taquilla</li>
                        <li>Clases dirigidas (pago extra)</li>
                     </ul>
                     <button class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 mt-4">Comprar</button>
            </div>
    </div>
</div>
</asp:Content>
