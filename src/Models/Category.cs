using System.Collections.Generic;

namespace MusicStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Product> Products { get; set; }
    }
}