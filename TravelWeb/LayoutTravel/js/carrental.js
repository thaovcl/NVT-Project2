document.querySelectorAll('.car-rental-options-button').forEach(button => {
    button.addEventListener('click', function() {
        // Xóa lớp 'active' khỏi tất cả các nút
        document.querySelectorAll('.car-rental-options-button').forEach(btn => {
            btn.classList.remove('active');
        });
        
        // Thêm lớp 'active' cho nút được nhấn
        this.classList.add('active');
    });
});

// Kích hoạt sự kiện click cho nút Tự lái khi tải trang
document.querySelector('.car-rental-options-button[data-option="self-drive"]').click();



