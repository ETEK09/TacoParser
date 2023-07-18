using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');



            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogWarning("The cells elements are less than 3"); // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latitude = cells[0];
            var longitude = cells[1];
            var nameCity = cells[2];

            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`

            // which is similar to parsing a string as an `int`
            bool parseLatitude = double.TryParse(latitude, out double latNumber);
            bool parseLongitude = double.TryParse(longitude, out double longNumber);
            //Console.WriteLine("If loginfo is a failure ")

            if (!parseLatitude) 
            { 
                logger.LogWarning("Was unable to parse Latitude."); 
               
            }

            if (!parseLongitude)
            {
                logger.LogWarning("Was unable to parse longitude.");

            }


            // You'll need to create a TacoBell class --DONE
            // that conforms to ITrackable --DONE

            // Then, you'll need an instance of the TacoBell class --DONE
            // With the name and point set correctly
            // 

            Point point = new Point();
            point.Latitude = latNumber;
            point.Longitude = longNumber;

            //tacoBell.Name = nameCity;
            //tacoBell.Location = point;
            TacoBell tacoBell = new TacoBell()          
            {
                Name = nameCity,
                Location = point
            };

            // Then, return the instance of your TacoBell class

            // Since it conforms to ITrackable

            return tacoBell;


        }

       
    }
}