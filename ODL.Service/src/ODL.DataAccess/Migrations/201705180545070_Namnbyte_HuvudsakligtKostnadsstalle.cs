namespace ODL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Namnbyte_HuvudsakligtKostnadsstalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("Avtal.OrganisationAvtal", "HuvudsakligtKostnadsstalle", c => c.Boolean(nullable: false));
            DropColumn("Avtal.OrganisationAvtal", "Huvudkostnadsstalle");
        }
        
        public override void Down()
        {
            AddColumn("Avtal.OrganisationAvtal", "Huvudkostnadsstalle", c => c.Boolean(nullable: false));
            DropColumn("Avtal.OrganisationAvtal", "HuvudsakligtKostnadsstalle");
        }
    }
}
