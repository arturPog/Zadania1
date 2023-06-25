

$("#pobierz").on('click', function (e) {
    alert("ok");
    let urlAjax = $('#pobierzUrlHidden').attr("data-url");
    let nip = $('#nip').val();
    var FormDataSend = new FormData();
    FormDataSend.append("nip", nip);
    $.ajax({
        url: urlAjax,
        //cache: false,
        type: "Post",
        data: FormDataSend,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            alert("ok2");

            if (result.companyDBStr) {
                $("#companyData").html(result.companyDBStr);
                alert("ok3");
            }
            alert("ok4");
        },
        error: function (xhr, ajaxOptions, thrownError) {

            alert('błąd przetwarzania. PageHomeLoadAjax');
        }, complete: function (data) {
            alert("ok5");
        }
    });
});
$(document).on('ready', function () {
    alert("ok");
   
});