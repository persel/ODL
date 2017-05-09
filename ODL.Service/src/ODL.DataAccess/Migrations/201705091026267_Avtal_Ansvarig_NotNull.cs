namespace ODL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Avtal_Ansvarig_NotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Avtal.Avtal", "Ansvarig", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Avtal.Avtal", "Ansvarig", c => c.Boolean());
        }
    }
}
