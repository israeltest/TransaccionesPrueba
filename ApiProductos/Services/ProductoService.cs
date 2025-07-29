using ApiProductos.DTOs;
using ApiProductos.Models;
using ApiProductos.Repositories;

namespace ApiProductos.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodos() => await _repo.ObtenerProductos();

        public async Task<Producto?> ObtenerPorId(int id) => await _repo.ObtenerProductoPorId(id);

        public async Task Crear(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Categoria = dto.Categoria,
                Imagen = dto.Imagen,
                Precio = dto.Precio,
                Stock = dto.Stock
            };
            await _repo.CrearProducto(producto);
        }

        public async Task Actualizar(ProductoUpdateDto dto)
        {
            var producto = new Producto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Categoria = dto.Categoria,
                Imagen = dto.Imagen,
                Precio = dto.Precio,
                Stock = dto.Stock
            };
            await _repo.ActualizarProducto(producto);
        }

        public async Task Eliminar(int id) => await _repo.EliminarProducto(id);
    }
}
