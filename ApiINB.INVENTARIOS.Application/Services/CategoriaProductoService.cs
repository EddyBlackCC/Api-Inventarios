using ApiINB.INVENTARIOS.Application.DTOs.CategoriaProducto;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class CategoriaProductoService : ICategoriaProductoService
    {
        private readonly ICategoriaProductoRepository _repository;

        public CategoriaProductoService(ICategoriaProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaProductoDto>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();

            return categorias.Select(x => new CategoriaProductoDto
            {
                CategoriaId = x.CategoriaId,
                NombreCategoria = x.NombreCategoria,
                Descripcion = x.Descripcion,
                Activo = x.Activo
            }).ToList();
        }

        public async Task<CategoriaProductoDto?> GetByIdAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
                return null;

            return new CategoriaProductoDto
            {
                CategoriaId = categoria.CategoriaId,
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
                Activo = categoria.Activo
            };
        }

        public async Task CreateAsync(CreateCategoriaProductoDto dto)
        {
            var categoria = new CategoriaProducto
            {
                NombreCategoria = dto.NombreCategoria,
                Descripcion = dto.Descripcion,
                AudCreaUsuario = 1,
                AudCreaFecha = DateTime.Now
            };

            await _repository.AddAsync(categoria);

            await _repository.SaveChangesAsync();
        }
    }
}