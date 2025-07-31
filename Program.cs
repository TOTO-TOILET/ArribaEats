using System.Diagnostics;

namespace Arriba_eat;

public class Program
{
    public static void Main(string[] args)
    {
        AuthManager authManager = new AuthManager();
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
                    }
                    if (user is Restaurant restaurant)
                    {
                        RestaurantController controller = new RestaurantController(restaurant);
                        RestaurantUI UI = new RestaurantUI(controller, restaurant);
                        UI.DisplayMainMenu();
                    }
                    else if (user is Customer customer)
                    {
                        CustomerUI UI = new CustomerUI();
                        UI.DisplayMainMenu();
                    }
                    else if (user is Deliverer deliverer)
                    {
                        DelivererUI UI = new DelivererUI();
                        UI.DisplayMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Account does not exist");
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


