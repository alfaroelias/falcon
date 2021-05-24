using practice_falconsoft.Services;
using practice_falconsoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_falconsoft.Repository;
using practice_falconsoft.Helpers;
using practice_falconsoft.Models;
using System.Reflection;
using System.Linq.Expressions;

namespace practice_falconsoft.Services
{
    public class PedidoRepo : IPedidoRepo
    {
        private readonly AppDbContext contexto;
        private List<Pedido> listaPedidos;

        public PedidoRepo(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public Pedido create(Pedido pedido)
        {
            contexto.Pedido.Add(pedido);
            contexto.SaveChanges();
            return pedido;
        }

        public Pedido delete(int id)
        {
            Pedido pedido = contexto.Pedido.Find(id);
            if (pedido != null)
            {
                contexto.Pedido.Remove(pedido);
                contexto.SaveChanges();
            }
            return pedido;
        }

        public Pedido getPedido(int id)
        {
            Pedido pedido = contexto.Pedido.Find(id);
            return pedido;
        }

        public List<Pedido> getPedidos()
        {
            listaPedidos = contexto.Pedido.ToList<Pedido>();

            foreach (Pedido pedido in listaPedidos)
            {
                pedido.Detalle = contexto.PedidoDetalle.Where(x => x.PedidoId == pedido.Id).ToList();
                foreach (PedidoDetalle pedidoDetalle in pedido.Detalle)
                {
                    pedidoDetalle.Producto = contexto.Producto.Where(x => x.Id == pedidoDetalle.ProductoId).FirstOrDefault();
                }
            }

            return listaPedidos;
        }

        public Task<PagedList<Pedido>> GetPedidoPaginado(PedidosParameters pedidosParameters)
        {
            var collection = (IQueryable<Pedido>)contexto.Pedido;

            listaPedidos = contexto.Pedido.ToList<Pedido>();

            //Cargo los productos dentro del detalle
            foreach (Pedido pedido in listaPedidos)
            {
                pedido.Detalle = contexto.PedidoDetalle.Where(x => x.PedidoId == pedido.Id).ToList();
                foreach (PedidoDetalle pedidoDetalle in pedido.Detalle)
                {
                    pedidoDetalle.Producto = contexto.Producto.Where(x => x.Id == pedidoDetalle.ProductoId).FirstOrDefault();
                }
            } 

            //Busqueda por cualquier propiedad del pedido
            if (!string.IsNullOrWhiteSpace(pedidosParameters.SearchQuery))
            {
                string searchQuery = pedidosParameters.SearchQuery.Trim();
                collection = collection.Where(a => 
                    a.Apellido.Contains(searchQuery)
                    || a.Nombre.Contains(searchQuery)               
                    );
            }

            if (!string.IsNullOrWhiteSpace(pedidosParameters.OrderBy))
            {               
                if (pedidosParameters.OrderBy.ToUpper() == "APELLIDO")
                    collection = collection.OrderBy(x => x.Apellido);
                
                if (pedidosParameters.OrderBy.ToUpper() == "NOMBRE")
                    collection = collection.OrderBy(x => x.Nombre);
            }

            var count = collection.Count();

            return PagedList<Pedido>.CreatePaged(collection,
            pedidosParameters.PageNumber,
            pedidosParameters.PageSize);
        }

        public Pedido update(Pedido pedido)
        {
            var prod = contexto.Pedido.Attach(pedido);
            prod.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
            return pedido;
        }

    }
}
