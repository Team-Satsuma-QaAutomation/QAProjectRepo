namespace Unit.tests
{
    using Dapper;
    using System;
    using System.Data.OleDb;
    using System.Linq;
    using System.Configuration;
    using Sections;

    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["TestDataSheetPath"];
            var filename = "input_test_data.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + filename);
            return con;
        }

        public static InputData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [TestDataSheetPath$] where key = '{0}'", keyName);
                var value = connection.Query<InputData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
