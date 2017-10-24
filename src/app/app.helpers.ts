declare var jQuery: any;


export function SetFoucs(id) {

    jQuery(id).focus();
}
export function CloseModal(id) {
    jQuery(id).modal('toggle');
}
export function Processing(id, value) {
    jQuery(id).css("display", value);
}
export function Notify(id, value, msg ='Record saved successfully..') {
    jQuery(".msg", id).text(msg);
   
    jQuery(id).show(value, function () {
        setTimeout(function () { jQuery(id).hide(); }, 3000);
    });
}

export function setFormValidation(id) {
   
    jQuery(id).validate({
       
        errorPlacement: function(error, element) {
          
            jQuery(element).closest('div').addClass('has-error');
        }
    });
}

export function ValidateMe(id) {
    return jQuery(id).validate();

}
export function ValidationCheck(id) {
    return jQuery(id).valid();
}