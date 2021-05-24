using practice_falconsoft.Services;
using practice_falconsoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_falconsoft.Repository;

namespace practice_falconsoft.Services
{
    public class ProductoRepo : IProductoRepo
    {
        private readonly AppDbContext contexto;
        private List<Producto> listaProductos;

        public ProductoRepo(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public Producto createProducto(Producto producto)
        {
            contexto.Producto.Add(producto);
            contexto.SaveChanges();
            return producto;
        }

        public Models.Producto createProducto(Models.Producto producto)
        {
            throw new NotImplementedException();
        }

        public Producto deleteProducto(int id)
        {
            Producto producto = contexto.Producto.Find(id);
            if (producto != null)
            {
                contexto.Producto.Remove(producto);
                contexto.SaveChanges();
            }
            return producto;
        }

        public Producto getProducto(Guid id)
        {
            Producto producto =  contexto.Producto.Find(id);

            return producto;
        }

        public List<Producto> getProductos()
        {
            listaProductos = contexto.Producto.ToList<Producto>();
            return listaProductos;
        }

        public Producto updateProducto(Producto producto)
        {
            var prod = contexto.Producto.Attach(producto);
            prod.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
            return producto;
        }

        public bool ProductExists(Guid id)
        {
            return contexto.Producto.Any(e => e.Id == id);
        }
    }
}
