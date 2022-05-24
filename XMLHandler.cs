using System.Data;
using System.IO;

namespace ConvertXMLsToCSV
{
    public class XMLHandler
    {
        public static DataSet GetDataFromFilesInDirectory( string directory )
        {
            DataSet ds = new();

            string[] paths = Directory.GetFiles( directory );
            foreach ( string path in paths )
            {
                ds.ReadXml( path );
            }

            return ds;
        }
    }
}
