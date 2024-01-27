using System.Web.UI.WebControls;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES(Name) VALUES('Action')");
            Sql("INSERT INTO GENRES(Name) VALUES('Thriller')");
            Sql("INSERT INTO GENRES(Name) VALUES('Fantasy')");
            Sql("INSERT INTO GENRES(Name) VALUES('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
