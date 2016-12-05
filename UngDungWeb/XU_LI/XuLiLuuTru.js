/// <reference path="D:\VisualStudio\QuanLiThuChiService\UngDungWeb\js/angular.min.js" />

var ungDungQuanLiThuChi = angular.module("UngDungQuanLiThuChi", ["ui.router"]);

function dump(a) {
    console.log(a);
}

ungDungQuanLiThuChi.factory("XuLiLuuTru", function ($http, $q) {
    return {
        // nay danh sach thanh vien tu server
        layDanhSachThanhVien: function () {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/layDanhSachThanhVien",
                headers: {
                    "Accept": "application/xml",
                    "Content-Type": "application/xml",
                },
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        // them khoan thu chi
        themKhoanThuChi: function (chuoiThuChi) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/themKhoanThuChi",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded",
                },
                params: {
                    chuoiDuLieuThuChi: encodeURIComponent(chuoiThuChi)
                }
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        //

        // lay thong ke nam tu server
        layDanhSachThongKeNam: function (offset,limit) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/thongKeTheoNam",
                headers: {
                    "Content-Type": "application/xml",
                },
                params: {
                    offset: offset,
                    limit: limit
                }
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        //

        // lay thong ke thang tu server
        layDanhSachThongKeThang: function (nam) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/thongKeTheoThang",
                headers: {
                    "Content-Type": "application/xml",
                },
                params: {
                    nam: nam
                }
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        //

        // lay thong ke thang tu server
        layDanhSachThongKeThanhVienTheoNam: function (nam,idGiaDinh) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/thongKeThanhVienTheoNam",
                headers: {
                    "Content-Type": "application/xml",
                },
                params: {
                    nam: nam,
                    idGiaDinh: idGiaDinh
                }
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        //

        // lay thong ke thang tu server
        layDanhSachThongKeThanhVienTheoThang: function (nam,thang, idGiaDinh) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/thongKeThanhVienTheoThang",
                headers: {
                    "Content-Type": "application/xml",
                },
                params: {
                    nam: nam,
                    thang: thang,
                    idGiaDinh: idGiaDinh
                }
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        //

        // lay thong ke thang tu server
        timKiem: function (chuoiDuLieuTimKiem) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "http://localhost:59644/XuLiDichVu.asmx/timKiem",
                headers: {
                    "Content-Type": "application/xml",
                },
                params: {
                    chuoiXmlDuLieuTimKiem: encodeURIComponent(chuoiDuLieuTimKiem)
                }
            }).then(function (response) {
                deferred.resolve(response.data);
            }, function (error) {
                deferred.reject(error.data);
            });
            return deferred.promise;
        },
        //
    }
});
