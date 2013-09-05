using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMigrator;

namespace Socus.Migrations
{
    [Migration(201309032108)]
    public class AdicionaStatusEmTratamento : AutoReversingMigration
    {
        public override void Up()
        {
            this.Alter.Table("tratamentos")
                .AddColumn("ativo").AsBoolean().NotNullable();
        }
    }
}