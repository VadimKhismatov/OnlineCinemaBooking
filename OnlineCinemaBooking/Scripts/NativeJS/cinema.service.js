function cinemaService() {

	var self = this;
	self.get = get;
	self.buy = buy;


	//функция get посылает запрос на сервер для получения исходных данных(рядов и мест) 
	function get(callback) {

		var request = new XMLHttpRequest();

		request.open("GET", "/OnlineCinemaBooking/api/cinema/get");



		request.onreadystatechange = function () {

			if (request.readyState == 4) {
				if (request.status == 200) {
					var data = JSON.parse(request.responseText);

					if (typeof callback === 'function')
						callback(data);
				}
			}
		};

		request.send();

	}

	//функция buy посылает на сервер данные в JSON формате в котором хранятся id забранированных мест. 
	function buy(ids, callback) {

		var data = JSON.stringify(ids);
		console.log("JSON data", data);

		var request = new XMLHttpRequest();

		request.open("POST", "/OnlineCinemaBooking/api/cinema/buy", true);
		request.setRequestHeader("Content-Type", "application/json");

		request.onreadystatechange = function () {

			if (request.readyState != 4) return

			if (request.status == 200) {

				var data = JSON.parse(request.responseText);

				if (typeof callback === "function") callback(data);
			}

		};

		request.send(data);


	}
}
