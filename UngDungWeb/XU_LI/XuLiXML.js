/// <reference path="XuLiDuongDan.js" />
ungDungQuanLiThuChi.factory("XuLiXML", function () {

    var idGiaDinh = 1;
    var idThuChiChung = 1;
    var THU_CHI_CHUNG = "THU CHI CHUNG";
    var parser = new DOMParser();

    return {

        // xu li chuoi xml nhan tu server webservice
        phanTichChuoiTuWebseriveThanhString: function (chuoiDuLieu) {
            var parser = new DOMParser();
            var elementTam = parser.parseFromString(chuoiDuLieu, "text/xml");
            //<string xmlns
            var firstChildTam  = elementTam.firstChild;
            // neu  co du lieu
            if (firstChildTam) {
                // <dataset>
                var chuoiThucSu = firstChildTam.firstChild;
                if (chuoiThucSu) {
                    var elementThucSu = parser.parseFromString(chuoiThucSu.nodeValue, "text/xml");
                    if (elementThucSu.firstChild)
                        return elementThucSu.firstChild;
                }
            }
            return false;
        },

        // kiemTraChuoiLoi
        kiemTraChuoiLoi: function(dataError){
            var parser = new DOMParser();
            var elementTam = parser.parseFromString(dataError, "text/xml");
            //<string xmlns
            var firstChildTam = elementTam.firstChild;
            // neu  co du lieu
            if (firstChildTam) {
                // <dataset>
                var chuoiThucSu = firstChildTam.firstChild;
                if (chuoiThucSu) {
                    return chuoiThucSu;
                }
            }
            return null;
        },
        // tao mot mang object js tu xml
        taoMangObjectJSTuXMLThanhVien: function (xmlElement) {
            
            var dsNodeCon = xmlElement.childNodes;          
            var soCon = dsNodeCon.length;
            var kq = [];
            (function () {
                for (var i = 0 ; i < soCon ; i++) {
                    var node = dsNodeCon[i];
                    var idTam = node.getAttribute("ID");
                    var hoTenTam = (idTam == idThuChiChung) ? THU_CHI_CHUNG : node.getAttribute("HoTen");
                    var thanhVien = {
                        Id: idTam,
                        HoTen: hoTenTam,
                        IdGioiTinh: node.getAttribute("IdGioiTinh"),
                        NgaySinh: node.getAttribute("NgaySinh"),
                        IdGiaDinh: node.getAttribute("IdGiaDinh")
                    }
                    kq[i] = thanhVien;
                }
            })();
            return kq;
        },

        // tao mot mang object js tu xml
        taoMangObjectJSTuXMLElement: function (xmlElement) {
            var dsNodeCon = xmlElement.childNodes;
            var soCon = dsNodeCon.length;            
            var kq = [];
            (function () {
                for (var i = 0 ; i < soCon ; i++) {
                    var attrs = dsNodeCon[i].attributes;
                    var tempObj = {};
                    var soAtrribute = attrs.length;
                    (function () {                      
                        for (var j = 0 ; j < soAtrribute ; j++) {                       
                            tempObj[attrs[j].nodeName] = attrs[j].nodeValue;
                        }
                    })();
                    kq[i] = tempObj;
                }
            })();
            return kq;
        },

        // tao chuoi thu chi thu object js
        taoChuoiTuObject: function (obj,tenChuoi) {
            var doc = parser.parseFromString("<Data></Data>", "text/xml");
            var root = doc.documentElement;
            var child = doc.createElement(tenChuoi);
            for (var thuocTinh in obj) {
                child.setAttribute(thuocTinh, obj[thuocTinh]);
            }
            root.appendChild(child);
            return root.outerHTML;
        },

    }
});