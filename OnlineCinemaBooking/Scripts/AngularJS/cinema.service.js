/// <reference path="cinema.view.js" />
var cinemaApp = cinemaApp || angular.module("cinemaApp", []);

cinemaApp.factory("getData", function ($http) {
    

    return {
        get: function (callback) {
            $http.get("/OnlineCinemaBooking/api/cinema/get")
                .success(callback);
        },
        post: function (ids,callback) { 
            $http.post("/OnlineCinemaBooking/api/cinema/buy", ids)
                .success(callback);
        }

    }
});