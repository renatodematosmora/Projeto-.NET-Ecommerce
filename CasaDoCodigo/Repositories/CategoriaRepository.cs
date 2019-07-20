using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<IList<Categoria>> GetCategorias()
        {
            var categorias = await dbSet.Include(c => c.Produtos).ToListAsync();
            return categorias;
        }

        public async Task<IList<Categoria>> GetCategorias(string pesquisa)
        {
            IQueryable<Categoria> query = dbSet.Include(c => c.Produtos);
            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = (from c in query
                        where c.Nome.Contains(pesquisa)
                        || c.Produtos.Any(p => p.Nome.Contains(pesquisa))
                        select c);
            }
            return await query.ToListAsync();
        }

        public async Task<Categoria> SaveCategoria(string nome)
        {
            var categoriaDB = dbSet
                .Where(c => c.Nome == nome)
                .SingleOrDefault();
            if (categoriaDB == null)
            {
                var novaCategoria = new Categoria()
                {
                    Nome = nome
                };
                categoriaDB = dbSet.Add(novaCategoria).Entity;
            }
            await contexto.SaveChangesAsync();
            return categoriaDB;
        }
    }
}
