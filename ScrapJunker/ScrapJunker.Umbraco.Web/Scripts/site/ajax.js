$(document).ready(function () {
    $("form")
        //.formValidation()
        .on('submit', function (e) {
            // Prevent form submission
            e.preventDefault();

            var $form = $(e.target),
                fv = $form.data('formValidation');

            // Use Ajax to submit form data
            $.ajax({
                url: $form.attr('action'),
                type: 'POST',
                data: $form.serialize(),
                beforeSend: function () {
                    debugger;
                    $form.LoadingOverlay("show");
                },
                success: function (result) {
                    toastr.success("Success!");
                },
                error: function (result) {
                    if (result.responseJSON.ModelState !== undefined) {
                        var errors = [];
                        for (var key in result.responseJSON.ModelState) {
                            for (var i = 0; i < result.responseJSON.ModelState[key].length; i++) {
                                errors.push(result.responseJSON.ModelState[key][i]);
                            }
                        }
                        toastr.error(errors);
                    }
                    else if (result.responseJSON.ExceptionMessage !== undefined) {
                        toastr.error(result.responseJSON.ExceptionMessage);
                    } else {
                        toastr.error(result.responseJSON.Message);
                    }
                },
                complete: function () {
                    $form.LoadingOverlay("hide");
                }
            });
        });
});