﻿using System;
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
                //  context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;//böylede bir yazım olabilir
                context.SaveChanges();
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
            }
        }

        public void Delete(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                //gönderdiğimiz product nesnesini veritabanı ile eşleştiriyor.
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}