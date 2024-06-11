using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class BrandDAO
    {
        private static BrandDAO instance = null;
        private static readonly object instanceLock = new object();
        public static BrandDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BrandDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Brand> GetAllBrands()
        {

            var brands = new List<Brand>();
            try
            {
                using var context = new PerfumesStoreContext();
                brands = context.Brands.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return brands;

        }
        public Brand GetBrandByID(int braId)
        {
            Brand brands = null;
            try
            {
                using var context = new PerfumesStoreContext();
                brands = context.Brands.SingleOrDefault(p => p.BrandId == braId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return brands;
        }

        public void AddNew(Brand brands)
        {
            using var context = new PerfumesStoreContext();
            if (brands == null)
            {
                context.Brands.Add(brands);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Brands ID does exits!");
            }

        }

        public void Delete(int id)
        {
            Brand? brands = GetBrandByID(id);
            if (brands == null)
            {
                throw new Exception($"Brands {id} not found");
            }
            using var context = new PerfumesStoreContext();
            context.Brands.Remove(brands);
            context.SaveChanges();
        }
    }
}
