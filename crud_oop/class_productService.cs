using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_oop
{
    public class class_productService
    {
        public class_productManagement ProductManagement { get; set; }

        public class_productService()
        {
            ProductManagement = new class_productManagement();
        }

        public void GenerateProduct(int number = 1)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                ProductManagement.Addproduct(new Class_product
                {
                    Id = i + 1,
                    Name = "Item " + i + 1,
                    Price = random.Next(10, 201),
                    Category = random.Next(1, 6)
                }); ;
            }
            ProductManagement.ListToTextFile();
        }

        public void showProduct()
        {
            foreach (var item in ProductManagement.Products)
            {
                Console.WriteLine($"{item.Id,5}{item.Name,10}{item.Price,10}{item.Category,10}");
            }
            Console.WriteLine("===========================================");
        }
        public void showGroupbyprice_test()
        {
            var groupbyPrice = groupPrice().GroupBy(e => e.tempPrice);
            foreach (var item in groupbyPrice)
            {
                Console.WriteLine(item.Key);
                foreach (var item1 in item.OrderBy(e => e.tempCategory))
                {
                    Console.WriteLine($"\t{item1.tempCategory}");
                }

            }
        }
        public void showGroupbyprice()
        {
            var groupbyPrice = groupPrice().GroupBy(e => e.tempPrice);
            Console.WriteLine("===============================");
            foreach (var item in groupbyPrice)
            {
                Console.Write($"{NameOfPrice(item.Key),4}");
                for (int i = 1; i <= 5; i++)
                {
                    Console.Write($"{item.Count(e => e.tempCategory == i),4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("===============================");
        }
        public List<Class_product> OrderbyPrice() => ProductManagement.Products.OrderBy(e => e.Price).ToList(); 
        
        public List<tempG> groupPrice()
        {
            var temp = new List<tempG>();
            int tempP = 0;

            foreach (var item in OrderbyPrice())
            {
                tempP = item.Price switch
                {
                    <= 100 => 1,
                    <= 200 => 2,
                    _ => 3,
                };
                temp.Add(new tempG {
                tempPrice = tempP,
                tempCategory = item.Category
                });
            }
            return temp;
        }
        private string NameOfPrice(int price)
        {
            return price switch
            {
                1 => "10-100",
                2 => "101-200",
                _ => " ",
            };
        }                public Class_product searchProductbyId()
        {
            InputID:
            Console.Write("input your Id : ");
            var id = int.Parse(Console.ReadLine());
            var result = ProductManagement.GetProductById(id);
            if (result == null) { Console.WriteLine("data not found"); goto InputID; };
            Console.WriteLine("===========================================");
            Console.WriteLine($"your result is : ID : {result.Id} Name : {result.Name} Price : {result.Price} Categor : {result.Category}");
            Console.WriteLine("===========================================");
            return result;
        }        public void DeleteProduct()
        {
            var result = searchProductbyId();
            if (result == null) return;
            Console.Clear();
            ProductManagement.DeleteById(result);
            Console.WriteLine();
            ProductManagement.ListToTextFile();
            showProduct();
        }
        public void UpdateProduct()
        {
        UpdateProductService:
            var result = searchProductbyId();
            if (result == null) { goto UpdateProductService; }
            var newProduct = ProductManagement.InputProduct(result);
            ProductManagement.UpdateProduct(newProduct, result);
            Console.Clear();
            ProductManagement.ListToTextFile();
            showProduct();
        }
        public void menu()
        {
            Console.Clear();
            showProduct();
            var status = true;
            while (status)
            {
                Console.WriteLine("[1] Update\n[2] Delete\n[3] Exit");
                var key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1: UpdateProduct(); break;
                    case 2: DeleteProduct(); break;
                    case 3: status = false; break;
                }
            }
        }
    }

    public class tempG
    { 
        public int tempPrice {  get; set; }
        public int tempCategory {  get; set; }
    }
}
