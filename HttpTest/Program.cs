using HttpTest.Services;
using System.Threading.Tasks;

namespace HttpTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            UserService service = new UserService();
            //var users = await service.GetUsers();
            //foreach (var u in users)
            //{
            //    Console.WriteLine(u);
            //}


            var user = await service.GetUser(1);
            Console.WriteLine(user);
        }
    }
}
