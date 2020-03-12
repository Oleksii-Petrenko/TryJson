using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonTest
{
    class Program
    {
        static async Task SendRequestAndShowResult()
        {
            const string request = "https://tester.consimple.pro/";
            string responseBody = string.Empty;
            
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }

            Repository repo = JsonSerializer.Deserialize<Repository>(responseBody);
            var categories = repo.Categories;
            var products = repo.Products;

            var table = from p in products
                        join c in categories on p.CategoryId equals c.Id
                        select new { ProductName = p.Name, CategoryName = c.Name };

            foreach (var row in table)
            {
                Console.WriteLine($"Product Name: {row.ProductName}, Category Name: {row.CategoryName}");
            }
        }


        static async Task Main(string[] args)
        {
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Input 'y' to get data, input 'x' to exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        await SendRequestAndShowResult();
                        break;
                    case "x":
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("You can enter only 'y' or 'n'");
                        flag = false;
                        break;
                }
            }

        }
    }
}