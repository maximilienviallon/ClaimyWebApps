namespace ClaimyWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateClaimTableAndForeignKeyTables : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO[dbo].[ZipCities] ([Zipcode], [City]) VALUES(N'6300', N'Gråsten')");
            Sql("INSERT INTO[dbo].[ZipCities([Zipcode], [City]) VALUES(N'6400', N'sønderborg')");
            Sql("INSERT INTO[dbo].[ZipCities([Zipcode], [City]) VALUES(N'6700', N'Esbjerg')");
            Sql("INSERT INTO[dbo].[Customers] ([Email], [Name], [Password]) VALUES(N'AndersAnderson@anderson.com', N'Anders', N'Andersi')");
            Sql("INSERT INTO[dbo].[Customers] ([Email], [Name], [Password]) VALUES(N'Andre@gmail.com', N'Andre', N'Andrei')");
            Sql("INSERT INTO[dbo].[Customers] ([Email], [Name], [Password]) VALUES(N'daut@dautmail.com', N'Daut', N'dauti')");
            Sql("INSERT INTO[dbo].[Customers] ([Email], [Name], [Password]) VALUES(N'max@gmail.com', N'Max', N'maxi')");
            Sql("INSERT INTO [dbo].[Claims] ([ID], [FeeNum], [Transgression], [Remarks], [LicensePlate], [DriversFirstName], [Address], [Appeal], [GuardNumber], [Amount], [PaymentInfo], [Zipcode], [CustomerEmail]) VALUES (5, 3015623, N'can''t park', N'still can''t park', N'JW-159-59', N'Max', N'something 11', N'I can park', N'123456789', N'1000', N'123123456456789789', N'6400', N'max@gmail.com')");
            Sql("INSERT INTO [dbo].[Claims] ([ID], [FeeNum], [Transgression], [Remarks], [LicensePlate], [DriversFirstName], [Address], [Appeal], [GuardNumber], [Amount], [PaymentInfo], [Zipcode], [CustomerEmail]) VALUES (6, 1569123, N'can''t park either', N'still cant''t park either', N'BB-420-69', N'Daut', N'dautstreet 22', N'I can Park', N'156878942', N'1023', N'1234597456375464150', N'6300', N'daut@dautmail.com')");
            Sql("INSERT INTO [dbo].[Claims] ([ID], [FeeNum], [Transgression], [Remarks], [LicensePlate], [DriversFirstName], [Address], [Appeal], [GuardNumber], [Amount], [PaymentInfo], [Zipcode], [CustomerEmail]) VALUES (11, 6543549, N'Something', N'because', N'BB-888-88', N'Andre', N'notsure 44', N'same as the others', N'463542315', N'500', N'210357489123456789', N'6400', N'andre@gmail.com')");
            Sql("INSERT INTO [dbo].[Claims] ([ID], [FeeNum], [Transgression], [Remarks], [LicensePlate], [DriversFirstName], [Address], [Appeal], [GuardNumber], [Amount], [PaymentInfo], [Zipcode], [CustomerEmail]) VALUES (12, 1327549, N'Can''t think of anything', N'ehhhhh', N'SD-333-11', N'Anders', N'somethingvej 46', N'same', N'415614234', N'70000', N'14237459151246745306', N'6700', N'AndersAnderson@anderson.com')");
        }

    public override void Down()
        {
        }
    }
}
