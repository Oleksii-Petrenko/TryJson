using System.Collections.Generic;

namespace JsonTest
{
    public class Repository
    {
        public List<Products> Products { get; set; }
        public List<Categories> Categories { get; set; }
    }

    public class Products
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }

    public class Categories
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}