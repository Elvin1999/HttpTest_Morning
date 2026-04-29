using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest.Services
{

    public class Rootobject
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }
        public Support support { get; set; }
        public _Meta _meta { get; set; }
    }

    public class RootobjectSingle
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User data { get; set; }
        public Support support { get; set; }
        public _Meta _meta { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class _Meta
    {
        public string powered_by { get; set; }
        public string docs_url { get; set; }
        public string upgrade_url { get; set; }
        public string example_url { get; set; }
        public string variant { get; set; }
        public string message { get; set; }
        public Cta cta { get; set; }
        public string context { get; set; }
    }

    public class Cta
    {
        public string label { get; set; }
        public string url { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }

        public override string ToString()
        {
            return $@"
    ID : {id}
    EMAIL : {email}
    Firstname : {first_name}
    Lastname : {last_name}
    Avatar : {avatar}
";
        }
    }

    public class UserDto
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class UserService
    {
        private readonly string myapikey = "free_user_3D1EfJF4jQhHHs1qXHtBTvjC7hH";
        private readonly string url = "https://reqres.in/api/users";

        public async Task<List<User>> GetUsers()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", myapikey);

            var result = await client.GetAsync(url);// /users
            var jsonString = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Rootobject>(jsonString);
            return data != null ? data.data.ToList() : [];
        }

        public async Task<User> GetUser(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", myapikey);

            var result = await client.GetAsync(url+"/"+id);// /users/1
            var jsonString = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RootobjectSingle>(jsonString);
            return data != null ? data.data : null;
        }

        public async Task<string> AddUser(UserDto dto)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", myapikey);

            var json = JsonConvert.SerializeObject(dto);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            Console.WriteLine((int)response.StatusCode);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.IsSuccessStatusCode);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        // /users/1
        // 
        public async Task<string> UpdateUserAsync(int id,UserDto userDto)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", myapikey);

            var json = JsonConvert.SerializeObject(userDto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await client.PutAsync(url + "/" + id, stringContent);

            Console.WriteLine((int)response.StatusCode);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.IsSuccessStatusCode);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", myapikey);

            var response = await client.DeleteAsync(url + "/" + id);

            Console.WriteLine((int)response.StatusCode);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.IsSuccessStatusCode);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
