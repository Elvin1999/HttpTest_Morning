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


            //var user = await service.GetUser(1);
            //Console.WriteLine(user);


            //var result = await service.AddUser(new UserDto
            //{
            //     email="elvin@gmail.com",
            //     first_name="Elvin",
            //     last_name="Camalzade"
            //});

            //var result = await service.UpdateUserAsync(1,new UserDto
            //{
            //    email = "elvin@gmail.com",
            //    first_name = "Elvin",
            //    last_name = "Camalzade"
            //});

            //Console.WriteLine(result);


            var result = await service.DeleteUserAsync(1);

            Console.WriteLine(result);
        }
    }
}
