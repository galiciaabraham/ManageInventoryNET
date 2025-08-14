// Initialize Blazor helper functions
window.blazorHelpers = {
    showModal: function (element) {
        $(element).modal('show');
    },
    hideModal: function (element) {
        $(element).modal('hide');
    }
};