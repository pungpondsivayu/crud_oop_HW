using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_oop
{
    public class class_productManagement : Interface_productManagement
    {
        public List<Class_product> Products { get; set; }

        public class_productManagement()
        {
            Products = new List<Class_product>();
        }

        public void Addproduct(Class_product product)
        {
            Products.Add(product);
        }

        public List<Class_product> GetproductList()
        {
            return Products;
        }

        public Class_product GetProductById(int id)
        {
            return Products.Find(e => e.Id.Equals(id));
        }

        public void DeleteById(Class_product product)
        {
            if(product == null) return;
            Products.Remove(product);
        }

        public Class_product InputProduct(Class_product product)
        {
            Console.WriteLine("Product Id : " + product.Id);
            Console.Write("Input Name : ");
            product.Name = Console.ReadLine();
            Console.Write("Input Price : ");
            product.Price = double.Parse(Console.ReadLine());
            Console.Write("Input Category : ");
            product.Category = int.Parse(Console.ReadLine());
            return product;
        }
        public Class_product InputInsertProduct(Class_product product)
        {
            Console.Write("Input Name : ");
            product.Name = Console.ReadLine();
            Console.Write("Input Price : ");
            product.Price = double.Parse(Console.ReadLine());
            Console.Write("Input Category : ");
            product.Category = int.Parse(Console.ReadLine());
            return product;
        }
        public void UpdateProduct(Class_product NewProduct, Class_product OldProduct)
        {
            var index = Products.IndexOf(OldProduct);
            Products.Remove(OldProduct);
            Products.Insert(index, NewProduct);
        }

        public void ListToTextFile()
        {
            string textfile = (@"C:\Users\thepp\Desktop\cs66\crud_oop\crud_oop\data.txt");
            using (StreamWriter f = new StreamWriter(textfile)) {
                foreach (var item in Products)
                {
                    f.WriteLine($"{item.Id} {item.Name} {item.Price} {item.Category}");
                }            
            }
        }

        public void insert(int index, Class_product Product)
        {
            Products.Insert(index, Product);
        }
    }
}
