namespace TextThePeople.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectLoginDatabaseToServer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persons", "PhoneNumber", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persons", "PhoneNumber", c => c.String());
        }
    }
}
