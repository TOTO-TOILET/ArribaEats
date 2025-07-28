namespace Arriba_eat;

public class UserController
{
    protected List<User> users = new List<User>();
    public List<User> GetUsers() => users;
    public void AddUser(User user) => users.Add(user);
}