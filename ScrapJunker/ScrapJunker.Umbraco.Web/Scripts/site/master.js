function verticalAlignMiddle() {
    var bodyHeight = $(window).height();
    var formHeight = $('.vamiddle').height();
    var marginTop = (bodyHeight / 4) - (formHeight / 4);
    if (marginTop > 0) {
        $('.vamiddle').css('margin-top', marginTop);
    }
}

window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        $('#backToTop').fadeIn();
    } else {
        $('#backToTop').fadeOut();
    }
}

$('#backToTop').click(function () {
    $('body,html').animate({
        scrollTop: 0
    }, 800);
    return false;
});


$(document).ready(function () {
    verticalAlignMiddle();
});

$(window).bind('resize', verticalAlignMiddle);