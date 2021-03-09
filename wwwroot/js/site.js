 $(document).ready(function () {
   // toastr.error("test","testset");
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-left",
        "preventDuplicates": false, 
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showDuration": "200",
        "showEasing": "swing",
        "showMethod": "fadeIn",
        "hideDuration": "600",
       // "hideEasing": "easeInBack",//"slideUp", //"linear",
        "hideMethod": "fadeOut",
      'tapToDismiss': false,
        "closeEasing ":"slideUp",
      "rtl": true,
      
      }
});


// $(document).ready(function () {

//     $('#btnClick').click(function () {
//         $('#customerForm').modal('show');

//     });
//     $('#btnClose').click(function () {
//         $('#customerForm').modal('hide');
//     });

//     var PlaceHolderElement = $("#PlaceHolderHere");
//     $('button[data-toggle="ajax-modal"]').click(function (event) {
//         var url = $(this).data('url');
//         var decodedUrl = decodeURIComponent(url);

//         $.get(decodedUrl).done(function (data) {
//             PlaceHolderElement.html(data);
//             PlaceHolderElement.find('.modal').modal('show');
//         });
//     });


//     PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
//         event.preventDefault();
//         var form = $(this).parents('.modal').find('form');
//         var actionUrl = form.attr('action');
//         var sendData = form.serialize();
//         $.post(actionUrl, sendData).done(function (data) {
//             PlaceHolderElement.find('.modal').modal('hide');
//         });
//     });

// }) 