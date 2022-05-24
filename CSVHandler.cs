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

            /*
             * Parsing the DS according to the original XML:
             * (TODO: how to make this generic?)
             * 
             <annotation>       -> Table[0] or "annotation"
                <folder>...
                <filename>... - - - - - - - - - - - - - - - - - ** wanted **
                <size>          -> Table[1] or "size"
                   ...
                </size>
                <segmented>...
                <object>        -> Table[2] or "object"
                    <name>...
                    <pose>...
                    <truncated>...
                    <occluded>...
                    <difficult>...
                    <bndbox>    -> Table[3] or "bndbox"
                        <xmin>... - - - - - - - - - - - - - - - ** wanted **
                        <ymin>... - - - - - - - - - - - - - - - ** wanted **
                        <xmax>... - - - - - - - - - - - - - - - ** wanted **
                        <ymax>... - - - - - - - - - - - - - - - ** wanted **
             */
            DataTable annotations = ds.Tables[ "annotation" ];
            DataTable boundingBoxes = ds.Tables[ "bndbox" ];

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
