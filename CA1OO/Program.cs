using System.Text;

namespace CA1OO
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Note the definition of a menu as an array of string

            int choice = 0;

            string[] mainMenu = { "Buy Ticket", "Check in Return ticket", "Print Journey Report", "Exit" };
            string[] ticketMenu = { "Single", "Return" };
            string[] customerMenu = { "Adult", "Child", "OAP", "Student" };

            // Basic Journey information - details of the route

           int[] minsToFinalDestination = { 40, 30, 20, 15, 10, 0 }; // travel time to the final destination in minutes.
           string[] destinations = { "Ballyshannon", "Bundoran", "Cliffoney", "Grange", "Rathcormack", "Sligo" }; // stops on the route.

            //Details of the basic price for a single ticket to the destination

           decimal basePrice = 10m;

            // details about the bus

           int seatsOnBus = 10;


            Journey j = new Journey(destinations, minsToFinalDestination, false, 10, 10);


            do
            {
                choice = GetMenuOption("Ballin Buses:", mainMenu);
                switch (choice)
                {
                    case 0:
                        string origin = destinations[GetMenuOption("Please enter Origin: ", destinations)];
                        string destination = destinations[GetMenuOption("Please enter Origin: ", destinations)];
                        string ticketType = ticketMenu[GetMenuOption("Please enter ticket type: ", ticketMenu)];
                        string customerType = customerMenu[GetMenuOption("Please enter customer type", customerMenu)];
                        decimal price = j.BuyTicket(origin, destination,ticketType,customerType);
                        if (price > 0)
                        {
                            Console.WriteLine($" {customerType} {ticketType} from {origin} to {destination} :{price:C}");
                        }
                        else
                        {
                            Console.WriteLine($" Bus full");
                        }
                            break;

                    case 1: if (!j.CheckInTicket()) Console.WriteLine($" Bus full"); ; break;
                    case 2:j.PrintJourneyReport(); break;
                    default: break;
                }
            }
            while (choice != mainMenu.Length - 1);
        }

        /// <summary>
        /// This method prints out a menu passes as an array of strings and returns the chosen option.
        /// We could rewrite this to split the header as a seperate string. 
        /// </summary>
        /// <param name="menu">a string array of menu options </param>
        /// <returns> an integer representing the index of the menu item chosen.</returns>
        static int GetMenuOption(string header, string[] menuOptions)
        {
            int choice = 0;
            Console.WriteLine(header);


            while (choice <= 0 || choice > menuOptions.Length)
            {
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                }
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number");
                }


                if (choice <= 0 || choice > menuOptions.Length)
                {
                    Console.WriteLine("Incorrect menu choice");
                }
            }
            return choice - 1;

        }
    }
}
