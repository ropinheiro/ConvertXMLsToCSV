using System.Configuration;

namespace ConvertXMLsToCSV
{
    public class Configs
    {
        public string inputDirectory =
            ConfigurationManager.AppSettings[ "inputDirectory" ];

        public string outputDirectory =
            ConfigurationManager.AppSettings[ "outputDirectory" ];

        public string outputFile =
            ConfigurationManager.AppSettings[ "outputFile" ];
    }
}
