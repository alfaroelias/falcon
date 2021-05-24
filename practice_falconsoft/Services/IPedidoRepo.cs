using practice_falconsoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_falconsoft.Helpers;
using practice_falconsoft.Models;

namespace practice_falconsoft.Services
{
    public interface IPedidoRepo
    {
        Pedido getPedido(int id);
        List<Pedido> getPedidos();
        Task<PagedList<Pedido>> GetPedidoPaginado(PedidosParameters pedidosParameters);        
        Pedido update(Pedido pedido);
        Pedido delete(int id);
        Pedido create(Pedido pedido);
    }
}
