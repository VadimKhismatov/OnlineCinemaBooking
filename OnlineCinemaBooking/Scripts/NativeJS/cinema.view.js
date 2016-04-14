function CinemaView() {
	var self = this;
	var service = new cinemaService();
	self.init = init;
	self.render = render;
	self.renderSeats = renderSeats;

	var db;

	var selectedSeats = [];

	//функция init запускает функцию get которая осылает запрос на сервер для получение исходных данных
	function init() {

		service.get(function (data) {
			db = data;
			render();
		});

	};

	function render() {

		var container = document.getElementsByClassName('container')[0];
		var button = document.getElementById('purchase-button');

		var wrapper = document.createElement('div');
		wrapper.className = "wrapper";
		container.insertBefore(wrapper, container.children[1]);

		var side_left = document.createElement('div');
		side_left.className = "side rows";

		var side_right = document.createElement('div');
		side_right.className = "side rows";

		var center = document.createElement('div');
		center.className = 'center';

		wrapper.appendChild(side_left);
		wrapper.appendChild(side_right);
		wrapper.insertBefore(center, wrapper.children[1]);

		//console.log('rowsData before. ', db);

		//var rowsData = db.rows; // массив в который будут сохранен массив с количеством рядов и мест из объекта data

		//console.log('rowsData after. ',db.rows);

		//переменные в которые будет записан HTML для каждой из боковых панелей с рядами
		var sourceLeft = "";
		var sourceRight = "";

		for (var i = db.rows.length; i > 0; i--) {

			sourceLeft += "<div class=\"caption left\">Ряд " + i + "</div>";
			sourceRight += "<div class=\"caption right\">Ряд " + i + "</div>";
		}

		side_left.innerHTML = sourceLeft;
		side_right.innerHTML = sourceRight;


		//обработчик события который изменяет статутс выбраного места на забронированный и наоборот.

		center.addEventListener("click", select, false);

		//обработчик события кнопки который запускает функцию purchase
		button.addEventListener("click", purchase, false);

		renderSeats();
	};

	//функция отрисовки мест
	function renderSeats() {

		var wrapper = document.getElementsByClassName('wrapper')[0];
		var center = document.getElementsByClassName('center')[0];
		center.innerHTML = '';
		var rowsData = db.rows;



		var rows = document.createElement("div");
		rows.className = "rows";
		center.appendChild(rows);

		for (var i = rowsData.length - 1; 0 <= i ; i--) {

			var row = rowsData[i];

			var html = "";

			var elementRow = document.createElement('div');
			elementRow.className = "row";
			elementRow.setAttribute("data-row", i);
			rows.appendChild(elementRow);

			for (var j = 0; j < row.length; j++) {

				var seat = row[j];

				if (seat.status === 1) {

					html += "<div class=\"seat purchased\" data-seat = " + j + ">" + seat.name + "</div>";

				} else if (seat.status === 2) {

					html += "<div class=\"seat selected\" data-seat = " + j + ">" + seat.name + "</div>";

				} else if (seat.status === 3) {

					html += "<div class=\"seat booked\" data-seat = " + j + ">" + seat.name + "</div>";
				} else {

					html += "<div class=\"seat\" data-seat = " + j + ">" + seat.name + "</div>";

				}

			}

			elementRow.innerHTML = html;
		}

	};

	//функция выбора мест
	function select(e) {

		var center = document.getElementsByClassName('center')[0];

		var parent = e.target.parentElement;

		var rowIndex = parent.getAttribute('data-row');
		//console.log("row", rowNumber);

		var seatIndex = e.target.getAttribute('data-seat');

		var selectedIndex = rowIndex + seatIndex;
		//console.log("var selectedIndex", selectedIndex);


		var seat = db.rows[rowIndex][seatIndex];

		//в этом if идет проверка статуса места, если оно куплено то оно будет не доступно для выбора и броннирования.

		if (seat.status == 1 || seat.status == 3) return;


		//console.log("befor",selectedSeats);
		//console.log(' selectedSeat index', selectedSeats[selectedIndex]);

		if (selectedIndex == selectedSeats[selectedIndex]) {

			var seat = db.rows[rowIndex][seatIndex];

			seat.status = 0;

			delete selectedSeats[selectedIndex];

			center.innerHTML = '';

			renderSeats();

		} else {

			//в массив selectedSeats добавляется по индексу(selectedIndex) который создается из номеров ряда и места, ряд и место, сам же массив имеет вид array like object

			selectedSeats[selectedIndex] = selectedIndex;
			console.log("after", selectedSeats);

			var seat = db.rows[rowIndex][seatIndex];

			seat.status = 2;

			center.innerHTML = '';

			renderSeats();
		}

		//console.log('rowsData click.');

		//console.log("purchasedSeats", purchasedSeats);

	};

	//в функции purchase происходит проход по массиву(объекту) с выбранными местами и сохранение id тех мест которые были выбраны и запись всех id в массив ids, после чего вызывается
	//функция buy в которую передается массив ids для последующей отправки на сервер.
	function purchase() {

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

		service.buy(ids, function (data) {

			db = data;
			renderSeats();
		});



	};
};

var view = new CinemaView();
window.onload = view.init();