namespace Fake_Code_Analysis_Implementation_5_03.Utils.DAL
{
    public class Connections
    {
        public static string GetConnectionString()
        {
            string ConectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename = |DataDirectory|\CodeAnalysisDB.mdf;" +
                    "Initial Catalog = CodeAnalysisDB;" +
                       " Integrated Security = True ;";


            return ConectionString;
        }
       
    }
}