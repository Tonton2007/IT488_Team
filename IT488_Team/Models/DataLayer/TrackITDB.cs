

namespace IT488_Team.Models.DataLayer
{
    internal class TrackITDB
    {
        /*
         *  use TrackIT
            select ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation
            from Products

        CREATE LOGIN Midnightcoders  
    WITH PASSWORD = '123456';  
GO  

        */
        public static readonly string ConnectionString = @"Data Source=DESKTOP-JOLUDPU\SQLEXPRESS;Initial Catalog=TrackIT;Integrated Security=True";

       // public static readonly string ConnectionString = @"Data Source=DESKTOP-JOLUDPU\SQLEXPRESS;Initial Catalog=TrackIT;Integrated Security=True";
}
}
