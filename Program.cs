using System.Diagnostics;

namespace Arriba_eat;

public class Program
{
    public static void Main(string[] args)
    {
        UserController controller = new UserController();
        AuthManager authManager = new AuthManager(controller);
        
        while (true)
        {
            Console.WriteLine("Welcome to Arriba!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    authManager.Register();
                    break;
                case 2:
                    User user = authManager.Login();
                    if (user != null)
                    {
                        Console.WriteLine($"Welcome back {user.name}!");
                        bool loggedIn  = true;
                        while (loggedIn)
                        {
                            if (user is Restaurant restaurant)
                            {
                                RestaurantController restaurantController = new RestaurantController(restaurant);
                                RestaurantUI UI = new RestaurantUI(restaurantController, restaurant);
                                loggedIn = UI.DisplayMainMenu();
                            }
                            else if (user is Customer customer)
                            {
                                CustomerUI UI = new CustomerUI();
                                loggedIn = UI.DisplayMainMenu();
                            }
                            else if (user is Deliverer deliverer)
                            {
                                DelivererUI UI = new DelivererUI();
                                loggedIn = UI.DisplayMainMenu();
                            }
                            else
                            {
                                Console.WriteLine("Account does not exist");
                            }
                        }
                        
                    }
                    break;
                case 3:
                    return;
                default:
                    break;
            }
        }
    }
}


