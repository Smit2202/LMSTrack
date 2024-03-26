using static LMSTrack.Model.ModelClass;

namespace LMSTrack.Services.LMSServices
{
    public interface ILMSUserServices
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<List<User>> PostUser(User user);
        Task<List<User>> PutUser(int id, User user);
        Task<List<User>> DeleteUser(int id);
    }
}
