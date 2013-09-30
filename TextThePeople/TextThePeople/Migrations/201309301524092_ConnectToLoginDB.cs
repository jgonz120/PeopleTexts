namespace TextThePeople.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectToLoginDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persons", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persons", "PhoneNumber", c => c.String(maxLength: 11));
        }
    }
}
