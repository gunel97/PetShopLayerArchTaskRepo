const wishlistTableBody = document.getElementById("wishlistTableBody");
function loadWishlist(data) {
    console.log(data);
    wishlistTableBody.innerHTML = "";
    data.items.forEach(item => {
        wishlistTableBody.innerHTML +=
            `  <tr>
                        <td class="py-4">
                            <div class="cart-info d-flex flex-wrap align-items-center ">
                                <div class="col-lg-3">
                                    <div class="card-image">
                                        <img src="images/${item.imageName}" alt="cloth" class="img-fluid">
                                    </div>
                                </div>
                                <div class="col-lg-9">
                                    <div class="card-detail ps-3">
                                        <h5 class="card-title">
                                            <a href="#" class="text-decoration-none">${item.productName}</a>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td class="py-4 align-middle">
                            <div class="total-price">
                                <span class="secondary-font fw-medium">$ ${item.price}</span>
                            </div>
                        </td>
                        <td class="py-4 align-middle">
                            <div class="total-price">
                                <span class="secondary-font fw-medium">In Stoke</span>
                            </div>
                        </td>
                        <td class="py-4 align-middle">
                            <div class="d-flex align-items-center">
                                <div class="me-4">
                                    <button onclick="addToBasket(${item.productId})" class="btn btn-dark p-3 text-uppercase fs-6 btn-rounded-none w-100">
                                        Add to
                                        cart
                                    </button>
                                </div>
                                <div class="cart-remove">
                                    <a onclick="removeFromWishlist(${item.productId})">
                                        <svg width="24" height="24">
                                            <use xlink:href="#trash"></use>
                                        </svg>
                                    </a>
                                </div>
                            </div>
                        </td>
                    </tr>`
    });
}

//document.addEventListener("DOMContentLoaded", function () {
//    loadBasket();
//});

function addToWishlist(productId) {
    fetch('/wishlist/add/' + productId, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                //loadWishlist(); // Sepeti güncelle
            } else {
                // Hata durumunda yapılacak işlemler
                alert('Failed to add product to basket.');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred while adding the product to the basket.');
        });
}
function removeFromWishlist(productId, element) {
    fetch('/wishlist/remove/' + productId, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            console.log(response);
            if (response.ok) {
                //  loadWishlist(); // Sepeti güncelle
                element.closest('tr').remove(); // Ürünü DOM'dan kaldır
            } else {
                // Hata durumunda yapılacak işlemler
                alert('Failed to remove product from basket.');
            }
        }
        )
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred while removing the product from the basket.');
        });
}
