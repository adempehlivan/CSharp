using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            //EtradeContext bellekte çok yer kaplıyor. Bu tip nesneleri F12 ile giderse IDispsible yi görürüsün. using kullanırsan metoddan çıkınca gb yi beklemeden nesneyi zorla dispose edersin.
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.ToList();
            }
        }

        public void Add(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                
                var entity = context.Entry(product);
                entity.State = EntityState.Added;//böylede bir yazım olabilir
                context.SaveChanges();


                //kısa add işlemi
                //  context.Products.Add(product);
                //  context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            { 
                //gönderdiğimiz product nesnesini veritabanı ile eşleştiriyor.
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
         
                context.SaveChanges();


                //update in ise olması gereken nesneyi çekersin çektiğin objede değişiklik yapıp savechanges yaparsın
            }
        }

        public void Delete(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
               
                //context.Products.Remove(product); silmeyi add gibi basit şekilde yapabiliriz.
                //gönderdiğimiz product nesnesini veritabanı ile eşleştiriyor. ama yanlış gibi
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> GetByName(string key)
        {
            //EtradeContext bellekte çok yer kaplıyor. Bu tip nesneleri F12 ile giderse IDispsible yi görürüsün. using kullanırsan metoddan çıkınca gb yi beklemeden nesneyi zorla dispose edersin.
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            //EtradeContext bellekte çok yer kaplıyor. Bu tip nesneleri F12 ile giderse IDispsible yi görürüsün. using kullanırsan metoddan çıkınca gb yi beklemeden nesneyi zorla dispose edersin.
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice<=max).ToList();
            }
        }

        public Product GetById(int id)
        {
            //EtradeContext bellekte çok yer kaplıyor. Bu tip nesneleri F12 ile giderse IDispsible yi görürüsün. using kullanırsan metoddan çıkınca gb yi beklemeden nesneyi zorla dispose edersin.
            using (EtradeContext context = new EtradeContext())
            {
                var result = context.Products.FirstOrDefault(x => x.Id == id);
                return result;
            }

        }
    }
}
