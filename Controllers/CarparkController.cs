using CarparkInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarparkInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarparkController : ControllerBase
    {
        private readonly CsvImporter _csvImporter;

        // Inject CsvImporter through constructor
        public CarparkController(CsvImporter csvImporter)
        {
            _csvImporter = csvImporter;
        }

        // POST: api/carpark/import
        [HttpPost("import")]
        public IActionResult ImportCsv()
        {
            try
            {
                // Define the file path to your CSV file
                string filePath = @"C:\Work\carpark-info-assignment\hdb-carpark-information-20220824010400.csv";

                // Call the import method
                _csvImporter.ImportCsv(filePath);

                // Return a success message
                return Ok("CSV Data Imported Successfully!");
            }
            catch (Exception ex)
            {
                // Return an error message if something goes wrong
                return BadRequest($"Error importing CSV: {ex.Message}");
            }
        }

        // POST: api/carpark
        [HttpGet("filter")]
        public IActionResult FilterCarparks([FromQuery] bool? freeParking, [FromQuery] bool? nightParking, [FromQuery] double? vehicleHeight)
        {
            try
            {
                using (var context = new CarparkDbContext())
                {
                    var query = context.Carparks.AsQueryable();

                    // Apply filters based on user input
                    if (freeParking.HasValue)
                    {
                        // Use "YES" or "NO" as stored in the database
                        query = query.Where(c => c.free_parking.ToUpper() == (freeParking.Value ? "YES" : "NO"));
                    }

                    if (nightParking.HasValue)
                    {
                        // Use "YES" or "NO" as stored in the database
                        query = query.Where(c => c.night_parking.ToUpper() == (nightParking.Value ? "YES" : "NO"));
                    }

                    if (vehicleHeight.HasValue)
                    {
                        // Filter for carparks with the exact gantry height requested
                        query = query.Where(c => c.gantry_height == vehicleHeight.Value);
                    }

                    var filteredCarparks = query.ToList();

                    // Check if we have any filtered carparks
                    if (filteredCarparks.Count == 0)
                    {
                        return NotFound("No carparks match your criteria.");
                    }

                    return Ok(filteredCarparks);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching filtered carparks: {ex.Message}");
            }
        }

        // POST: api/carpark/{carparkId}/favorite
        [HttpPost("{carparkId}/favorite")]
        public IActionResult MarkAsFavorite(string carparkId)
        {
            try
            {
                using (var context = new CarparkDbContext())
                {
                    // Find the carpark by its car_park_no
                    var carpark = context.Carparks.FirstOrDefault(c => c.car_park_no == carparkId);

                    if (carpark == null)
                    {
                        return NotFound($"Carpark with ID {carparkId} not found.");
                    }

                    // Mark the carpark as favorite
                    carpark.IsFavorite = true;

                    // Save changes to the database
                    context.SaveChanges();

                    return Ok($"Carpark {carparkId} has been marked as favorite.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error marking carpark as favorite: {ex.Message}");
            }
        }




    }
}
