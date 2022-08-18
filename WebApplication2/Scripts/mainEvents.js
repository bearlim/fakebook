$('BODY').on('click', '.inputRadio', function () {
    if ($('#genPersonalizado').is(':checked')) {
        $('#gerenoPersonalizado').fadeIn();
    }
    else {
        $('#gerenoPersonalizado').fadeOut();
    }
})