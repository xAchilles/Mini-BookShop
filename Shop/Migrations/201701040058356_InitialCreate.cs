namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "TypeOfBook_ID", "dbo.TypeOfBook");
            DropIndex("dbo.Book", new[] { "TypeOfBook_ID" });
            AlterColumn("dbo.Book", "TypeOfBook_ID", c => c.Int());
            CreateIndex("dbo.Book", "TypeOfBook_ID");
            AddForeignKey("dbo.Book", "TypeOfBook_ID", "dbo.TypeOfBook", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "TypeOfBook_ID", "dbo.TypeOfBook");
            DropIndex("dbo.Book", new[] { "TypeOfBook_ID" });
            AlterColumn("dbo.Book", "TypeOfBook_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Book", "TypeOfBook_ID");
            AddForeignKey("dbo.Book", "TypeOfBook_ID", "dbo.TypeOfBook", "ID", cascadeDelete: true);
        }
    }
}
