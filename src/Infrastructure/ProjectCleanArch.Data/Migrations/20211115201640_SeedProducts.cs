using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCleanArch.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"INSERT INTO [dbo].[Products]
                   ([Name]
                   ,[Description]
                   ,[Price]
                   ,[Stock]
                   ,[Image]
                   ,[CategoryId])
                    VALUES('Caderno Expiral',
                           'Caderno Expiral 100 folhas',
                           7.45,
                           50,
                           'caderno.png',
                           1)");

            mb.Sql(@"INSERT INTO [dbo].[Products]
                   ([Name]
                   ,[Description]
                   ,[Price]
                   ,[Stock]
                   ,[Image]
                   ,[CategoryId])
                    VALUES('Estojo Escolar',
                           'Estojo Escolar com ziper',
                           5.45,
                           100,
                           'estojo.png',
                           1)");

            mb.Sql(@"INSERT INTO [dbo].[Products]
                   ([Name]
                   ,[Description]
                   ,[Price]
                   ,[Stock]
                   ,[Image]
                   ,[CategoryId])
                    VALUES('Borracha Escolar',
                           'Borracha branca pequena',
                           1.45,
                           200,
                           'borracha.png',
                           1)");

            mb.Sql(@"INSERT INTO [dbo].[Products]
                   ([Name]
                   ,[Description]
                   ,[Price]
                   ,[Stock]
                   ,[Image]
                   ,[CategoryId])
                    VALUES('Calculadora Escolar',
                           'Calculadora simples',
                           15.45,
                           20,
                           'Calculadora.png',
                           2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
