$(document).ready(function () {
    $('.nav-tabs li').click(function () {
        $('.active').removeClass('active');
        $(this).addClass('active');
    });
});