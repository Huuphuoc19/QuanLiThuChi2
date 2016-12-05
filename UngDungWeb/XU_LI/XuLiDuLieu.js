

ungDungQuanLiThuChi.controller("thongKeController", function ($scope, danhSachThongKeNam, XuLiXML,XuLiLuuTru)
{

    var vm = this;
    vm.idGiaDinh = 3;
    vm.idThuChiChung = 35;
    // lay danh sach thong ke nam tu server thog qua lop xu li luu tru
    var danhSachThongKeNamXML = XuLiXML.phanTichChuoiTuWebseriveThanhString(danhSachThongKeNam);
    if (danhSachThongKeNamXML) {
        vm.thuChiNam = XuLiXML.taoMangObjectJSTuXMLElement(danhSachThongKeNamXML);
    }
    vm.thuChiThang = [];
    vm.thuChiThanhVienNam = [];
    vm.hienThiThongKeThang = function (nam, $event) {
        vm.thongTinThongKe = "(" + nam + ")";
        // lay thong ke thang theo nam
        XuLiLuuTru.layDanhSachThongKeThang(nam)
            .then(function (data) {
                var danhSachThongKeThangXML = XuLiXML.phanTichChuoiTuWebseriveThanhString(data);
                if (danhSachThongKeThangXML) {
                    vm.thuChiThang = XuLiXML.taoMangObjectJSTuXMLElement(danhSachThongKeThangXML);
                }
            });
        
        XuLiLuuTru.layDanhSachThongKeThanhVienTheoNam(nam, vm.idGiaDinh)
            .then(function (data) {              
                var dsThongKeThuChiThanhVien = XuLiXML.phanTichChuoiTuWebseriveThanhString(data);
                if (dsThongKeThuChiThanhVien) {
                    vm.thuChiThanhVien = XuLiXML.taoMangObjectJSTuXMLElement(dsThongKeThuChiThanhVien);
                }
            });
    
    }

    vm.hienThiThongKeThanhVienTheoThang = function (nam, thang, $event) {
        vm.thongTinThongKe = "(" + thang + "/" + nam + ")";
        XuLiLuuTru.layDanhSachThongKeThanhVienTheoThang(nam, thang, vm.idGiaDinh)
            .then(function (data) {
                var dsThongKeThuChiThanhVien = XuLiXML.phanTichChuoiTuWebseriveThanhString(data);
                if (dsThongKeThuChiThanhVien) {
                    vm.thuChiThanhVien = XuLiXML.taoMangObjectJSTuXMLElement(dsThongKeThuChiThanhVien);
                }
            });
    };

});

ungDungQuanLiThuChi.controller("thuController", function ($scope, dateFilter, danhSachThanhVien, XuLiXML, XuLiLuuTru, XuLiHienThi) {
    var vm = this;
    var danhSachThanhVienXML = XuLiXML.phanTichChuoiTuWebseriveThanhString(danhSachThanhVien);
    if (danhSachThanhVienXML) {
        vm.thanhVien = XuLiXML.taoMangObjectJSTuXMLThanhVien(danhSachThanhVienXML);
    }
    // set mac dinh cho select box
    vm.sele
    vm.soTien = "";
    vm.ngayThang = "";
    vm.ghiChu = "";
    vm.selectedThanhVien = "";
    var duLieuThem = {};
    vm.themThuChi = function () {
        
        vm.messages = [];
        if (vm.selectedThanhVien == "" || vm.soTien == "" || vm.ngayThang == "") {
            vm.messages = ["Vui lòng nhập đầy đủ dữ liệu"];
        } else {
            if (XuLiHienThi.isNumber(vm.soTien) == "") {
                vm.messages = ["Số tiền phải là số"];
                return;
            }
            //<Data><ThuChi SoTien="" NgayThuChi="" LoaiThuChi="" GhiChu="" IdThanhVien="" /></Data>"
            var doiTuongThu = {
                SoTien: vm.soTien,
                NgayThuChi: dateFilter(vm.ngayThang, "dd/MM/yyyy"),
                LoaiThuChi: "Thu",
                GhiChu: vm.ghiChu,
                IdThanhVien: vm.selectedThanhVien
            }
            var chuoiDuLieuThuChi = XuLiXML.taoChuoiTuObject(doiTuongThu,"ThuChi");
            
            XuLiLuuTru.themKhoanThuChi(chuoiDuLieuThuChi)
                .then(function (data) {
                    var error = XuLiXML.kiemTraChuoiLoi(data);
                    if (error == null) {
                        vm.messages = ["Thêm thành công"];
                    } else {
                        vm.messages = ["Đã có lỗi xảy ra, vui lòng thử lại"];
                    }
                }, function (error) {
                    vm.messages = ["Đã có lỗi xảy ra, vui lòng thử lại"];
                });
        }
    }
});

ungDungQuanLiThuChi.controller("chiController", function ($scope, dateFilter, danhSachThanhVien, XuLiXML, XuLiLuuTru, XuLiHienThi) {
    var vm = this;
    var danhSachThanhVienXML = XuLiXML.phanTichChuoiTuWebseriveThanhString(danhSachThanhVien);
    vm.thanhVien = XuLiXML.taoMangObjectJSTuXMLThanhVien(danhSachThanhVienXML);
    // set mac dinh cho select box
    vm.sele
    vm.soTien = "";
    vm.ngayThang = "";
    vm.ghiChu = "";
    vm.selectedThanhVien = "";
    var duLieuThem = {};
    vm.messages = [];
    vm.themThuChi = function () {
        vm.messages = [];
        if (vm.selectedThanhVien == "" || vm.soTien == "" || vm.ngayThang == "") {
            vm.messages = ["Vui lòng nhập đầy đủ dữ liệu"];
        } else {
            if (XuLiHienThi.isNumber(vm.soTien) == "") {
                vm.messages = ["Số tiền phải là số"];
                return;
            }

            //<Data><ThuChi SoTien="" NgayThuChi="" LoaiThuChi="" GhiChu="" IdThanhVien="" /></Data>"
            var doiTuongThu = {
                SoTien: vm.soTien,
                NgayThuChi: dateFilter(vm.ngayThang, "dd/MM/yyyy"),
                LoaiThuChi: "Chi",
                GhiChu: vm.ghiChu,
                IdThanhVien: vm.selectedThanhVien
            }
            var chuoiDuLieuThuChi = XuLiXML.taoChuoiTuObject(doiTuongThu,"ThuChi");

            XuLiLuuTru.themKhoanThuChi(chuoiDuLieuThuChi)
                .then(function (data) {
                    var error = XuLiXML.kiemTraChuoiLoi(data);
                    if (error == null) {
                        vm.messages = ["Thêm thành công"];
                    } else {
                        vm.messages = ["Đã có lỗi xảy ra, vui lòng thử lại"];
                    }
                }, function (error) {
                    vm.messages = ["Đã có lỗi xảy ra, vui lòng thử lại"];
                });
        }
    }
});

ungDungQuanLiThuChi.controller("timkiemController", function ($scope, XuLiXML, XuLiLuuTru, XuLiHienThi) {
    var vm = this;
    // khoi tao bien
    vm.idGiaDinh = 3;
    vm.idThuChiChung = 35;
    //
    vm.thanhVien = "";
    vm.soTien = "";
    vm.ngay = "";
    vm.thang = "";
    vm.loaiThuChi = "";
    vm.ketQuaTimKiem = "";
    vm.messages = [];
    vm.timKiem = function () {
        vm.messages = [];
        if (vm.thanhVien == "" && vm.soTien == "" && vm.ngay == "" && vm.thang == "" && vm.loaiThuChi == "") {
            vm.messages.push("Vui lòng nhập ít nhất một trường");
        } else {
            var flag = false;
            var tamSoTien = XuLiHienThi.isNumber(vm.soTien);
            var tamNgay = XuLiHienThi.isValidDate(vm.ngay);
            var tamThang = XuLiHienThi.isValidMonth(vm.thang);
            var tamThuChi = XuLiHienThi.isChungRieng(vm.loaiThuChi);
            // kiem tra input hop le
            // so tien khac rong va khng phai la so
            if (vm.soTien != "" && tamSoTien == "") {
                vm.messages.push("Số tiền phải là số !");
                flag = true
            }
            // ngay khac rong va ngay khong hop le
            if (vm.ngay != "" && tamNgay == "") {
                vm.messages.push("Ngày với định dạng dd/MM/yyyy !");
                flag = true
            }
            if (vm.thang != "" && tamThang == "") {
                vm.messages.push("Tháng với định dạng MM/yyyy !");
                flag = true
            }
            if (vm.loaiThuChi != "" && tamThuChi == "") {
                vm.messages.push("Loại thu chi là chung hoặc riêng");
                flag = true
            }

            // neu vo pham ==> return
            if (flag) {
                return;
            }
            //<Data><DuLieuTimKiem HoTen="" SoTien="" Ngay="" Thang="" ChungRieng="" IdChungRieng="" IdGiaDinh="">
            var doiTuongTimKiem = {
                HoTen: vm.thanhVien,
                SoTien: tamSoTien,
                Ngay: tamNgay,
                Thang: tamThang,
                ChungRieng: tamThuChi,
                IdChungRieng: vm.idThuChiChung,
                IdGiaDinh: vm.idGiaDinh
            }
            var chuoiTimKiem = XuLiXML.taoChuoiTuObject(doiTuongTimKiem, "DuLieuThuChi");
            dump(chuoiTimKiem);
            XuLiLuuTru.timKiem(chuoiTimKiem)
                .then(function (data) {
                    var ketQua = XuLiXML.phanTichChuoiTuWebseriveThanhString(data);
                    if (ketQua) {
                        vm.ketQuaTimKiem = XuLiXML.taoMangObjectJSTuXMLElement(ketQua);
                    }
                }, function (error) {
                    dump(error);
                });
        }
        dump("Message:");
        dump(vm.messages);
    }

    // tim kiem tung tieu chi
    vm.timKiemTheoThuocTinh = function ($event) {
        // neu vu nhan phim enter
        if ($event.charCode == 13 || $event.keyCode == 13 || $event.key == "Enter") {
            vm.timKiem();
        }
    }

    vm.resetForm = function () {
        vm.thanhVien = "";
        vm.soTien = "";
        vm.ngay = "";
        vm.thang = "";
        vm.loaiThuChi = "";
        vm.ketQuaTimKiem = "";       
    }
});