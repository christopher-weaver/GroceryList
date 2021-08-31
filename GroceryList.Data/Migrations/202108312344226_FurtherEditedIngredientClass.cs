namespace GroceryList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurtherEditedIngredientClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ingredient", "DateOfPurchase");
            DropColumn("dbo.Ingredient", "ExpirationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredient", "ExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ingredient", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
