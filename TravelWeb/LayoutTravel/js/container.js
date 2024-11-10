document.addEventListener('DOMContentLoaded', function() {
    // Lấy tất cả các nút của tourist và voucher
    const touristButtons = document.querySelectorAll('.container__tourist-options-button');
    const voucherButtons = document.querySelectorAll('.container__voucher-options-button');

    // Hàm để xử lý sự kiện click cho các nút
    function handleButtonClick(buttons) {
        buttons.forEach(button => {
            button.addEventListener('click', function() {
                // Loại bỏ lớp active khỏi tất cả các nút
                buttons.forEach(btn => btn.classList.remove('active'));

                // Thêm lớp active vào nút đang được nhấn
                this.classList.add('active');
            });
        });

        // Đảm bảo nút đầu tiên có lớp active khi trang tải
        buttons[0].classList.add('active');
    }

    // Gọi hàm cho cả nhóm nút
    handleButtonClick(touristButtons);
    handleButtonClick(voucherButtons);
});
