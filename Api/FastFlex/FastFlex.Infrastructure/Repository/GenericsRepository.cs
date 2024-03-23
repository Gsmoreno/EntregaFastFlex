using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Context;
using FastFlex.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastFlex.Infrastructure.Repository
{
    public class GenericsRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<FastFlexContext> _OptionsBuilder;

        public GenericsRepository()
        {
            _OptionsBuilder = new DbContextOptions<FastFlexContext>();
        }

        public async Task Add(T obj)
        {
            try
            {
                using (var data = new FastFlexContext(_OptionsBuilder))
                {
                    await data.Set<T>().AddAsync(obj);
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(T obj)
        {
            try
            {
                using (var data = new FastFlexContext(_OptionsBuilder))
                {
                    data.Set<T>().Remove(obj);
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                using (var data = new FastFlexContext(_OptionsBuilder))
                {
                    return await data.Set<T>().ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            try
            {
                using (var data = new FastFlexContext(_OptionsBuilder))
                {
                    return await data.Set<T>().FindAsync(Id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task Update(T obj)
        {
            try
            {
                using (var data = new FastFlexContext(_OptionsBuilder))
                {
                    data.Set<T>().Update(obj);
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}