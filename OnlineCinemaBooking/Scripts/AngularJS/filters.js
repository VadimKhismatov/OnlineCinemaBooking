/// <reference path="cinema.controller.js" />
var cinemaApp = cinemaApp || angular.module("cinemaApp", []);

//фильтр принимает параметр status места и возвращает соответствующий класс css.
cinemaApp.filter("status", function () {
    return function (status) {
        //console.log(status);
        switch (status) {
            case 0:
                return "seat";
            case 1:
                return "seat purchased";
            case 2:
                return "seat selected";
            case 3:
                return "seat booked";

        }
    }

});