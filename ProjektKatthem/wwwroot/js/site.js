// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Hitta knapp via ID:
let mybutton = document.getElementById("myBtn");

// När användaren scrollar 20px ner visas knappen
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 150) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// När knappen används - åk upp till toppen
function topFunction() {
    document.body.scrollTop = 0; // För Safari
    document.documentElement.scrollTop = 0; // För Chrome, Firefox, IE and Opera
}