namespace UI.tests.Models
{
    using System;
    using System.Configuration;
    using System.Data.OleDb;
    using System.Linq;
    using Dapper;

    public class AccessExcelData
    {
        public static string ConnectionForRegistrationUser()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\x86\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["TestDataSheetPath"];
            var filename = "RegistrationUser.xlsx";

            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + filename);
            return con;
        }

        public static RegistrationUser GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(ConnectionForRegistrationUser()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName);
                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

       // public static string ConnectionsForLoginUser()
       // {
       //     var path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\x86\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["TestDataSheetPath"];
       //     var filename = "LoginUser.xlsx";
       //
       //     var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		//                              Data Source = {0}; 
		//                              Extended Properties=Excel 12.0;", path + filename);
       //     return con;
       // }
       //
       // public static LoginUser GetLoginData(string keyName)
       // {
       //     using (var connection = new OleDbConnection(ConnectionForLoginUser()))
       //     {
       //         connection.Open();
       //         var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName);
       //         var value = connection.Query<LoginUser>(query).FirstOrDefault();
       //         connection.Close();
       //         return value;
       //     }
       // }
    }
}
