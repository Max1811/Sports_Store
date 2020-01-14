using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.InicializationData
{
    public class CategoriesData
    {
        public List<Category> categories = new List<Category>()
        {
            new Category("Clothes"),
            new Category("Transport"),
            new Category("Another stuff"),
        };
    }
}
