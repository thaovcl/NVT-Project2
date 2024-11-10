// Lấy các phần tử
const hotelForm = document.getElementById('hotelForm');
const flightForm = document.getElementById('flightForm');
const busForm = document.getElementById('busForm');
const airportTransferForm = document.getElementById('airportTransferForm');
const carrentalForm = document.getElementById('carrentalForm');
const activityForm = document.getElementById('activityForm');
const otherForm = document.getElementById('otherForm');

const hotelButton = document.getElementById('hotelButton');
const flightButton = document.getElementById('flightButton');
const busButton = document.getElementById('busButton');
const airportTransferButton = document.getElementById('airportTransferButton');
const carrentalButton = document.getElementById('carrentalButton');
const activityButton = document.getElementById('activityButton');
const otherButton = document.getElementById('otherButton');

// Đảm bảo form Khách sạn luôn hiển thị và nút luôn active
document.addEventListener("DOMContentLoaded", function () {
    hotelForm.style.display = "block";
    hotelButton.classList.add("active");
});

// Sự kiện cho nút Khách sạn
hotelButton.addEventListener('click', function() {
    hotelForm.style.display = 'block'; // Hiện form khách sạn
    flightForm.style.display = 'none'; // Ẩn form vé máy bay
    busForm.style.display = 'none'; // Ẩn form vé xe khách
    airportTransferForm.style.display = 'none'; // Ẩn form đưa đón sân bay
    carrentalForm.style.display = 'none'; // Ẩn form cho thuê xe
    activityForm.style.display = 'none'; // Ẩn form hoạt động
    otherForm.style.display = 'none'; // Ẩn form khác
    hotelButton.classList.add('active'); // Thêm lớp active
    flightButton.classList.remove('active'); // Xóa lớp active
    busButton.classList.remove('active'); 
    airportTransferButton.classList.remove('active'); 
    carrentalButton.classList.remove('active');
    activityButton.classList.remove('active'); 
    otherButton.classList.remove('active'); 
});

// Sự kiện cho nút Vé máy bay
flightButton.addEventListener('click', function() {
    flightForm.style.display = 'block'; 
    hotelForm.style.display = 'none'; 
    busForm.style.display = 'none';
    airportTransferForm.style.display = 'none';
    carrentalForm.style.display = 'none'; 
    activityForm.style.display = 'none'; 
    otherForm.style.display = 'none'; 
    flightButton.classList.add('active'); 
    hotelButton.classList.remove('active'); 
    busButton.classList.remove('active');
    airportTransferButton.classList.remove('active'); 
    carrentalButton.classList.remove('active');
    activityButton.classList.remove('active'); 
    otherButton.classList.remove('active'); 
});

// Sự kiện cho nút Vé xe khách
busButton.addEventListener('click', function(){
    busForm.style.display = 'block';
    hotelForm.style.display = 'none';
    flightForm.style.display = 'none';
    airportTransferForm.style.display = 'none';
    carrentalForm.style.display = 'none'; 
    activityForm.style.display = 'none'; 
    otherForm.style.display = 'none'; 
    busButton.classList.add('active');
    flightButton.classList.remove('active'); 
    hotelButton.classList.remove('active');
    airportTransferButton.classList.remove('active'); 
    carrentalButton.classList.remove('active');
    activityButton.classList.remove('active'); 
    otherButton.classList.remove('active'); 
});

// Sự kiện cho nút Đưa đón sân bay
airportTransferButton.addEventListener('click', function() {
    airportTransferForm.style.display = 'block'; 
    hotelForm.style.display = 'none'; 
    flightForm.style.display = 'none'; 
    busForm.style.display = 'none'; 
    carrentalForm.style.display = 'none';
    activityForm.style.display = 'none'; 
    otherForm.style.display = 'none'; 
    airportTransferButton.classList.add('active'); 
    hotelButton.classList.remove('active'); 
    flightButton.classList.remove('active'); 
    busButton.classList.remove('active'); 
    carrentalButton.classList.remove('active');
    activityButton.classList.remove('active'); 
    otherButton.classList.remove('active'); 
});

// Sự kiện cho nút cho thuê xe
carrentalButton.addEventListener('click', function(){
    carrentalForm.style.display = 'block';
    hotelForm.style.display = 'none'; 
    flightForm.style.display = 'none'; 
    busForm.style.display = 'none'; 
    airportTransferForm.style.display = 'none';
    activityForm.style.display = 'none'; 
    otherForm.style.display = 'none'; 
    carrentalButton.classList.add('active');
    hotelButton.classList.remove('active'); 
    flightButton.classList.remove('active'); 
    busButton.classList.remove('active');
    airportTransferButton.classList.remove('active'); 
    activityButton.classList.remove('active'); 
    otherButton.classList.remove('active'); 
});

// Sự kiện cho nút Hoạt động & vui chơi
activityButton.addEventListener('click', function() {
    activityForm.style.display = 'block'; 
    hotelForm.style.display = 'none'; 
    flightForm.style.display = 'none'; 
    busForm.style.display = 'none'; 
    airportTransferForm.style.display = 'none';
    carrentalForm.style.display = 'none'; 
    otherForm.style.display = 'none'; 
    activityButton.classList.add('active'); 
    hotelButton.classList.remove('active'); 
    flightButton.classList.remove('active'); 
    busButton.classList.remove('active'); 
    airportTransferButton.classList.remove('active'); 
    carrentalButton.classList.remove('active'); 
    otherButton.classList.remove('active'); 
});

// Sự kiện cho nút Khác
otherButton.addEventListener('click', function() {
    otherForm.style.display = 'block'; 
    hotelForm.style.display = 'none'; 
    flightForm.style.display = 'none'; 
    busForm.style.display = 'none'; 
    airportTransferForm.style.display = 'none';
    carrentalForm.style.display = 'none'; 
    activityForm.style.display = 'none'; 
    otherButton.classList.add('active'); 
    hotelButton.classList.remove('active'); 
    flightButton.classList.remove('active'); 
    busButton.classList.remove('active'); 
    airportTransferButton.classList.remove('active'); 
    carrentalButton.classList.remove('active'); 
    activityButton.classList.remove('active'); 
});
