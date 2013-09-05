using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMigrator;

namespace Socus.Migrations
{
    [Migration(201309032015)]
    public class CriaTratamento : AutoReversingMigration
    {
        public override void Up()
        {
            this.Create.Table("tratamentos")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("nome").AsString().NotNullable()
                .WithColumn("preco").AsDecimal().NotNullable();
        }
    }
}