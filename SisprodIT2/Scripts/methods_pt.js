// Esta parte pode ser colocada em um script da aplicação e juntado ao Bundle
jQuery.validator.addMethod("mynumber", function (value, element) {
    return this.optional(element) || /^(\d+|\d+,\d{1,2})$/.test(value);
}, "O campo " + element + " deve ser um número.");

// Esta parte é para cada form
$("#meuForm").validate({
    rules: {
        field: {
            required: true,
            mynumber: true
        }
    }
});