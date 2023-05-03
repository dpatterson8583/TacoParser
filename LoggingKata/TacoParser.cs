namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public TacoParser() { }
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Parser: -------------");
            logger.LogInfo("Parser: Begin parsing");

            if(line==null)
            {
                logger.LogInfo("Parser: Line is null.  Exiting Parse with 'null'.");
                return null;
            }

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');
            logger.LogInfo("Parser: Record split at commas");

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogInfo("Parser: Length of array 'cells' is < 3.  Exiting Parse with 'null'");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            //DONE: grab the latitude from your array at index 0
            var Lat = double.Parse(cells[0]);
   
            //DONE: grab the longitude from your array at index 1
            var Long = double.Parse(cells[1]);
            
            //DONE: grab the name from your array at index 2
            var Name = cells[2];
            logger.LogInfo($"Parser: Acquired latitude & longitude and name from array : {Name}");

            //DONE: Your going to need to parse your string as a `double` which is similar to parsing a string as an `int`
            //DONE: You'll need to create a TacoBell class that conforms to ITrackable
            //DONE: Then, you'll need an instance of the TacoBell class, with the name and point set correctly
            var currTB = new TacoBell();
            
            currTB.Name = Name;
            currTB.Location = new Point
            {
                Latitude = Lat,
                Longitude = Long
            };
            logger.LogInfo("Parser: Instantiated new Taco Bell object with updated properties.");
  
            //DONE: Then, return the instance of your TacoBell class, since it conforms to ITrackable
            logger.LogInfo("Parser: Return the TB object to the calling module");
            return currTB;
        }
    }
}