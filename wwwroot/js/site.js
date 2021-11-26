// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function ()
{
    $(".page-link").click(function (e)
    {
        e.preventDefault();
        var uri = this.attributes["href"].value;
        $("#list").load(uri);
        $(".active").removeClass("active disabled");
        $(this).parent().addClass("active");
        history.pushState(null, null, uri);
    });
});