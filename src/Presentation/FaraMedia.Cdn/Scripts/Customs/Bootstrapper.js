$(document).ready(function() {
    $("time").timeago();

    $(".sortable-table").tablesorter();

    $('a[trap="true"]').click(function(e) {
        e.preventDefault();
    });

    $('div.alert-message').delay(5000).each(function(i) {
        $(this).delay(1000 * i).fadeOut();
    });

    $('div.alert-message a.close').click(function() {
        $(this).parent().fadeOut();
    });
});