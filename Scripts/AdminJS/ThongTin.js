function ChangeddlTinhA(check) {
    if (check == 0) {
        var idTinh = $('#ddlTinhThuongTru').val();
        $.ajax({
            url: '/DK_du_tuyen/ChangeTinh',
            data: {
                id: idTinh
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var html = '';
                    $.each(response.data, function (i,item) {
                        html += "<option value= " + item.ID + ">" + item.TenDiaChi + "</option>";
                    });
                    $('#ddlHuyenThuongTru').html(html);
                }
                else {
                }
            },
            error: function (err) {
                console.log(err);
            }
        });


    } else if (check == 1) {
        var idTinh = $('#ddlTinhTamTru').val();
        $.ajax({
            url: '/DK_du_tuyen/ChangeTinh',
            data: {
                id: idTinh
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var html = '';
                    $.each(response.data, function (i, item) {
                        html += "<option value= " + item.ID + ">" + item.TenDiaChi + "</option>";
                    });
                    $('#ddlHuyenTamTru').html(html);
                    
                }
                else {
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

}

function ChangeddlHuyenA() {

    var idHuyen = $('#ddlHuyenThuongTru').val();
    $.ajax({
        url: '/DK_du_tuyen/ChangeHuyen',
        data: {
            id: idHuyen
        },
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                var html = '';
                $.each(response.data, function (i, item) {
                    html += "<option value=" + item.ID + ">" + item.TenDiaChi + "</option>";
                });
                $('#ddlXaThuongTru').html(html);
            }
            else {
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function ChangeddlHuyenB() {

    var idHuyen = $('#ddlHuyenTamTru').val();
    $.ajax({
        url: '/DK_du_tuyen/ChangeHuyen',
        data: {
            id: idHuyen
        },
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                var html = '';
                $.each(response.data, function (i, item) {
                    html += "<option value=" + item.ID + ">" + item.TenDiaChi + "</option>";
                });
                $('#ddlXaTamTru').html(html);
            }
            else {
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function ChangeddlTruong() {
    var idTruong = $('#ddlNguyenVong1').val();
    $.ajax({
        url: '/DK_du_tuyen/ChangeTruong',
        data: {
            id:idTruong
        },
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                var html = '';
                $.each(response.data, function (i, item) {
                    html += "<option value= " + item.ID + ">" + item.Tentruong + "</option>";
                });
                $('#ddlNguyenVong2').html(html);
            }
        },
        error: function (err) {
            console.log(err);
        }

    });
}
