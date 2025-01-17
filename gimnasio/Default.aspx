<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gimnasio.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <section class="text-center py-8 px-4 w-full">
        <h2 class="text-3xl md:text-4xl font-bold mb-4">El mejor gimnasio para ponerte en forma</h2>
        <img src="gimprincipal.jpg" alt="Gimnasio" class="w-full max-w-full md:max-w-4xl mx-auto rounded-lg shadow-lg">
            <div class="mt-6">
            <a href="Registro.aspx" class="bg-blue-500 text-white px-6 py-2 rounded hover:bg-blue-600 transition duration-300">Inscríbete</a>
        </div>
    </section>

    <!-- Ofertas con Carrusel -->
    <section class="my-8 text-center px-4 w-full">
        <h2 class="text-2xl md:text-3xl font-semibold mb-6">Ofertas</h2>
        <div class="relative carousel-container w-full">
            <button class="carousel-btn absolute left-0 top-1/2 transform -translate-y-1/2 bg-gray-800 text-white p-2 rounded-full" onclick="changeSlide(-1)">&#10094;</button>
            <button class="carousel-btn absolute right-0 top-1/2 transform -translate-y-1/2 bg-gray-800 text-white p-2 rounded-full" onclick="changeSlide(1)">&#10095;</button>

            <div class="carousel-slide w-full">
                <img src="jovenes.jpg" alt="Oferta Estudiantes" class="w-full rounded-lg">
              
                    <p class="mt-2 text-base md:text-lg font-medium">Descuento especial para estudiantes. ¡Inscríbete ya!</p>
            </div>
            <div class="carousel-slide w-full">
                <img src="anciano.jpg" alt="Oferta Jubilados" class="w-full rounded-lg">
                <p class="mt-2 text-base md:text-lg font-medium">Oferta especial para jubilados. ¡No te lo pierdas!</p>
            </div>
        </div>
    </section>

    <!-- Horario -->
    <section class="text-center my-8 px-4 w-full">
        <h2 class="text-2xl md:text-3xl font-semibold mb-4">Horario</h2>
        <div class="bg-white shadow-md p-4 md:p-6 rounded-lg mx-auto w-full max-w-md">
            <p class="text-base md:text-lg"><strong>Lunes - Viernes:</strong> 8:30 - 23:30</p>
            <p class="text-base md:text-lg"><strong>Sábados:</strong> 8:30 - 17:30</p>
            <p class="text-base md:text-lg"><strong>Domingos y festivos:</strong> 8:30 - 14:30</p>
        </div>
    </section>
</asp:Content>
