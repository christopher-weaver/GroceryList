namespace GroceryList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredient", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Pantry", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Recipe", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShoppingList", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingList", "UserId");
            DropColumn("dbo.Recipe", "UserId");
            DropColumn("dbo.Pantry", "UserId");
            DropColumn("dbo.Ingredient", "UserId");
        }
    }
}
