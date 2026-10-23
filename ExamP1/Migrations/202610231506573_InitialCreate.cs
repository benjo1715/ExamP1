namespace ExamP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recuerdoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TituloRecuerdo = c.String(nullable: false),
                        TipoRecuerdo = c.String(nullable: false),
                        Claridad = c.Int(nullable: false),
                        SintezoideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sintezoides", t => t.SintezoideId, cascadeDelete: true)
                .Index(t => t.SintezoideId);
            
            CreateTable(
                "dbo.Sintezoides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        NivelIa = c.Int(nullable: false),
                        FuenteEnergia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recuerdoes", "SintezoideId", "dbo.Sintezoides");
            DropIndex("dbo.Recuerdoes", new[] { "SintezoideId" });
            DropTable("dbo.Sintezoides");
            DropTable("dbo.Recuerdoes");
        }
    }
}
