﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPOCHub.DataAccessLayer
{
    public interface ICommonRepository<T>
    {
        List<T> GetAll();
        T GetDetails(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        int SaveChanges();
    }
}
