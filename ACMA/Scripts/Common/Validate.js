window.Validate = (function () {
    'use strict';

    var configLoginForm = function (submitHandler) {

        $("#formLogin").validate({
            submitHandler: function (form) {
                if ($(form).valid()) {
                    submitHandler(form);
                }
                return false;
            },
            onfocusout: function (element) {
                var valid = $(element).valid();
                if (!valid)
                    $(element).val('');
            },
            rules: {
                UserName: {
                    required: true
                },
                Password: {
                    required: true
                }
            },
            messages: {
                UserName: {
                    required: 'O campo Usuario é obrigatório'
                },
                Password: {
                    required: 'O campo Senha é obrigatório',
                }              
            }
        });
    };

    var configRegisterUserForm = function (submitHandler) {
        ValidateMethod.AddMethodFullName();
        ValidateMethod.AddMethodPhoneRequired();
        ValidateMethod.AddMethodSelectListRequired();

        $('#IdSelectListProfile').on('change', function () {
            $(this).valid();
        });

        $("#formRegisterUser").validate({
            submitHandler: function (form) {
                if ($(form).valid()) {
                    submitHandler(form);
                }
                return false;
            },
            errorPlacement: function (error, element) {
                //check whether chosen plugin is initialized for the element
                if (element.data().chosen) { //or if (element.next().hasClass('chosen-container')) {
                    element.next().after(error);
                } else {
                    element.after(error);
                }
            },
            onfocusout: function (element) {
                var valid = $(element).valid();
                if (!valid)
                    $(element).val('');
            },
            rules: {
                UserName: {
                    required: true
                },
                Password: {
                    required: true
                },
                Email: {
                    required: true,
                    email: true
                },
                FullName: {
                    required: true,
                    fullName: true
                },
                Phone: {
                    phone: true
                },
                IdSelectListProfile: {
                    selectListRequired: true,
                }
            },
            messages: {
                UserName: {
                    required: 'O campo Usuario é obrigatório'
                },
                Password: {
                    required: 'O campo Senha é obrigatório',
                },
                Email: {
                    required: 'O campo E-mail é obrigatório',
                    email: 'Digite um email válido'
                },
                FullName:{
                    required: 'O campo Usuario é obrigatório',
                    fullName: 'Digite o seu nome completo'
                },
                Phone: {
                    phone: 'O campo Telefone é obrigatório'
                },
                IdSelectListProfile: {
                    selectListRequired: 'O campo Perfil de Acesso é obrigatório'
                }
            }
        });
    };

    var configUpdateUserForm = function (submitHandler) {
        ValidateMethod.AddMethodFullName();
        ValidateMethod.AddMethodSelectListRequired();

        $('#IdSelectListProfile').on('change', function () {
            $(this).valid();
        });

        $("#formUpdateUser").validate({
            submitHandler: function (form) {
                if ($(form).valid()) {
                    submitHandler(form);
                }
                return false;
            },
            errorPlacement: function (error, element) {
                //check whether chosen plugin is initialized for the element
                if (element.data().chosen) { //or if (element.next().hasClass('chosen-container')) {
                    element.next().after(error);
                } else {
                    element.after(error);
                }
            },
            onfocusout: function (element) {
                var valid = $(element).valid();
                if (!valid)
                    $(element).val('');
            },
            rules: {
                UserName: {
                    required: true
                },
                Password: {
                    required: true
                },
                Email: {
                    required: true,
                    email: true
                },
                FullName: {
                    required: true,
                    fullName: true
                },
                Phone: {
                    required: true
                },
                IdSelectListProfile: {
                    selectListRequired: true,
                }
            },
            messages: {
                UserName: {
                    required: 'O campo Usuario é obrigatório'
                },
                Password: {
                    required: 'O campo Senha é obrigatório',
                },
                Email: {
                    required: 'O campo E-mail é obrigatório',
                    email: 'Digite um email válido'
                },
                FullName: {
                    required: 'O campo Usuario é obrigatório',
                    fullName: 'Digite o seu nome completo'
                },
                Phone: {
                    required: 'O campo Telefone é obrigatório'
                },
                IdSelectListProfile: {
                    selectListRequired: 'O campo Perfil de Acesso é obrigatório'
                }
            }
        });
    };

    return {
        configLoginForm: configLoginForm,
        configRegisterUserForm: configRegisterUserForm,
        configUpdateUserForm: configUpdateUserForm
    };

}());