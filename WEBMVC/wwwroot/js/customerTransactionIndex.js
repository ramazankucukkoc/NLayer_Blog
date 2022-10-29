$(document).ready(function () {
    $('#table').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Satış Yap',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-secondary',
                //action: function (e, dt, node, config) {
                //    alert('Ekle butonuna basıldı');
                //}
            },
            {
                text: 'Yenile',
                className: 'btn btn-info',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/CustomerTransaction/GetAllCustomerTransactions/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $("#table").hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const customerTransactionListDto = jQuery.parseJSON(data);
                            console.log(customerTransactionListDto);
                            if (customerTransactionListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(customerTransactionListDto.CustomerTransaction.$values,
                                    function (index, customerTransaction) {
                                        tableBody += `
                                        <tr>

 <td>
                                            <button class="btn btn-success btn-sm btn-block btn-update" data-id="${customerTransaction.Id}"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen-fill" viewBox="0 0 16 16">
  <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001z"/>
</svg></button>
                                            <button class="btn btn-danger btn-sm btn-block btn-delete"data-id="${customerTransaction.Id}"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg></button>
                                        </td>
   <td>${customerTransaction.ProductId}</td>
   <td>${customerTransaction.CustomerId}</td>
   <td>${customerTransaction.PersonelId}</td>
   <td>${customerTransaction.Unit}</td>
   <td>${customerTransaction.UnitPrice}</td>
   <td>${customerTransaction.TotalPrice}</td>
                                        <td>${customerTransaction.Description}</td>
                                        <td>${customerTransaction.IsActive}</td>
                                        <td>${customerTransaction.IsDeleted}</td>
                                        <td>${customerTransaction.Note}</td>                                     
                                        <td>${customerTransaction.CreatedDate}</td>
                                        <td>${customerTransaction.CreatedByName}</td>
                                        <td>${customerTransaction.ModifiedDate}</td>
                                        <td>${customerTransaction.ModifiedByName}</td>
                                               
                                    </tr>`;

                                    });
                                $('#table > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#table').fadeIn(1400);
                            }
                            else {

                                toastr.error(`${customerTransactionListDto.Message}`, 'İşlem Başarısız!')
                            }
                        },
                        error: function (err) {
                            $('.spinner-border').hide();
                            $('#table').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Wrong!')

                        }
                    });
                }
            }


        ],

        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    $(function () {
        const url = '/CustomerTransaction/Add/';
        const placeHolderDiv = $("#modalPlaceHolder");

        $('#btnAdd').click(function () {

            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-customerTransaction-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);

                    const customerTransactionAddAjaxModel = jQuery.parseJSON(data);
                    console.log(customerTransactionAddAjaxModel);

                    const newFormBody = $('.modal-body', customerTransactionAddAjaxModel.CustomerTransactionAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';

                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.Id}">
                                       <td>
                                      <button class="btn btn-success btn-sm btn-block btn-update" data-id="${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.Id}"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen-fill" viewBox="0 0 16 16">
                                           <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001z"/>
                                           </svg></button>

                                                    <button class="btn btn-danger btn-sm btn-block btn-delete"data-id="${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.Id}"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                                </svg>
                                               </button>
                                                    </td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.ProductId}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.CustomerId}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.PersonelId}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.Unit}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.UnitPrice}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.TotalPrice}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.Description}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.IsActive}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.IsDeleted}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.Note}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.CreatedDate}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.CreatedByName}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.ModifiedDate}</td>
                                                    <td>${customerTransactionAddAjaxModel.CustomerTransactionDto.CustomerTransaction.ModifiedByName}</td>
                                                    <td>
                                                   
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#table').append(newTableRowObject);
                        newTableRowObject.fadeIn(2500);
                        toastr.success(`${customerTransactionAddAjaxModel.CustomerTransactionDto.Message}`, 'Başarılı İşlem!');
                    }
                    else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;

                        });
                        toastr.warning(summaryText);
                    }
                });
            });




    });

});