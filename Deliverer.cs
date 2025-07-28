namespace Arriba_eat;

public class Deliverer : User
{
    private string licencePlate;
    public Deliverer(string name, string email, string password, string licencePlate)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.licencePlate = licencePlate;
    }
}