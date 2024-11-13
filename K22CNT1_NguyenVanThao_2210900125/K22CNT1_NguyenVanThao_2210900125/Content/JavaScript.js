
    // Hàm tính toán và cập nhật thành tiền cho mỗi sản phẩm
    function calculateTotalPrice() {
        // Lấy tất cả các dòng trong bảng
        var rows = document.querySelectorAll('#orderDetailsTable .order-item');

    rows.forEach(function(row) {
            var priceElement = row.querySelector('.price');
    var quantityElement = row.querySelector('.quantity');
    var totalPriceElement = row.querySelector('.total-price');

    // Lấy giá trị đơn giá và số lượng từ các thuộc tính dữ liệu
    var price = parseFloat(priceElement.getAttribute('data-price')); // Lấy đơn giá
    var quantity = parseInt(quantityElement.getAttribute('data-quantity')); // Lấy số lượng

    // Kiểm tra giá trị đầu vào
    if (isNaN(price) || isNaN(quantity)) {
        console.error("Lỗi: Đơn giá hoặc Số lượng không hợp lệ");
    return; // Nếu không hợp lệ, thoát khỏi hàm
            }

    // Tính tổng tiền
    var totalPrice = price * quantity;

    // Định dạng đơn giá và tổng tiền theo kiểu "12.000.000 VNĐ"
    var formattedPrice = price.toLocaleString('vi-VN'); // Định dạng đơn giá
    var formattedTotalPrice = totalPrice.toLocaleString('vi-VN'); // Định dạng tổng tiền

    // Cập nhật giá trị đơn giá và thành tiền
    priceElement.textContent = formattedPrice + ' VNĐ';
    totalPriceElement.textContent = formattedTotalPrice + ' VNĐ';
        });
    }

    // Gọi hàm tính toán khi trang được tải xong
    window.onload = function() {
        calculateTotalPrice();
    };

