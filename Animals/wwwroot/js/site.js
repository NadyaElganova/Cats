// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#select-option').change(async function () {
    window.location.href = `/Home/SearchCat?name=${this.value}`;
})