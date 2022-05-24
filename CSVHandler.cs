using System.Data;
using System.IO;
using System.Text;

namespace ConvertXMLsToCSV
{
    public class CSVBuilder
    {
        private readonly string Contents = string.Empty;

        public CSVBuilder( DataSet ds )
        {
            Contents = ConvertDataToCsv( ds );
        }

        private static string ConvertDataToCsv( DataSet ds )
        {
            StringBuilder sb = new();

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

                sb.AppendLine( $"{filename},{xmin},{ymin},{xmax},{ymax}" );
            }

            return sb.ToString();
        }

        public void WriteToFile( string outputPath )
        {
            File.WriteAllText( outputPath, Contents );
        }
    }
}
