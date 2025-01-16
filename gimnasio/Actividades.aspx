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


    <div class="container mx-auto p-6">
        <h1 class="text-4xl font-bold text-center mb-8">Calendario de Actividades</h1>

        <!-- Contenedor de mes y año -->
        <div class="flex items-center justify-between mb-6">
            <button id="prevMonth" class="bg-gray-300 px-4 py-2 rounded-lg">‹</button>
            <h2 id="monthYear" class="text-2xl font-semibold"></h2>
            <button id="nextMonth" class="bg-gray-300 px-4 py-2 rounded-lg">›</button>
        </div>

        <!-- Calendario -->
        <div id="calendar" class="bg-white shadow-md rounded-lg overflow-hidden">
            <!-- Aquí se generará el calendario dinámicamente -->
        </div>

        <!-- Modal para Reservar Actividad -->
        <div id="modal" class="fixed inset-0 bg-gray-800 bg-opacity-50 hidden justify-center items-center">
            <div class="bg-white p-6 rounded-lg">
                <h2 class="text-2xl font-bold mb-4" id="actividadNombre"></h2>
                <p id="actividadPrecio" class="mb-4"></p>
                <button id="btnReservar" class="bg-blue-500 text-white px-4 py-2 rounded">Reservar</button>
                <button id="btnCerrar" class="bg-gray-300 text-black px-4 py-2 rounded mt-2">Cerrar</button>
            </div>
        </div>


    </div>
    <!-- Footer -->
    <footer class="bg-blue-500 text-white text-center py-4">
        <p>&copy; 2025 Fit Gym. Todos los derechos reservados.</p>
    </footer>   

    <script>
        var currentDate = new Date();  // Fecha actual
        var currentMonth = currentDate.getMonth();  // Mes actual
        var currentYear = currentDate.getFullYear();  // Año actual

        $(document).ready(function () {
            cargarCalendario();  // Cargar calendario

            // Cargar actividades del día seleccionado
            $(document).on('click', '.dia', function () {
                var fecha = $(this).data('fecha');
                cargarActividades(fecha);
            });

            // Ver detalles de actividad
            $(document).on('click', '.actividad', function () {
                var actividadId = $(this).data('actividad-id');
                var actividadNombre = $(this).data('actividad-nombre');
                var actividadPrecio = $(this).data('actividad-precio');
                $('#actividadNombre').text(actividadNombre);
                $('#actividadPrecio').text("Precio: " + actividadPrecio + "€");
                $('#modal').removeClass('hidden');
                $('#btnReservar').data('actividad-id', actividadId);
            });

            // Reservar actividad
            $('#btnReservar').click(function () {
                var actividadId = $(this).data('actividad-id');
                var userId = 'usuario_ejemplo@dominio.com'; // Cambia esto por la ID del usuario logueado
                reservarActividad(actividadId, userId);
            });

            // Cerrar modal
            $('#btnCerrar').click(function () {
                $('#modal').addClass('hidden');
            });

            // Cambiar al mes anterior
            $('#prevMonth').click(function () {
                if (currentMonth === 0) {
                    currentMonth = 11;
                    currentYear--;
                } else {
                    currentMonth--;
                }
                cargarCalendario();
            });

            // Cambiar al mes siguiente
            $('#nextMonth').click(function () {
                if (currentMonth === 11) {
                    currentMonth = 0;
                    currentYear++;
                } else {
                    currentMonth++;
                }
                cargarCalendario();
            });
        });

        // Función para cargar el calendario
        function cargarCalendario() {
            // Determinar el primer y último día del mes
            var firstDayOfMonth = new Date(currentYear, currentMonth, 1);
            var lastDayOfMonth = new Date(currentYear, currentMonth + 1, 0);

            var calendarHtml = `
                <div class="grid grid-cols-7 bg-gray-200 text-center p-2">
                    <div class="font-bold">Dom</div>
                    <div class="font-bold">Lun</div>
                    <div class="font-bold">Mar</div>
                    <div class="font-bold">Mié</div>
                    <div class="font-bold">Jue</div>
                    <div class="font-bold">Vie</div>
                    <div class="font-bold">Sáb</div>
                </div>
            `;

            var currentDay = firstDayOfMonth.getDay();
            var daysInMonth = lastDayOfMonth.getDate();

            calendarHtml += '<div class="grid grid-cols-7 gap-2 p-4">';

            // Vacíos antes del primer día del mes
            for (var i = 0; i < currentDay; i++) {
                calendarHtml += '<div></div>';
            }

            // Los días del mes
            for (var i = 1; i <= daysInMonth; i++) {
                var date = new Date(currentYear, currentMonth, i);
                var dateString = date.toISOString().split('T')[0];
                calendarHtml += `<div class="dia p-4 text-center bg-white rounded-lg shadow hover:bg-blue-200 cursor-pointer" data-fecha="${dateString}">${i}</div>`;
            }

            calendarHtml += '</div>';

            // Mostrar mes y año actual
            var monthNames = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
            $('#monthYear').text(monthNames[currentMonth] + " " + currentYear);

            $('#calendar').html(calendarHtml);
        }

        // Función para cargar las actividades de un día
        function cargarActividades(fecha) {
            $.ajax({
                type: "POST",
                url: 'Calendario.aspx/GetActivities',
                data: JSON.stringify({ fecha: fecha }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var actividadesHtml = '';
                    if (data.length > 0) {
                        data.forEach(function (actividad) {
                            actividadesHtml += `<div class="actividad p-4 bg-blue-200 rounded-lg shadow mb-2 cursor-pointer" data-actividad-id="${actividad.Id}" data-actividad-nombre="${actividad.Nombre}" data-actividad-precio="${actividad.Precio}">${actividad.Nombre} - ${actividad.Precio}€</div>`;
                        });
                    } else {
                        actividadesHtml = '<p>No hay actividades disponibles para este día.</p>';
                    }
                    $('#calendar').html(actividadesHtml);
                }
            });
        }

        // Función para reservar una actividad
        function reservarActividad(actividadId, userId) {
            $.ajax({
                type: "POST",
                url: 'Calendario.aspx/ReserveActivity',
                data: JSON.stringify({ activityId: actividadId, userId: userId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.success) {
                        alert("Actividad reservada con éxito!");
                        $('#modal').addClass('hidden');
                    } else {
                        alert(data.message);
                    }
                }
            });
        }
    </script>

</body>
</html>
