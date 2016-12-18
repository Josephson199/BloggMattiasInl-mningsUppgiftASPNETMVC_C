// Write your Javascript code.
$(document)
    .ready(function ($) {
        $('.accordion-content').slideUp("fast");
    });


$(document).ready(function ($) {
    $('.accordion').find('.accordion-toggle').on("click", function () {

        //Expand or collapse this panel
        $(this).next().slideToggle('fast');

        //Hide the other panels
        $(".accordion-content").not($(this).next()).slideUp('fast');

    });
});


