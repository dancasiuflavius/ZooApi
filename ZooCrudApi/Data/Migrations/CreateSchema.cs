using FluentMigrator;

namespace ZooCrudApi.Data.Migrations;

[Migration(03162024)]

public class CreateSchema:Migration
{
    public override void Up()
    {
        Create.Table("animals")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString(128).NotNullable()
            .WithColumn("category").AsString(128).NotNullable()
            .WithColumn("age").AsInt32().NotNullable()
            .WithColumn("date_of_birth").AsDateTime().NotNullable();
    }
    public override void Down()
    {
        
    }

}
