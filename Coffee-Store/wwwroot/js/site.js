let menu = document.querySelector("#menu-btn");
let navbar = document.querySelector(".navbar");

menu.onclick = () => {
    menu.classList.toggle("fa-times");
    navbar.classList.toggle("active");
};

window.onscroll = () => {
    menu.classList.remove("fa-times");
    navbar.classList.remove("active");
};

document.querySelectorAll(".image-slider img").forEach((images) => {
    images.onclick = () => {
        var src = images.getAttribute("src");
        document.querySelector(".main-home-image").src = src;
    };
});


const increaseButtons = document.querySelectorAll('.increase');
const decreaseButtons = document.querySelectorAll('.decrease');

// Event listeners to the increase buttons
increaseButtons.forEach(button => {
    button.addEventListener('click', function () {
        const quantityInput = this.parentElement.querySelector('input');
        // Ensure the quantity is a number and less than 99 before incrementing
        if (!isNaN(quantityInput.value) && quantityInput.value < 99) {
            quantityInput.value = parseInt(quantityInput.value) + 1;
        }
    });
});

// Event listeners to the decrease buttons
decreaseButtons.forEach(button => {
    button.addEventListener('click', function () {
        const quantityInput = this.parentElement.querySelector('input');
        // Ensure the quantity is a number and more than 0 before decrementing
        if (!isNaN(quantityInput.value) && quantityInput.value > 0) {
            quantityInput.value = parseInt(quantityInput.value) - 1;
        }
    });
});

// Validation for the Quantity Input field in Orders Page

function validateQuantity(input) {
    if (input.value < 0) input.value = 0;
    if (input.value > 99) input.value = 99;
}

// Validation for the Form in the Reservations Page

document.querySelector('form').addEventListener('submit', function (e) {
    // Get the input values
    var name = document.getElementById('name').value;
    var email = document.getElementById('email').value;
    var phone = document.getElementById('phone').value;

    // Validate the name
    if (name.length > 100) {
        alert('Name cannot be longer than 100 characters.');
        e.preventDefault();
        return;
    }

    // Validate the email
    if (!email.includes('@')) {
        alert('Invalid Email Address');
        e.preventDefault();
        return;
    }

    // Validate the phone number
    if (phone.length != 10) {
        alert('Phone Number must be 10 digits long.');
        e.preventDefault();
        return;
    }
});

// Validations for Login Page

function validateForm() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    if (username == "" || password == "") {
        alert("Username and Password must be filled out");
        return false;
    }
}