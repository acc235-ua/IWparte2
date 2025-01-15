let currentSlide = 0;
const slides = document.querySelectorAll('.carousel-slide');

function showSlide(index) {
    slides.forEach(slide => slide.style.display = 'none');
    slides[index].style.display = 'block';
}

function changeSlide(direction) {
    currentSlide += direction;
    if (currentSlide >= slides.length) currentSlide = 0;
    if (currentSlide < 0) currentSlide = slides.length - 1;
    showSlide(currentSlide);
}

// Inicializar carrusel
showSlide(currentSlide);

function togglePricing(plan) {
    const prices = {
        monthly: { student: '€19,99', standard: '€24,99', senior: '€21,99' },
        annual: { student: '€199,99', standard: '€249,99', senior: '€219,99' }
    };

    document.getElementById('price-student').innerText = prices[plan].student;
    document.getElementById('price-standard').innerText = prices[plan].standard;
    document.getElementById('price-senior').innerText = prices[plan].senior;

    document.querySelectorAll('.toggle-btn').forEach(btn => btn.classList.remove('active'));
    document.querySelector(`.toggle-btn[onclick*="${plan}"]`).classList.add('active');
}
