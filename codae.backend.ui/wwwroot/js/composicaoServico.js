(function ($) {
    $(function () {

        function submit() {
            var formdata = new FormData($('form').get(1));
            var options = {
                url: '/Servico/CreateItem',
                data: formdata,
                cache: false,
                contentType: false,
                processData: false,
                type: 'POST',
                error: function (xhr) {
                    alert("An error occured: " + xhr.status + " " + xhr.statusText);
                },
                success: function (data) {
                    $('#composicao').html(data);
                    $('#submitComponent').on('click', submit);
                    $('#form-component').reset();
                }
            };
            $.ajax(options);
        }   
        
        $('#submitComponent').on('click', submit);
    });
})(jQuery);