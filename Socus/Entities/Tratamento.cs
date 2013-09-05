using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Felice.Core.Model;

namespace Socus.Entities
{
    public class Tratamento : Entity
    {
        public virtual string Nome
        {
            get;
            set;
        }

        public virtual decimal Preco
        {
            get;
            set;
        }
    }
}