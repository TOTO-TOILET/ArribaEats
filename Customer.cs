namespace Arriba_eat;

public class Customer : User
{
    public Customer(string name, string email, string password, string location)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.location = location;
    }
}