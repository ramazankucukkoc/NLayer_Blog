$(document).ready(function () {
    $('#productTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ürün Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-primary',

            },
            {
                text: 'Refresh',
                className: 'btn btn-danger',
                action: function (e, dt, nofr, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Products/GetAllProducts/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $("#productTable").hide();
                            //$('.spinner-grow').show();

                        },
                        success: function (data) {
                            const productListDto = jQuery.parseJSON(data);
                            console.log(productListDto);
                            if (productListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(productListDto.Products.$values,
                                    function (index, product) {
                                        tableBody += `
                                           <tr>
                                <td>
                                    <button class="btn btn-success btn-sm btn-block btn-update" data-id="${product.Id}">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen-fill" viewBox="0 0 16 16">
                                            <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001z" />
                                        </svg>
                                    </button>
                                    <button class="btn btn-danger btn-sm btn-block  btn-delete" data-id="${product.Id}">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg>
                                    </button>
                                </td>                              
                                <td >${product.ProductName}</td>
                                <td >${product.CategoryId}</td>
                                <td >${product.Price}</td>
                                <td >${product.Stock}</td>
                                <td >${product.Description}</td>
                                <td>${product.IsActive}</td>
                                <td >${product.IsDeleted}</td>
                                <td >${product.Note}</td>
                                <td >${product.CreatedDate}</td>
                                <td >${product.CreatedByName}</td>
                                <td >${product.ModifiedDate}</td>
                                <td >${product.ModifiedByName}</td>
                            </tr>`;

                                    });
                                $('#productTable > tbody').replaceWith(tableBody);
                                //$('.spinner-grow').hide();
                                $('#productTable').fadeIn(1400);
                            }
                            else {
                                toastr.error(`${productListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            //$('.spinner-grow').hide();
                            $('#productTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Wrong!');
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
//Datatables finish
    //@* Ajax Add get metodu *@
    $(function () {
        const url = '/Products/Add/';
        const placeHolderDiv = $("#modalPlaceHolder");
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });
        //@* Ajax Add post metodu *@
        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-product-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const productAddAjaxModel = jQuery.parseJSON(data);

                    console.log(productAddAjaxModel);

                    const newFormBody = $('.modal-body', productAddAjaxModel.ProductAddPartial);

                    placeHolderDiv.find('.modal.body').replaceWith(newFormBody);

                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const tableNewRow = `
                          <tr name="${productAddAjaxModel.ProductDto.Product.Id}">
                                <td>
                                    <button class="btn btn-success btn-sm btn-block btn-update" data-id="${productAddAjaxModel.ProductDto.Product.Id}">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen-fill" viewBox="0 0 16 16">
                                            <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001z" />
                                        </svg>
                                    </button>
                                    <button class="btn btn-danger btn-sm btn-block  btn-delete" data-id="${productAddAjaxModel.ProductDto.Product.Id}">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg>
                                    </button>
                                </td>
                                <td >${productAddAjaxModel.ProductDto.Product.ProductName}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.CategoryId}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.Price}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.Stock}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.Description}</td>

                                <td >${productAddAjaxModel.ProductDto.Product.IsActive}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.IsDeleted}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.Note}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.CreatedDate}</td>
                                <td>${productAddAjaxModel.ProductDto.Product.CreatedByName}</td>
                                <td>${productAddAjaxModel.ProductDto.Product.ModifiedDate}</td>
                                <td >${productAddAjaxModel.ProductDto.Product.ModifiedByName}</td>
                            </tr>`;

                        const newTableRowObject = $(tableNewRow);
                        newTableRowObject.hide();
                        $('#productTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${productAddAjaxModel.ProductDto.Message}`, "Başarılı Şekilde ekleme gerçekleşti");
                    }
                    else {
                        let summaryText = "";
                        $('#validation-summary >ul >li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;

                        });
                        toastr.warning(summaryText);
                    }
                });
            });
        });
    //@* Ajax Delete post metodu *@
    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const productName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Are You Sure?',
                text: `${productName} You won't be able to revert this!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes,delete it!',
                cancelButtonText:'No, delete it!'

            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { productId: id },
                        url: '/Products/Delete',
                        success: function (data) {
                            const productDto = jQuery.parseJSON(data);
                            if (productDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `${productDto.Product.ProductName} adlı ürün başarıyla silinmiştir`,
                                    'success'
                                );
                                tableRow.fadeOut(3500);

                            }
                            else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'There are Wrong a Transaction',
                                    text: `${productDto.Message}`
                                });
                            }

                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`);

                        }

                    })
                }
            });
        });
    //@* Ajax Update get metodu *@
    $(function () {
        const url = '/Products/Update';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update', function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url,{productId:id}).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');

                }).fail(function () {
                    toastr.error("Bir hata Meydana Geldi.");
                });
        });
        //@* Ajax Update post metodu *@
        placeHolderDiv.on('click',
            '#btn-update',
            function (event) {
                event.preventDefault();
                const form = $('#form-product-update');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    const productUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(productUpdateAjaxModel);
                    const newFormBody = $('.modal-body', productUpdateAjaxModel.ProductUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');

                        const newTableRow = `
                                <tr name="${productUpdateAjaxModel.ProductDto.Product.Id}">
                                <td>
                                    <button class="btn btn-success btn-sm btn-block btn-update" data-id="@product.Id">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen-fill" viewBox="0 0 16 16">
                                            <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001z" />
                                        </svg>
                                    </button>
                                    <button class="btn btn-danger btn-sm btn-block  btn-delete" data-id="@product.Id">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg>
                                    </button>
                                </td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.ProductName}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.CategoryId}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.Price}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.Stock}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.Description}</td>

                                <td >${productUpdateAjaxModel.ProductDto.Product.IsActive}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.IsDeleted}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.Note}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.CreatedDate}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.CreatedByName}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.ModifiedDate}</td>
                                <td >${productUpdateAjaxModel.ProductDto.Product.ModifiedByName}</td>

                            </tr>`;
                        const newTableRowObject = $(newTableRow);
                        const categoryTableRow = $(`[name="${productUpdateAjaxModel.ProductDto.Product.Id}"]`);
                        newTableRowObject.hide();
                        categoryTableRow.replaceWith(newTableRowObject);

                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${productUpdateAjaxModel.ProductDto.Message}`, 'Başarılı İşlem!');

                    }
                    else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;

                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function (response) {
                    console.log(response);
                });
            });
    });
});