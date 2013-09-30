namespace TextThePeople.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoNullsInPersonType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persons", "PersonType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persons", "PersonType", c => c.Int());
        }
    }
}
