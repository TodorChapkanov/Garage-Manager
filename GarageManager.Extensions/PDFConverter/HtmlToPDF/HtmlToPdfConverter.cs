using GarageManager.Extensions.PDFConverter.Enums;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace GarageManager.Extensions.PDFConverter.HtmlToPDF
{

    public class HtmlToPdfConverter : IHtmlToPdfConverter
    {
        public  byte[] Convert(string basePath, string htmlCode, FormatType formatType, OrientationType orientationType)
        {
            var inputFileName = $@"input_{Guid.NewGuid()}.html";
            var outputFileName = $"{basePath}/output_{Guid.NewGuid()}.pdf";
            File.WriteAllText($"{inputFileName}", htmlCode);
           // inputFileName = $"{basePath}/{inputFileName}";
            var startInfo = new ProcessStartInfo("phantomjs.exe")
            {
                WorkingDirectory = basePath,
                Arguments = $"rasterize.js \"{inputFileName}\" \"{outputFileName}\" \"{formatType}\" \"{orientationType.ToString().ToLower()}\"",
                UseShellExecute = false,
            };

            var process = new Process { StartInfo = startInfo };
            process.Start();
            process.WaitForExit();
            var code = process.ExitCode;

            var bytes = File.ReadAllBytes($"{outputFileName}");

            
           File.Delete($"{basePath}/{inputFileName}");

            return bytes;
        }

        public void ConsumeReader(TextReader reader)
        {
            string text;

            while ((text = reader.ReadLine()) != null)
            {
                Console.WriteLine(text);
            }
        }

    }

}
