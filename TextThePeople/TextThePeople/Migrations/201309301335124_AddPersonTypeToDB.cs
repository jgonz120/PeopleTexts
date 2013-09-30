namespace TextThePeople.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonTypeToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persons", "PersonType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persons", "PersonType");
        }
    }
}
