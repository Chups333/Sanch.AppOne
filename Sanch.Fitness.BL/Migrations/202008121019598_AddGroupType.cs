namespace Sanch.Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.Users", new[] { "GenderId" });
            AddColumn("dbo.Activities", "CaloriesPerMinute", c => c.Double(nullable: false));
            AddColumn("dbo.Eatings", "Food_Id", c => c.Int());
            AddColumn("dbo.Foods", "Proteins", c => c.Double(nullable: false));
            AddColumn("dbo.Foods", "Carbohydates", c => c.Double(nullable: false));
            AddColumn("dbo.Foods", "Calories", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "GenderId", c => c.Int());
            CreateIndex("dbo.Users", "GenderId");
            CreateIndex("dbo.Eatings", "Food_Id");
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
            AddForeignKey("dbo.Users", "GenderId", "dbo.Genders", "Id");
            DropColumn("dbo.Activities", "CalloriesPerMinute");
            DropColumn("dbo.Foods", "Protiens");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Protiens", c => c.Double(nullable: false));
            AddColumn("dbo.Activities", "CalloriesPerMinute", c => c.Double(nullable: false));
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            AlterColumn("dbo.Users", "GenderId", c => c.Int(nullable: false));
            DropColumn("dbo.Foods", "Calories");
            DropColumn("dbo.Foods", "Carbohydates");
            DropColumn("dbo.Foods", "Proteins");
            DropColumn("dbo.Eatings", "Food_Id");
            DropColumn("dbo.Activities", "CaloriesPerMinute");
            CreateIndex("dbo.Users", "GenderId");
            AddForeignKey("dbo.Users", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
    }
}
