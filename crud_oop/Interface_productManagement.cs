using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_oop
{
    public interface Interface_productManagement
    {
        void Addproduct(Class_product product);
        List<Class_product> GetproductList();
        Class_product GetProductById (int id);
        void DeleteById(Class_product product);
        Class_product InputProduct(Class_product product);
        void UpdateProduct(Class_product NewProduct, Class_product OldProduct);
        void ListToTextFile();
    }
}
