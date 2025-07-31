namespace Arriba_eat;

public class MenuItem
{
    public string ItemName { get; set; }
    public double ItemPrice { get; set; }

    public MenuItem(string itemName, double itemPrice)
    {
        this.ItemName = itemName;
        this.ItemPrice = itemPrice;
    }
}