using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OnlineCinemaBooking.Controllers
{
	public class CinemaController : ApiController
	{
		// api/cinema
		public IHttpActionResult Get()
		{
			var cache = HttpContext.Current.Cache;

			var data = cache["Items"] as IList<Seat>[];
			if(data == null)
			{
				data = GetCinemaData();
				cache["Items"] = data;
			}

			return Json(new { rows = data }, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
		}

		// api/cinema/buy
		[HttpPost]
		public IHttpActionResult Buy(int[] selected)
		{
			var cache = HttpContext.Current.Cache;

			var data = cache["Items"] as IList<Seat>[];
			if(data == null)
			{
				data = GetCinemaData();
				cache["Items"] = data;
			}

			var items = data.SelectMany(c => c)
				.Where(seat => selected.Contains(seat.Id))
				.ToArray();

			Array.ForEach(items, delegate(Seat item) { item.Status = SeatStatus.Sold; });

			return Json(new { rows = data }, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
		}


		private IList<Seat>[] GetCinemaData()
		{
			var random = new Random();

			var data = new[] {
				
                #region row 1
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Sold
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Booked
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                   

                },

                #endregion
				
				#region row 2
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    
                },

                #endregion
				
				#region row 3
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
					
                },

                #endregion
				
				#region row 4
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
					
                },

                #endregion

				#region row 5
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "8",
                        Status = SeatStatus.Free
                    },
					
                },

                #endregion

				#region row 6
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "8",
                        Status = SeatStatus.Free
                    },
					
                },

                #endregion
				
				#region row 7
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "8",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "9",
                        Status = SeatStatus.Free
                    }
                    },

                #endregion

				#region row 8
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "8",
                        Status = SeatStatus.Free
                    },
					new Seat
                    {
                        Id=random.Next(),
                        Name = "9",
                        Status = SeatStatus.Free
                    }
                },

                #endregion

                #region row 9
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "8",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "9",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "10",
                        Status = SeatStatus.Free
                    },
                },

                #endregion

                #region row 10
                new List<Seat>
                {
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "1",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "2",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "3",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "4",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "5",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "6",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "7",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "8",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "9",
                        Status = SeatStatus.Free
                    },
                    new Seat
                    {
                        Id=random.Next(),
                        Name = "10",
                        Status = SeatStatus.Free
                    },
                },

                #endregion


            };

			return data;
		}
	}



	public class Seat
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("status")]
		public SeatStatus Status { get; set; }
	}



	public enum SeatStatus
	{
		Free = 0,
		Sold = 1,
		Selected = 2,
		Booked = 3
	}
}
