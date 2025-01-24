using System.ComponentModel.DataAnnotations;

namespace CarparkInfo.Models
{
    public class Carpark
    {
        [Key]
        public string car_park_no { get; set; }
        public string address { get; set; }
        public double x_coord { get; set; }
        public double y_coord { get; set; }
        public string car_park_type { get; set; }
        public string type_of_parking_system { get; set; }
        public string short_term_parking { get; set; }
        public string free_parking { get; set; }
        public string night_parking { get; set; }
        public int car_park_decks { get; set; }
        public double gantry_height { get; set; }
        public string car_park_basement { get; set; }

        public bool IsFavorite { get; set; }
    }

}
