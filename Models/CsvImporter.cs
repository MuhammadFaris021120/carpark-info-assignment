namespace CarparkInfo.Models
{
    using CsvHelper;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Formats.Asn1;

    public class CsvImporter
    {
        public void ImportCsv(string filePath)
        {
            // Open the CSV file
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Read records from the CSV file and map them to the Carpark class
                var records = csv.GetRecords<Carpark>().ToList();

                // Save the records to the database
                using (var context = new CarparkDbContext())
                {
                    // Add the records to the Carparks table
                    context.Carparks.AddRange(records);

                    // Save changes to the database
                    context.SaveChanges();
                }
            }
        }
    }

}
