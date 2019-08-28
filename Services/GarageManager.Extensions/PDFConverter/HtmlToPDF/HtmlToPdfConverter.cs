using GarageManager.Extensions.PDFConverter.Enums;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace GarageManager.Extensions.PDFConverter.HtmlToPDF
{

    public class HtmlToPdfConverter : IHtmlToPdfConverter
    {
        private const string Input = "input_";
        private const string Output = "output_";
        private const string PhantomeExe = "phantomjs.exe";
        private const string RasterzePath = "wwwroot/js/rasterize.js";
        private const string HtmlFileExtencion = ".html";
        private const string PdfFileExtencion = ".pdf";
        public byte[] Convert(string basePath, string htmlCode, FormatType formatType = FormatType.a4, OrientationType orientationType= OrientationType.Portrait)
        {
            var inputFileName = $@"{Input}{Guid.NewGuid()}{HtmlFileExtencion}";
            var outputFileName = $"{basePath}/{Output}{Guid.NewGuid()}{PdfFileExtencion}";
            File.WriteAllText($"{inputFileName}", htmlCode);
            var startInfo = new ProcessStartInfo($"{PhantomeExe}")
            {
                WorkingDirectory = basePath,
                Arguments = $"{RasterzePath} \"{inputFileName}\" \"{outputFileName}\" \"{formatType}\" \"{orientationType.ToString().ToLower()}\"",
                UseShellExecute = true,
            };

            var process = new Process { StartInfo = startInfo };
            process.Start();
            process.WaitForExit();


            var bytes = File.ReadAllBytes($"{outputFileName}");


            File.Delete($"{basePath}/{inputFileName}");
            File.Delete($"{outputFileName}");

            return bytes;
        }
    }

}
