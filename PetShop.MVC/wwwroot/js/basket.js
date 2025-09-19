
const basketTotalPrice = document.getElementById('basketTotalPrice');
const basketContainer  = document.getElementById('basketContainer');
const basketTotalCount = document.getElementById('basketTotalCount');
const basketTotalBadge = document.getElementById('basketTotalBadge');

function loadBasket(){
    fetch('/basket/getbasket', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            basketContainer.innerHTML = "";
            data.items.forEach(item => {
                basketContainer.innerHTML += `<li class="list-group-item d-flex justify-content-between lh-sm">
                    <div>
                    <h6 class='my-0'>${item.productName} (${item.quantity})</h6>
                    </div>
            <span class="text-body-secondary">$${item.quantity * item.price}</span>
            </li> `;

            });

            basketContainer.innerHTML +=
            `<li class="list-group-item d-flex justify-content-between">
        <span class="fw-bold">Total (USD)</span>
        <strong id="basketTotalPrice">$${data.totalPrice}</strong>
    </li>`;
            basketTotalCount.innerText = data.totalCount;
            basketTotalBadge.innerText = data.totalCount;
        })
        .catch(error => {
            console.Error('Error:', error);
        });
}

function loadBasket1(data) {
            basketContainer.innerHTML = "";
            data.items.forEach(item => {
                basketContainer.innerHTML += `<li class="list-group-item d-flex justify-content-between lh-sm">
                    <div>
                    <h6 class='my-0'>${item.productName} (${item.quantity})</h6>
                    </div>
            <span class="text-body-secondary">$${item.quantity * item.price}</span>
            </li> `;

            });

            basketContainer.innerHTML +=
                `<li class="list-group-item d-flex justify-content-between">
        <span class="fw-bold">Total (USD)</span>
        <strong id="basketTotalPrice">$${data.totalPrice}</strong>
    </li>`;
            basketTotalCount.innerText = data.totalCount;
            basketTotalBadge.innerText = data.totalCount;
}

document.addEventListener('DOMContentLoaded', function(){
    loadBasket();
});

function addToBasket(productId) {
    fetch('/basket/add/' + productId, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                loadBasket();
                alert('Product added to basket!');
            }
            else {
                alert('Failed to add product to basket')
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occured');
        });
}

function removeFromBasket(productId) {
    fetch('/basket/remove/' + productId, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                loadBasket();
                element.closest('tr').remove();
            }
            else {
                alert('Failed to remove product from basket');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occured');
        });
}

function changeQuantity(productId, change) {

    const productIdInput = document.getElementById(`productId${productId}`);
    const currentQuantity = parseInt(productIdInput.value);
    const cartContainer = document.getElementById('cartContainer');

    if (currentQuantity + change < 1) {
        return;
    }

    productIdInput.value = currentQuantity + change;

    fetch(`/cart/changeQuantity?productId=${productId}&change=${change}`, {
        method: 'POST'
    })
        .then(response => response.json())
        .then(data =>
        {
            console.log(data);
            cartContainer.innerHTML = data.cartHtml;
            loadBasket1(data.basketViewModel);
        })
        .catch(error => console.error('Error:', error));
}

