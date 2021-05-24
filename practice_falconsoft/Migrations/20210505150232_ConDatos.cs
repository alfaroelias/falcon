using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_falconsoft.Migrations
{
    public partial class ConDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Productos_ProductoId",
                table: "PedidoDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Apellido", "Fecha", "Nombre" },
                values: new object[,]
                {
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "Cavallo", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Perez", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Mesa ratona", 400, 2 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "Silla madera", 200, 4 },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "Estantes", 150, 13 }
                });

            migrationBuilder.InsertData(
                table: "PedidoDetalle",
                columns: new[] { "Id", "PedidoId", "ProductoId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b") });

            migrationBuilder.InsertData(
                table: "PedidoDetalle",
                columns: new[] { "Id", "PedidoId", "ProductoId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6c"), new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee") });

            migrationBuilder.InsertData(
                table: "PedidoDetalle",
                columns: new[] { "Id", "PedidoId", "ProductoId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6d"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") });

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Producto_ProductoId",
                table: "PedidoDetalle",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalle_Producto_ProductoId",
                table: "PedidoDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DeleteData(
                table: "PedidoDetalle",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "PedidoDetalle",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6c"));

            migrationBuilder.DeleteData(
                table: "PedidoDetalle",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6d"));

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"));

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalle_Productos_ProductoId",
                table: "PedidoDetalle",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
