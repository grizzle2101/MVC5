namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSeedDataForMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded,NumberInStock) VALUES ('Tropic Thunder', 'Comedy', '2008-11-11', '2008-11-12', 5)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded,NumberInStock) VALUES ('Savign Private Ryan', 'Thriller', '2001-03-01', '2008-11-12', 2)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded,NumberInStock) VALUES ('Frozen', 'Kids', '2016-08-20', '2016-11-15', 10)");
        }
        
        public override void Down()
        {
        }
    }
}
