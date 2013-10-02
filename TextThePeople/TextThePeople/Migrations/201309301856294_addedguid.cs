namespace TextThePeople.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedguid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "authKey", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "authKey");
        }
    }
}
