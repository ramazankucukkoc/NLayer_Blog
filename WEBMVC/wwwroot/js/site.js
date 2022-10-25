// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function convertFirstLetterToUpperCase(text) {
    return text.charAt(0).toUpperCase() + text.slice(1);
}
function convertToShortDate(dateString) {
    const shortDate= new Date(dateString).toLocaleDateString('en-US');
    return shortDate;
}

