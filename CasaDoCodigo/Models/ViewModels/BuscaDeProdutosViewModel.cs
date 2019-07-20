using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public BuscaDeProdutosViewModel(IList<Categoria> itensCategoria, bool resultado)
        {
            this.ItensCategoria = itensCategoria;
            this.Encontrou = resultado;
        }

        public BuscaDeProdutosViewModel(bool resultado)
        {
            this.Encontrou = resultado;
        }

        public IList<Categoria> ItensCategoria { get; set; }
        public string Pesquisa { get; set; }
        public bool Encontrou { get; set; }
    }
}
