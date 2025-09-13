 basketTotalPrice = document.getElementById("basketTotalPrice");
 basketContainer = document.getElementById("basketContainer");
 basketTotalCount = document.getElementById("basketTotalCount");
 basketTotalBadge = document.getElementById("basketTotalBadge");

function loadBasket() {
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
                basketContainer.innerHTML += `                   
                <li class="list-group-item d-flex justify-content-between lh-sm">
                    <div>
                        <h6 class="my-0">${item.productName} (${item.quantity})</h6>
                    </div>
                    <span class="text-body-secondary">$${item.quantity * item.price}</span>
                </li>`;
            });
            basketContainer.innerHTML += ` 
                <li class="list-group-item d-flex justify-content-between">
                    <span class="fw-bold">Total (USD)</span>
                    <strong id="basketTotalPrice">$${data.totalPrice}</strong>
                </li>`;

            basketTotalCount.innerText = data.totalCount;
            basketTotalBadge.innerText = data.totalCount;
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

document.addEventListener("DOMContentLoaded", function () {
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
            loadBasket(); // Sepeti güncelle
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
function removeFromBasket(productId, element) {
    fetch('/basket/remove/' + productId, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => {
        if (response.ok) {
            loadBasket(); // Sepeti güncelle
            element.closest('tr').remove(); // Ürünü DOM'dan kaldır
        } else {
            // Hata durumunda yapılacak işlemler
            alert('Failed to remove product from basket.');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('An error occurred while removing the product from the basket.');
    });
}