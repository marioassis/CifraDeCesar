jQuery(document).ready(function () {
    jQuery("#formEnvio").submit(function (event) {
        event.preventDefault();
        jQuery.post("/Atualizado/EnviarArquivoJson", function (response) {
            jQuery("body").append(response);
            jQuery("#modalAnswer").modal({});
            try {
                jQuery.modal('toggle');   
            } catch (e) {
                console.log(e.message);
            } 
        });
    });
});