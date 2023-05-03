using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            //DONE: use File.ReadAllLines(path) to grab all the lines from your csv file
            //DONE: Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            if(lines.Length == 0)
            {
                logger.LogInfo($"Main: This file has 0 records");
                return;
            }
            else if(lines.Length == 1)
            {
                logger.LogInfo($"Main: This file has only 1 record and cannot be compared to another");
                return;
            }
            logger.LogInfo($"Main: Lines-{lines[0]}");

            //DONE: Create a new instance of your TacoParser class
            var parser = new TacoParser();
      
            //DONE: Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();
            logger.LogInfo($"Main: Parser instantiated & Locations retrieved");

            //DONE: DON'T FORGET TO LOG YOUR STEPS
            //DONE: Now that your Parse method is completed, START BELOW ----------

            //DONE: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            ITrackable TBtrack1 = null;
            ITrackable TBtrack2 = null;
        
            // DONE: Create a `double` variable to store the distance
            double TBdistance = 0;
            logger.LogInfo($"Main: TBtrack1, TBtrack2, & TBdistance initialized");

            //DONE: Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            //HINT NESTED LOOPS SECTION---------------------
            //DONE: Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            //DONE: Create a new corA Coordinate with your locA's lat and long
            //DONE: Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            //DONE: Create a new Coordinate with your locB's lat and long

            GeoCoordinate GeoCoord;
            GeoCoordinate GeoCoord2;
            Point corA = new Point();
            Point corB = new Point();
            double tmpDistance;
            logger.LogInfo($"Main: GeoCoordinate objects and Point corA and corB objects and tmpDistance established");

            foreach (var locA in locations)
            { 
                logger.LogInfo($"Main: Outer For loop started {locA.Name}");
  
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;
                GeoCoord = new GeoCoordinate(corA.Latitude, corA.Longitude);
 //               logger.LogInfo($"Main: Initial coordinate established");

                foreach (var locB in locations)
                {
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;
                    GeoCoord2 = new GeoCoordinate(corB.Latitude, corB.Longitude);
  //                  logger.LogInfo($"Main: Outer For loop started");

                    tmpDistance = GeoCoord.GetDistanceTo(GeoCoord2);
  

                    if (tmpDistance > TBdistance)
                    {
                        logger.LogInfo($"Main: Distance computed between two coordinate points {locA.Name} & {locB.Name} : {tmpDistance}");
  //                      logger.LogInfo($"Main: Distance comparison shows a new greater distance");
                       
                        TBdistance = tmpDistance;

                        TBtrack1 = new TacoBell();
                        TBtrack1.Location = locA.Location;
                        TBtrack1.Name = locA.Name;

                        TBtrack2 = new TacoBell();
                        TBtrack2.Location = locB.Location;
                        TBtrack2.Name = locB.Name;

  //                      logger.LogInfo($"Main: All tracking variables/objects updated");
                }
                }

            }

            //DONE: Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            Console.WriteLine($"{TBtrack1.Name}");
            Console.WriteLine($"{TBtrack2.Name}");
            Console.WriteLine($"{TBdistance}");
        }
    }
}
