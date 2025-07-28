namespace Arriba_eat;

public abstract class User
{
    protected string name;
    protected string password;
    protected string email;
    protected string location;// this is nullable 

    public string getName()
    {
        return name;
    }
    
    public string getPassword()
    {
        return password;
    }
    
    public string getEmail()
    {
        return email;
    }
    
    public string getLocation()
    {
        return location;
    }
}