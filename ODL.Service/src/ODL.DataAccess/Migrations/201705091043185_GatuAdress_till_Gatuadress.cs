namespace ODL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GatuAdress_till_Gatuadress : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Adress.GatuAdress", newName: "Gatuadress");
        }
        
        public override void Down()
        {
            RenameTable(name: "Adress.Gatuadress", newName: "GatuAdress");
        }
    }
}
