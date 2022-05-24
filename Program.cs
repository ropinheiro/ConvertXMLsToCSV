using System.Data;
using System.IO;

namespace ConvertXMLsToCSV
{
    class Program
    {
        static void Main( /* string[] args */ )
        {
            Configs configs = new(); // TODO: use args to override default configs.

            DataSet ds = XMLHandler.GetDataFromFilesInDirectory( configs.inputDirectory );

            CSVBuilder csvBuilder = new( ds );

            string outputPath = Path.Combine( configs.outputDirectory, configs.outputFile );
            csvBuilder.WriteToFile( outputPath );
            // TODO: give feedback to user
        }
    }
}