using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMigrator;

namespace Socus.Migrations
{
    [Migration(201309032111)]
    public class CriaPacienteAndEstado : AutoReversingMigration
    {
        public override void Up()
        {
            this.Create.Table("pacientes")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("nome").AsString().NotNullable()
                .WithColumn("estado_id").AsInt64();

            this.Create.Table("estado")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("nome").AsString().NotNullable();
        }
    }
}