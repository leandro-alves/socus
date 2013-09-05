using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Socus.Entities;
using Felice.Core;

namespace Socus.Forms
{
    public class NovoTratamentoForm
    {
        public long Id
        {
            get;
            set;
        }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome
        {
            get;
            set;
        }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "{0} deve ser númerico")]
        public string Preco
        {
            get;
            set;
        }
    }
}
