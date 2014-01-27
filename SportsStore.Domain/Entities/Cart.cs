using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
  public  class Cart
    {

      List<CartLine> lineCollection = new List<CartLine>();
      public void AddItem(Product product,int quantity)
      {
          CartLine cartLine = lineCollection.Where(x => x.Product.Name == product.Name).FirstOrDefault();
          if (cartLine == null)
          {
              lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
          }
          else
          {
              cartLine.Quantity += quantity;
              lineCollection.Add(cartLine);
          }

      }

      //去除产品
       public void RemoveLine(Product product,int quantity=0)
      {
          if (quantity == 0)
          {           
              RemoveLineAll(product.ProductID);
          }
          else
          {
             var c= lineCollection.Find(x => x.Product.ProductID == product.ProductID);
             if (c.Quantity == quantity)
             {
                 RemoveLineAll(product.ProductID);
             }
             else
             {
                 c.Quantity -= quantity;
             }
          }
      }
      //去除所有此产品
       public void RemoveLineAll(int id)
       {
               lineCollection.RemoveAll(x => x.Product.ProductID == id);             
       }
      //计算价格
      public decimal ComputeTotalValue()
       {
           return lineCollection.Sum(x=>x.Product.Price*x.Quantity);
       }
      public  void Clear()
      {
          lineCollection.Clear();
      }
      public IEnumerable<CartLine> Lines{ get{return lineCollection;} }

    }


  public class CartLine
  {
      
      public Product Product { get; set; }
      public int Quantity { get; set; }

  }
}
