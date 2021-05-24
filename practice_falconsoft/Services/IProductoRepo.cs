using practice_falconsoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Services
{
    public interface IProductoRepo
    {
        Producto getProducto(Guid id);
        List<Producto> getProductos();
        Producto updateProducto(Producto producto);
        Producto deleteProducto(int id);
        Producto createProducto(Producto producto);
        public bool ProductExists(Guid id);
    }
}
