/// <reference path="D:\VisualStudio\QuanLiThuChiService\UngDungWeb\js/angular.min.js" />
/// <reference path="D:\VisualStudio\QuanLiThuChiService\UngDungWeb\js/angular-ui-router.min.js" />
/// <reference path="XuLiLuuTru.js" />

ungDungQuanLiThuChi.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise("/thongke");
    $locationProvider.html5Mode(true);
    // xu li duong dan cho menu
    $stateProvider
    .state("thongke", {
        url: "/thongke",
        templateUrl: "templates/thongke.htm",
        controller: "thongKeController",
        controllerAs: "thongKeCtrl",
        // 
        resolve: {
            danhSachThongKeNam: function (XuLiLuuTru) {
                return XuLiLuuTru.layDanhSachThongKeNam(0,5)
                        .then(function (data) {
                            return data;
                        });
            },
        }
    })
    .state("thu", {
        url: "/thu",
        templateUrl: "templates/thu.htm",
        controller: "thuController",
        controllerAs: "thuCtrl",
        // 
        resolve: {
            // lay danh sach thanh vien tu xi lu luu tru
            danhSachThanhVien: function (XuLiLuuTru) {
                return XuLiLuuTru.layDanhSachThanhVien()
                        .then(function (data) {
                            return data;
                        });
            },
        }
    })
    .state("chi", {
        url: "/chi",
        templateUrl: "templates/chi.htm",
        controller: "chiController",
        controllerAs: "chiCtrl",
        // du
        resolve: {
            // lay danh sach thanh vien tu xi lu luu tru
            danhSachThanhVien: function (XuLiLuuTru) {
                return XuLiLuuTru.layDanhSachThanhVien()
                        .then(function (data) {
                            return data;
                        });
            },
        }
    })
    .state("timkiem", {
        url: "/timkiem",
        templateUrl: "templates/timkiem.htm",
        controller: "timkiemController",
        controllerAs: "timkiemCtrl",
    });
    //
});