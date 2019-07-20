﻿using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> SaveCategoria(string nome);
        Task<IList<Categoria>> GetCategorias();
        Task<IList<Categoria>> GetCategorias(string pesquisa);
    }
}
