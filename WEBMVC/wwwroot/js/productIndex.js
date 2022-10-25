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
                            $('.spinner-grow').show();

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
                                <td class ="table-primary text-danger">${product.ProductName}</td>
                                <td class="table-secondary text-danger">${product.Category.Name}</td>
                                <td class="table-danger text-danger">${product.Price}</td>
                                <td class="table-warning text-danger">${product.Stock}</td>
                                <td class="table-info text-danger">${product.Description}</td>
                                <td class="table-light text-danger">${product.IsActive}</td>
                                <td class="table-dark text-danger">${product.IsDeleted}</td>
                                <td class="table-primary text-danger">${product.Note}</td>
                                <td class="table-secondary text-danger">${product.CreatedDate}</td>
                                <td class="table-successtext-danger">${product.CreatedByName}</td>
                                <td class="table-danger text-danger">${product.ModifiedDate}</td>
                                <td class="table-info text-danger">${product.ModifiedByName}</td>
                            </tr>`;

                                    });
                                $('#productTable > tbody').replaceWith(tableBody);
                                $('.spinner-grow').hide();
                                $('#productTable').fadeIn(1400);
                            }
                            else {
                                toastr.error(`${productListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            $('.spinner-grow').hide();
                            $('#productTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Wrong!');
                        }
                    });
                }
            }
        ],
    });
//Datatables finish
    //@* Ajax Add get metodu *@



});