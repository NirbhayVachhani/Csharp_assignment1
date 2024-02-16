using System.Reflection;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// The Manager class for the Modern Appliances project serves as the central point of interaction
    /// for managing the inventory of appliances within a retail store environment. It is designed to
    /// facilitate a variety of operations essential to both store employees and customers.
    /// </summary>
    /// <remarks>
    /// Upon initialization, the class loads the store's appliance inventory from a designated file,
    /// making it immediately ready for various operations. Users of the system can perform actions such
    /// as:
    /// - Checking out an appliance for purchase.
    /// - Searching for appliances by brand or other criteria.
    /// - Displaying lists of appliances filtered by type (e.g., refrigerators, vacuums).
    /// - Generating a random selection of appliances, useful for promotions or random browsing.
    ///
    /// This functionality supports a dynamic and interactive experience, mimicking the real-life process
    /// of exploring, evaluating, and purchasing modern appliances in a retail setting. Through the use
    /// of object-oriented principles such as classes and inheritance, the project models the complexities
    /// of inventory management and customer service in a retail appliance store.
    /// </remarks>
    /// <author>Nirbhay Vachhani</author>
    /// <date>02/15/2024</date>

    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.Write("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long applianceNumber;

            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();

            // Convert user input from string to long and store as item number variable.
            applianceNumber = long.Parse(userInput);

            // Create 'foundAppliance' variable to hold appliance with item number
            Appliance foundAppliance;

            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            foundAppliance = null;

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test appliance item number equals entered item number
                if (appliance.ItemNumber == applianceNumber)
                {
                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = appliance;

                    // Break out of loop (since we found what need to)
                    break;
                }
            }
                // Test appliance was not found (foundAppliance is null)
                if (foundAppliance is null)
                {
                    // Write "No appliances found with that item number."
                    Console.WriteLine("No appliances found with that item number.");
                }
            
                else if (foundAppliance.IsAvailable)
                {
                    // Checkout found appliance
                    foundAppliance.Checkout();

                    // Write "Appliance has been checked out."
                    Console.WriteLine($"Appliance {applianceNumber} has been checked out.");
                }
                else
                {
                    // Write "The appliance is not available to be checked out."
                    Console.WriteLine("The appliance is not available to be checked out.");
                }

            Console.WriteLine();

        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine();
            // Write "Enter brand to search for:"
            Console.Write("Enter brand to search for: ");

            // Create string variable to hold entered brand
            string brand;

            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand == userInput)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine(); 
            // Write "Enter number of doors:"
            Console.WriteLine("Enter number of doors:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "2 - Double doors"
            Console.WriteLine("2 - Double doors");
            // Write "3 - Three doors"
            Console.WriteLine("3 - Three doors");
            // Write "4 - Four doors"
            Console.WriteLine("4 - Four doors");

            // Write "Enter number of doors: "
            Console.Write("Enter number of doors: ");

            // Create variable to hold entered number of doors
            int numDoors;
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Convert user input from string to int and store as number of doors variable.
            numDoors = int.Parse(userInput);
            // Create list to hold found Appliance objects
            List<Appliance> applienceObjects = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator)
                {
                    // Down cast Appliance to Refrigerator
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    // Refrigerator refrigerator = (Refrigerator) appliance;
                    
                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if (numDoors == 0 || numDoors == refrigerator.Doors)
                    {
                        // Add current appliance in list to found list
                        applienceObjects.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(applienceObjects, 0);
            // DisplayAppliancesFromList(applienceObjects, 0);

        }


        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine();
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.Write("Enter type of appliance: ");

            // Assuming type "2" for Vacuums is already chosen, we move directly to battery voltage input
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");

            // Get user input for battery voltage
            string userInput_voltage = Console.ReadLine();

            // Determine voltage
            int voltage = userInput_voltage == "18" ? 18 : 24; // Default to high voltage if input is not "18"

            // Filter vacuums by battery voltage (and possibly by grade if you implement this part)
            List<Appliance> found = Appliances.Where(a => a is Vacuum && ((Vacuum)a).BatteryVoltage == voltage).ToList();

            // Display matching vacuums
            if (found.Count > 0)
            {
                foreach (Vacuum vacuum in found)
                {
                    Console.WriteLine($"Item Number: {vacuum.ItemNumber}");
                    Console.WriteLine($"Brand: {vacuum.Brand}");
                    Console.WriteLine($"Quantity: {vacuum.Quantity}");
                    Console.WriteLine($"Wattage: {vacuum.Wattage}");
                    Console.WriteLine($"Color: {vacuum.Color}");
                    Console.WriteLine($"Price: {vacuum.Price}");
                    Console.WriteLine($"Grade: {vacuum.Grade}");
                    Console.WriteLine($"Battery voltage: {(vacuum.BatteryVoltage == 18 ? "Low" : "High")}");
                    Console.WriteLine(); // Separate entries for readability
                }
            }
            else
            {
                Console.WriteLine("No matching vacuums found.");
            }
        }



        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            
            Console.WriteLine();
            // Write "Room where the microwave will be installed: "
            Console.WriteLine("Room where the microwave will be installed: ");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - Kitchen"
            Console.WriteLine("K - Kitchen");
            // Write "2 - Work site"
            Console.WriteLine("W - Work site");

            // Write "Enter room type:"
            Console.Write("Enter room type: ");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create character variable that holds room type
            char roomType;

            // Test input is "0"
            if (userInput == "0")
            {
                // Assign 'A' to room type variable
                roomType = 'A';
            }
            // Test input is "1"
            else if (userInput == "k" || userInput == "K")
            {
                // Assign 'K' to room type variable
                roomType = 'K';
            }
            // Test input is "2"
            else if (userInput == "w" || userInput == "W")
            {
                // Assign 'W' to room type variable
                roomType = 'W';
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
                // return;
            }

            // Create variable that holds list of 'found' appliances
            List<Appliance> listFound = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave)
                {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)appliance;

                    // Test room type equals 'A' or microwave room type
                    if (roomType == 'A' || roomType == microwave.RoomType)
                    {
                        // Add current appliance in list to found list
                        listFound.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(listFound, 0);
            
            
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine();
            // Write "Enter the sound rating of the dishwasher:"
            Console.WriteLine("Enter the sound rating of the dishwasher:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - Quietest"
            Console.WriteLine("1 - Quietest");
            // Write "2 - Quieter"
            Console.WriteLine("2 - Quieter");
            // Write "3 - Quiet"
            Console.WriteLine("3 - Quiet");
            // Write "4 - Moderate"
            Console.WriteLine("4 - Moderate");

            // Write "Enter sound rating:"
            Console.Write("Enter sound rating: ");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();

            // Create variable that holds sound rating
            string soundRating;

            // Test input is "0"
            if (userInput == "0")
            {
                // Assign "Any" to sound rating variable
                soundRating = "Any";
            }
            // Test input is "1"
            else if (userInput == "1")
            {
                // Assign "Qt" to sound rating variable
                soundRating = "Qt";
            }
            // Test input is "2"
            else if (userInput == "2")
            {
                // Assign "Qr" to sound rating variable
                soundRating = "Qr";
            }
            // Test input is "3"
            else if (userInput == "3")
            {
                // Assign "Qu" to sound rating variable
                soundRating = "Qu";
            }
            // Test input is "4"
            else if (userInput == "4")
            {
                // Assign "M" to sound rating variable
                soundRating = "M";
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }
            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();
            
            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test if current appliance is dishwasher
                if (appliance is Dishwasher)
                {

                    // Down cast current Appliance to Dishwasher
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                    if (soundRating == "Any" || soundRating == dishwasher.SoundRating)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
       public override void RandomList()
{
    Console.WriteLine();
    Console.WriteLine("Welcome to Modern Appliances!");
    Console.WriteLine("How May We Assist You?");
    Console.WriteLine("1 – Check out appliance");
    Console.WriteLine("2 – Find appliances by brand");
    Console.WriteLine("3 – Display appliances by type");
    Console.WriteLine("4 – Produce random appliance list");
    Console.WriteLine("5 – Save & exit");
    Console.Write("Enter option: ");
    
    // Assuming option "4" for random appliance list is already chosen, we move directly to the number of appliances
    Console.Write("Enter number of appliances: ");

    // Get user input for number of appliances
    int numAppliances;
    if (!int.TryParse(Console.ReadLine(), out numAppliances))
    {
        Console.WriteLine("Invalid number. Please enter a valid number.");
        return;
    }

    // Check if the number of appliances requested is greater than the available appliances
    if (numAppliances > Appliances.Count)
    {
        Console.WriteLine($"Only {Appliances.Count} appliances available. Displaying all.");
        numAppliances = Appliances.Count;
    }

    // Shuffle the list and take the first 'numAppliances' appliances
    var randomAppliances = Appliances.OrderBy(a => Guid.NewGuid()).Take(numAppliances).ToList();

    // Display the details of the selected appliances
    Console.WriteLine("Random appliances:");
    foreach (var appliance in randomAppliances)
    {
        Console.WriteLine($"Item Number: {appliance.ItemNumber}");
        Console.WriteLine($"Brand: {appliance.Brand}");
        Console.WriteLine($"Quantity: {appliance.Quantity}");
        Console.WriteLine($"Wattage: {appliance.Wattage}");
        Console.WriteLine($"Color: {appliance.Color}");
        Console.WriteLine($"Price: {appliance.Price}");
        // Check appliance type and display additional details accordingly
        if (appliance is Vacuum vacuum)
        {
            Console.WriteLine($"Grade: {vacuum.Grade}");
            Console.WriteLine($"Battery Voltage: {(vacuum.BatteryVoltage == 18 ? "Low" : "High")}");
        }
        else if (appliance is Refrigerator refrigerator)
        {
            Console.WriteLine($"Number of Doors: {refrigerator.Doors}");
            Console.WriteLine($"Height: {refrigerator.Height}");
            Console.WriteLine($"Width: {refrigerator.Width}");
        }
        // Add similar conditions for Microwaves and Dishwashers if needed
        Console.WriteLine();
    }
}

    
    }
}

