// Lưu nôi dung hs trả lại
function SavesContent() {
    var array = [];
    $("#tableAll tr input[type=checkbox]").each(function () {

        if ($(this).is(":checked")) {
            let idBrowser = $(this).val();
            array.push(parseInt(idBrowser));
        }

    });
    if (array != null && array != "") {
        let dataId = JSON.stringify(array);

        var NoiDung = $('#txtNoiDung').val();
        $.ajax({
            method: 'POST',
            url: "/HoSoDuTuyen/SaveBackAll",
            data: {
                dataId: dataId,
                NoiDung: NoiDung

            },
            success: function (response) {
                if (response.status == true) {


                    location.reload();

                }
                else {
                    return false
                }
            },
            error: function (err) {
                console.log(err)
            }
        })
    } else {
        var ID = $('#hdID_A').val();
        var NoiDung = $('#txtNoiDung').val();
        var formData = new FormData();
        formData.append("ID", ID);
        formData.append("NoiDung", NoiDung);

        $.ajax({
            async: false,
            type: 'POST',
            url: "/HoSoDuTuyen/SaveBack",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.status == true) {


                    location.reload();

                }
                else {
                    return false
                }
            },
            error: function (err) {
                console.log(err)
            }
        })
    }

}

//show modal nội dung trả lại
function Back(id) {
    $('#returnform').modal("show");
    $('#hdID_A').val(id);
}

//show form hồ sơ trả lại nhiều hồ sơ
function BackAll() {
    $('.Checks').each(function () {
        if ($(this).is(':checked') == true) {
            $('#returnform').modal("show");
        }
    });


}


// 
function LuuHoSo() {

    var $fileUpload = $("input[type='file']");
    if (parseInt($fileUpload.get(0).files.length) > 6) {
        alert("Bạn chỉ được tải lên tối đa là 6 file");
        return false;
    }

    var ID = $('#hdID').val();
    var HoTen = $('#txtHoTen').val();
    var GioiTinh = $('#ddlGioiTinh').val();
    var DanToc = $('#ddlDanToc').val();
    var Email = $('#txtEmail').val();
    var NgaySinhHs = $('#txtNgaySinh').val();
    var SoNhaThuongTru = $('#txtDiaChiThuongTru').val();
    var HoTenMe = $('#txtTenMe').val();
    var NgheNghiepMe = $('#txtNgheNghiepMe').val();
    var sdtMe = $('#txtSoDienThoaiMe').val();
    var HoTenBo = $('#txtTenBo').val();
    var NgheNghiepBo = $('#txtNgheNghiepBo').val();
    var sdtBo = $('#txtSoDienThoaiBo').val();
    var TenNguoiGiamHo = $('#txtTenNguoiGiamHo').val();
    var EmailGiamHo = $('#txtEmailNguoiGiamHo').val();
    var sdtGiamHo = $('#txtSoDienThoaiLienHe').val();
    var NgheNghiepGiamHo = $('#txtNgheNghiep').val();
    var TinhThuongTru = $('#ddlTinhThuongTru').val();
    var HuyenThuongTru = $('#ddlHuyenThuongTru').val();
    var XaThuongTru = $('#ddlXaThuongTru').val();
    var TinhTamTru = $('#ddlTinhTamTru').val();
    var HuyenTamTru = $('#ddlHuyenTamTru').val();
    var XaTamTru = $('#ddlXaTamTru').val();
    var SoNhaTamTru = $('#txtDiaChiTamTru').val();
    var NguyenVong1 = $('#ddlNguyenVong1').val();
    var NguyenVong2 = $('#ddlNguyenVong2').val();
    var array = [];
    $("#hideDTUT tr input[type=checkbox]").each(function () {
        if ($(this).is(":checked")) {
            let idDTUT = $(this).val();
            array.push(parseInt(idDTUT));
        }
    });
    var dataString = JSON.stringify(array);
    var fileUpload = $("#uploadFile").get(0);
    var files = fileUpload.files;

    var formData = new FormData();

    formData.append("ID", ID);
    formData.append("HoTen", HoTen);
    formData.append("GioiTinh", GioiTinh);
    formData.append("DanToc", DanToc);
    formData.append("Email", Email);
    formData.append("NgaySinhHs", NgaySinhHs);
    formData.append("SoNhaThuongTru", SoNhaThuongTru);
    formData.append("HoTenMe", HoTenMe);
    formData.append("NgheNghiepMe", NgheNghiepMe);
    formData.append("sdtMe", sdtMe);
    formData.append("HoTenBo", HoTenBo);
    formData.append("NgheNghiepBo", NgheNghiepBo);
    formData.append("sdtBo", sdtBo);
    formData.append("TenNguoiGiamHo", TenNguoiGiamHo);
    formData.append("EmailGiamHo", EmailGiamHo);
    formData.append("sdtGiamHo", sdtGiamHo);
    formData.append("NgheNghiepGiamHo", NgheNghiepGiamHo);
    formData.append("TinhThuongTru", TinhThuongTru);
    formData.append("HuyenThuongTru", HuyenThuongTru);
    formData.append("XaThuongTru", XaThuongTru);
    formData.append("TinhTamTru", TinhTamTru);
    formData.append("HuyenTamTru", HuyenTamTru);
    formData.append("XaTamTru", XaTamTru);
    formData.append("SoNhaTamTru", SoNhaTamTru);
    formData.append("NguyenVong1", NguyenVong1);
    formData.append("NguyenVong2", NguyenVong2);
    formData.append("UT", dataString);


    for (var i = 0; i < files.length; i++) {
        formData.append(files[i].name, files[i]);
    }

    $.ajax({
        async: false,
        type: 'POST',
        url: "/DK_du_tuyen/SaveCreate",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.status == true) {

                alert(response.mess);
                location.reload();

            }
            else {
                return false
            }
        },
        error: function (err) {
            console.log(err)
        }
    })
}


// Xóa hs
function Deldelete(idHs) {
    let result = confirm("Bạn có muốn xóa hồ sơ này không?");
    if (result) {
        $.ajax({
            type: 'GET',
            url: '/HoSoDuTuyen/Del',
            data: {
                id: idHs
            },
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {

                    location.reload();

                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    else {
        return false;
    }

}

//fun xóa nhiều bảng ghi cùng lúc
function DeleteAll() {
    $('.Checks').each(function () {
        if ($(this).is(':checked') == true) {
            let Tralai = confirm("Bạn có muốn xóa những hồ sơ này không?");
            if (Tralai) {
                var array = [];
                $("#tableAll tr input[type=checkbox]").each(function () {
                    if ($(this).is(":checked")) {
                        let idDelete = $(this).val();
                        array.push(parseInt(idDelete));
                    }
                });
                //convert từ array sang string
                var dataString = JSON.stringify(array);
                $.ajax({
                    type: 'Post',
                    url: '/HoSoDuTuyen/DelAll',
                    dataType: "json",
                    data: { dataString: dataString },

                    success: function (response) {
                        if (response.status == true) {

                            location.reload();
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });
            } else {
                return false;
            }

        };
    });

}


//show form hs mới
function addData() {
    $('#exampleModal').modal("show");
    $('#txtHoTen').val('');
    $('#txtEmail').val('');
    $('#txtNgaySinh').val('');
    /*$('#ddlDoiTuongUuTien').val('');*/
    $('#ddlGioiTinh').val('');
    $('#ddlDanToc').val('');
    $('#ddlTinhThuongTru').val('');
    $('#ddlHuyenThuongTru').val('');
    $('#ddlXaThuongTru').val('');
    $('#txtDiaChiThuongTru').val('');
    $('#ddlTinhTamTru').val('');
    $('#ddlHuyenTamTru').val('');
    $('#ddlXaTamTru').val('');
    $('#txtDiaChiTamTru').val('');
    $('#txtTenNguoiGiamHo').val('');
    $('#txtEmailNguoiGiamHo').val('');
    $('#txtSoDienThoaiLienHe').val('');
    $('#txtNgheNghiep').val('');
    $('#txtTenMe').val('');
    $('#txtTenBo').val('');
    $('#txtNgheNghiepMe').val('');
    $('#txtSoDienThoaiMe').val('');
    $('#txtNgheNghiepBo').val('');
    $('#txtSoDienThoaiBo').val('');
    $('#ddlNguyenVong1').val('');
    $('#ddlNguyenVong2').val('');
    $('#uploadFile').val('');

}
//Show hồ sơ mới ra
//function addData() {
//    $('#exampleModal').modal("show");
//    $("#txtLHS").attr("disabled", false);
//    $("#activity input,#activity select").each(function () {
//        $(this).val("");
//        $(this).attr("disabled", false);
//    })
//    $('#hdID').val("0");
//    $("#itemFile").remove();


//}
// Sửa hs
function Edit(id) {
    $('#hideDTUT').show();
    $('#exampleModal').modal("show");
    $.ajax({
        url: '/HoSoDuTuyen/Getdata',
        data: { id: id },
        type: 'Get',
        dataType: 'json',

        success: function (response) {
            if (response.status == true) {

                $('.Checkss').each(function () {
                    let valueCheck = $(this).val();
                    let currentCheck = $(this);
                    $.each(response.idDTUT, function (index, value) {
                        A = value.IdDTUT;
                        if (valueCheck == A) {

                            currentCheck.attr('checked', true);

                        }
                    })

                })
                //$("#txtLHS").attr("disabled", false);
                //$("#activity input,#activity select").each(function () {
                //    $(this).attr("disabled", false);
                //})
                var sex = response.data.GioTinh == true ? "1" : "2";
                $('#hdID').val(response.data.ID);
                $('#txtHoTen').val(response.data.TenHS);
                $('#txtEmail').val(response.data.Email);
                $('#txtNgaySinh').val(response.data.NgaySinh);
                /*$('#ddlDoiTuongUuTien').val(response.data.DTUT);*/
                $('#ddlGioiTinh').val(sex).change();
                $('#ddlDanToc').val(response.data.DanToc).change();
                $('#ddlTinhThuongTru').val(response.data.IDTinhThT).change();
                $('#ddlHuyenThuongTru').val(response.data.IDHuyenThT).change();
                $('#ddlXaThuongTru').val(response.data.IDXaThT);
                $('#txtDiaChiThuongTru').val(response.data.SoNhaThuongTru).change();
                $('#ddlTinhTamTru').val(response.data.IDTinhTT).change();
                $('#ddlHuyenTamTru').val(response.data.IDHuyenTT).change();
                $('#ddlXaTamTru').val(response.data.IDXaTT);
                $('#txtDiaChiTamTru').val(response.data.SoNhaTamTru);
                $('#txtTenNguoiGiamHo').val(response.data.TenNGH);
                $('#txtEmailNguoiGiamHo').val(response.data.Email);
                $('#txtSoDienThoaiLienHe').val(response.data.SDTNGH);
                $('#txtNgheNghiep').val(response.data.NgheNghiepNGH);
                $('#txtTenMe').val(response.data.TenMe);
                $('#txtTenBo').val(response.data.TenBo);
                $('#txtNgheNghiepMe').val(response.data.NgheNghiepMe);
                $('#txtSoDienThoaiMe').val(response.data.SDTMe);
                $('#txtNgheNghiepBo').val(response.data.NgheNghiepBo);
                $('#txtSoDienThoaiBo').val(response.data.SDTBo);
                $('#ddlNguyenVong1').val(response.data.NguyenVong1).change();
                $('#ddlNguyenVong2').val(response.data.NguyenVong2).change();
                $('#uploadFile').val(response.data.files);
                $.each(response.itemFile, function (index, value) {
                    // html = `<p>${value.TenFile}</p>`
                    html =
                          `<div>
                           <a href="/Uploads/File/${value.TenFile} " target="_blank">${value.TenFile} </a>
                          </div>`;
                    $('#itemFile').append(html);
                })


            }
        },

        error: function (err) {
            console.log(err);
        }

    });
}


//nút Đóng
function Close() {
    $.ajax({
        success: function () {
            location.reload();
        },

        error: function (err) {
            console.log(err);
        }

    });
}

// Xem Hs
function seeView(id) {
    $.ajax({
        url: '/HoSoDuTuyen/Getdata',
        data: { id: id },
        type: 'GET',
        dataType: 'json',

        success: function (response) {
            if (response.status == true) {
                $('#exampleModal').modal("show");
                var sex = response.data.GioTinh == true ? "1" : "2";
                $('#hdID').val(response.data.ID);
                $('#txtHoTen').val(response.data.TenHS);
                $('#txtHoTen').attr('disabled', 'disabled');
                $('#txtEmail').val(response.data.Email);
                $('#txtEmail').attr('disabled', 'disabled');
                $('#txtNgaySinh').val(response.data.NgaySinh);
                $('#txtNgaySinh').attr('disabled', 'disabled');
                //$('#ddlDoiTuongUuTien').val(response.data.DTUT);
                $('#ddlDTUT').attr('disabled', 'disabled');
                $('#ddlGioiTinh').val(sex).change();
                $('#ddlGioiTinh').attr('disabled', 'disabled');
                $('#ddlDanToc').val(response.data.DanToc).change();
                $('#ddlDanToc').attr('disabled', 'disabled');
                $('#ddlTinhThuongTru').val(response.data.IDTinhThT).change();
                $('#ddlTinhThuongTru').attr('disabled', 'disabled');
                $('#ddlHuyenThuongTru').val(response.data.IDHuyenThT).change();
                $('#ddlHuyenThuongTru').attr('disabled', 'disabled');
                $('#ddlXaThuongTru').val(response.data.IDXaThT);
                $('#ddlXaThuongTru').attr('disabled', 'disabled');
                $('#txtDiaChiThuongTru').val(response.data.SoNhaThuongTru).change();
                $('#txtDiaChiThuongTru').attr('disabled', 'disabled');
                $('#ddlTinhTamTru').val(response.data.IDTinhTT).change();
                $('#ddlTinhTamTru').attr('disabled', 'disabled');
                $('#ddlHuyenTamTru').val(response.data.IDHuyenTT).change();
                $('#ddlHuyenTamTru').attr('disabled', 'disabled');
                $('#ddlXaTamTru').val(response.data.IDXaTT);
                $('#ddlXaTamTru').attr('disabled', 'disabled');
                $('#txtDiaChiTamTru').val(response.data.SoNhaTamTru);
                $('#txtDiaChiTamTru').attr('disabled', 'disabled');
                $('#txtTenNguoiGiamHo').val(response.data.TenNGH);
                $('#txtTenNguoiGiamHo').attr('disabled', 'disabled');
                $('#txtEmailNguoiGiamHo').val(response.data.Email);
                $('#txtEmailNguoiGiamHo').attr('disabled', 'disabled');
                $('#txtSoDienThoaiLienHe').val(response.data.SDTNGH);
                $('#txtSoDienThoaiLienHe').attr('disabled', 'disabled');
                $('#txtNgheNghiep').val(response.data.NgheNghiepNGH);
                $('#txtNgheNghiep').attr('disabled', 'disabled');
                $('#txtTenMe').val(response.data.TenMe);
                $('#txtTenMe').attr('disabled', 'disabled');
                $('#txtTenBo').val(response.data.TenBo);
                $('#txtTenBo').attr('disabled', 'disabled');
                $('#txtNgheNghiepMe').val(response.data.NgheNghiepMe);
                $('#txtNgheNghiepMe').attr('disabled', 'disabled');
                $('#txtSoDienThoaiMe').val(response.data.SDTMe);
                $('#txtSoDienThoaiMe').attr('disabled', 'disabled');
                $('#txtNgheNghiepBo').val(response.data.NgheNghiepBo);
                $('#txtNgheNghiepBo').attr('disabled', 'disabled');
                $('#txtSoDienThoaiBo').val(response.data.SDTBo);
                $('#txtSoDienThoaiBo').attr('disabled', 'disabled');
                $('#ddlNguyenVong1').val(response.data.NguyenVong1).change();
                $('#ddlNguyenVong1').attr('disabled', 'disabled');
                $('#ddlNguyenVong2').val(response.data.NguyenVong2).change();
                $('#ddlNguyenVong2').attr('disabled', 'disabled');
                $('#uploadFile').val(response.data.files);
                $('#uploadFile').attr('disabled', 'disabled');
                $(':input[type=submit]').prop('disabled', true);
                //xem đối tượng ưu tiên
                $.each(response.idDTUT, function (index, value) {
                    html = `<p>${value.KieuDoiTuongUuTien}</p>`
                    $('#iddTUT').append(html);
                })

                $.each(response.itemFile, function (index, value) {
                    // html = `<p>${value.TenFile}</p>`
                    html =
                        ` <div>
                        <a href="/Uploads/File/${value.TenFile} " target="_blank">${value.TenFile} </a>
                    </div>`;
                    $('#itemFile').append(html);
                })


            }

        },

        error: function (err) {
            console.log(err);
        }

    });

}

// Tìm kiếm hs dự tuyển
function Search() {
    var search = $('#txtSearch').val();
    location.href = '/Admin/HoSoDuTuyen/Index?search=' + search;
}

//dùng nút enter
function runSearch(event) {
    if (event.keyCode == 13) {
        var search = $('#txtSearch').val();
        location.href = '/Admin/HoSoDuTuyen/Index?search=' + search;
        return false;
    }
    return true;
}
//Tìm kiếm hs xét tuyển
function SearchXT() {
    var searchss = $('#txtSearchs').val();
    location.href = '/Admin/HoSoXetTuyen/Index?searchss=' + searchss;
}

//Duyệt
function Browser(id) {
    let result = confirm('Bạn có muốn duyệt hồ sơ')
    if (result == true) {
        $.ajax({
            url: '/HoSoDuTuyen/Brower',
            data: { id: id },
            type: 'GET',
            dataType: 'json',

            success: function (response) {

                if (response.status == true) {

                    location.reload();
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    }

}

//check all + thay click va change
$('#checkall').click(function () {
    if (this.checked) {
        $('.Checks').each(function () {
            this.checked = true;
        });
    } else {
        $('.Checks').each(function () {
            this.checked = false;
        });
    }
});

$('.Checks').click(function () {
    var ischeck = 0
    $('.Checks').each(function () {
        if ($(this).is(':checked') == false) {
            $("#checkall").prop('checked', false);
            ischeck = ischeck + 1;
        }
    })
    if (ischeck == 0) {
        $("#checkall").prop('checked', true);
    }
})





//Hàm duyệt nhiều hs 1 lúc
function BrowserAll() {
    $('.Checks').each(function () {
        if ($(this).is(':checked') == true) {
            let ketqua = confirm("Bạn có muốn duyệt những hồ sơ này không");
            if (ketqua) {
                var array = [];
                $("#tableAll tr input[type=checkbox]").each(function () {
                    if ($(this).is(":checked")) {
                        let idBrowser = $(this).val();
                        array.push(parseInt(idBrowser));
                    }
                });
                var dataString = JSON.stringify(array);
                $.ajax({
                    type: "POST",
                    url: '/HoSoDuTuyen/DuyetAll',
                    dataType: "json",
                    data: { dataString: dataString },

                    success: function (response) {

                        if (response.status == true) {

                            location.reload();
                        }
                        else {
                            return false;
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }

                })
            } else {
                return false;
            }
        }
    });


}

function DoiTuongUT() {
    var x = document.getElementById("hideDTUT");
    if (x.style.display == "none") {
        x.style.display = "block";

    } else {
        x.style.display = "none";
    }

}

