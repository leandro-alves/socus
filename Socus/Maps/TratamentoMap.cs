using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Socus.Entities;
using FluentNHibernate.Mapping;

namespace Socus.Maps
{
    public class TratamentoMap : ClassMap<Tratamento>
    {
        public TratamentoMap()
        {
            this.Table("tratamentos");
            this.Id(x => x.Id).Column("id").GeneratedBy.Native();
            this.Map(x => x.Nome).Column("nome");
            this.Map(x => x.Preco).Column("preco");
        }
    }
}