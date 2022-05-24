using System.Data;
using System.IO;
using System.Text;

namespace ConvertXMLsToCSV
{
    class Program
    {
        static void Main( /* string[] args */ )
        {
            Configs configs = new(); // TODO: use args to override default configs.
            DataSet ds = GetDataFromFiles( configs.inputDirectory );
            string contents = ConvertDataToCsv( ds );
            string outputPath = Path.Combine( configs.outputDirectory, configs.outputFile );
            WriteToFile( outputPath, contents );
            // TODO: give feedback to user
        }

        public class Configs
        {
            public string inputDirectory = @".\data\";
            public string outputDirectory = @".\";
            public string outputFile = "output.csv";
        }

        static DataSet GetDataFromFiles( string inputDirectory )
        {
            DataSet ds = new();

            string[] paths = Directory.GetFiles( inputDirectory );
            foreach ( string path in paths )
            {
                ds.ReadXml( path );
            }

            return ds;
        }

        static string ConvertDataToCsv( DataSet ds )
        {
            StringBuilder csvContent = new();

            DataTable annotations = ds.Tables[ 0 ];   // Tables[0] contain simple values in <annotation>
            // Ignore Tables[1]                       // Tables[1] contain simple values in <annotation> -> <size>
            // Ignore Tables[2]                       // Tables[2] contain simple values in <annotation> -> <object>
            DataTable boundingBoxes = ds.Tables[ 3 ]; // Tables[3] contain simple values in <annotation> -> <object> -> <bndbox>

            for ( int i = 0; i < annotations.Rows.Count; i++ )
            {
                DataRow annotation = annotations.Rows[ i ];
                DataRow boundingBox = boundingBoxes.Rows[ i ];

                string filename = annotation[ "filename" ].ToString();
                string xmin = boundingBox[ "xmin" ].ToString();
                string ymin = boundingBox[ "ymin" ].ToString();
                string xmax = boundingBox[ "xmax" ].ToString();
                string ymax = boundingBox[ "ymax" ].ToString();

                csvContent.AppendLine( $"{filename},{xmin},{ymin},{xmax},{ymax}" );
            }

            return csvContent.ToString();
        }

        static void WriteToFile( string outputPath, string contents )
        {
            File.WriteAllText( outputPath, contents );
        }
    }
}