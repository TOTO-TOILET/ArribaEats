namespace Arriba_eat;

public abstract class UserUI
{
    public virtual void DisplayUserInfo(User user)
    {
        Console.WriteLine($"Name: {user.name}");
        Console.WriteLine($"Email: {user.email}");
        Console.WriteLine($"Location: {user.location}");
    }

    /// <summary>
    /// Each user type have different main menu 
    /// </summary>
    public virtual bool DisplayMainMenu()
    {
        Console.WriteLine("1. Display user information");
        return true;
    }
}

