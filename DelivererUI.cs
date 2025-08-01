namespace Arriba_eat;

public class DelivererUI:UserUI
{
    public override bool DisplayMainMenu()
    {
        base.DisplayMainMenu();
        Console.WriteLine("2. Select a restaurant to order from");
        Console.WriteLine("3. See the status of your orders");
        Console.WriteLine("4. Rate a restaurant you've ordered from");
        Console.WriteLine("5. Log out");
        return true;
    }
}