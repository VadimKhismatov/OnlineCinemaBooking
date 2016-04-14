/// <reference path="../libs/angular.js" />
/// <reference path="cinema.service.js" />



var cinemaApp = cinemaApp || angular.module("cinemaApp", []);


cinemaApp.controller("homeCtrl", ["$scope","getData", function ($scope, getData) {

    var vm = this;

    var db;
    var selectedSeats = [];


    getData.get(function (data) {
        console.log(data);
        db = data;

        render();
    });

    

    //функция отрисовки рядов
    function render() {
         
        vm.rows = db.rows.reverse();
        console.log("vm rows",vm.rows);    
    };



    $scope.select = function (e) {

        var rowIndex = e.target.parentElement.getAttribute('data-row');
        var seatIndex = e.target.getAttribute('data-seat');

        var selectedIndex = rowIndex + seatIndex;

        //console.log("data-row ", rowIndex);
        //console.log("data-seat ", seatIndex);

        var seat = db.rows[rowIndex][seatIndex];

        if (seat.status == 1 || seat.status == 3) return;


        if (selectedIndex == selectedSeats[selectedIndex]) {

            var seat = db.rows[rowIndex][seatIndex];

            seat.status = 0;

            delete selectedSeats[selectedIndex];

        } else {

            //в массив selectedSeats добавляется по индексу(selectedIndex) который создается из номеров ряда и места, ряд и место, сам же массив имеет вид array like object

            selectedSeats[selectedIndex] = selectedIndex;
            console.log("after", selectedSeats);

            var seat = db.rows[rowIndex][seatIndex];

            seat.status = 2;

        }
        
    }


    $scope.purchase = function () {

        var ids = [];

        for (var key in selectedSeats) {

            var index = selectedSeats[key];
            console.log("index", index);

            var rowIndex = index.substr(0, 1);
            console.log("row Index", rowIndex);

            var seatIndex = index.substr(1, 1);
            console.log("seat Index", seatIndex);

            //console.log("db row", db.rows[rowIndex][seatIndex]);

            var seat = db.rows[rowIndex][seatIndex];
            console.log("seat", seat.id);
            ids.push(seat.id);
        };

        console.log("ids data to send", ids);

        getData.post(ids, function (data) {
            db = data;
            render();
        })


    };
}]);


