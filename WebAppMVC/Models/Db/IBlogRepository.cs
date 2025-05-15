namespace WebAppMVC.Models.Db
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
        Task Register(User user);
    }
}
