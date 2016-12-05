/// <reference path="XuLiLuuTru.js" />
ungDungQuanLiThuChi.factory("XuLiHienThi", function () {
    return {
        // kiem tra ngay hop le theo dinh dang MM/dd/yyyy
        isValidDate: function (text) {
            var regex = /^(0[1-9]|1\d|2\d|3[01]|[1-9])\/(0[1-9]|1[0-2]|[1-9])\/(19|20)\d{2}$/;
            if (!regex.test(text)) {
                return "";
            }
            var stringDateTam = text.split("\/");
            var dateNumber = Date.parse(stringDateTam[1] + "\/" + stringDateTam[0] + "\/" + stringDateTam[2]);
            if (dateNumber == NaN) {
                return "";
            }
            var fullDate = new Date(dateNumber);
            if (fullDate == "Invalid Date") {
                return "";
            }
            var date = fullDate.getDate();
            var month = fullDate.getMonth() + 1;
            var year = fullDate.getFullYear();
            if (date == stringDateTam[0] && month == stringDateTam[1]) {
                return date + "\/" + month + "\/" + year;
            }
            return "";

        },

        // MM/yyyy
        isValidMonth: function (text){
            var regex = /^(0[1-9]|1[0-2]|[1-9])\/(19|20)\d{2}$/;
            if(!regex.test(text)){
                return "";
            }
            return text.replace("\/","\:");
        },

        // kiem tra la so
        isNumber: function (text){
            var regex = /^[0-9]{1,10}$/;
            if(!regex.test(text)){
                return "";
            }
            return text;
        },
        // nhap chung rieng
        isChungRieng: function (text) {
            var textTemp = text.toLowerCase();
            var regex = /^(chung|riêng)$/;
            if(!regex.test(textTemp)){
                return "";
            }
            return textTemp;
        }
    }
})