using GarageManager.Extensions.PDFConverter.Enums;
using System;
using System.Diagnostics;
using System.IO;

namespace GarageManager.Extensions.PDFConverter.HtmlToPDF
{
    public interface IHtmlToPdfConverter
    {
        byte[] Convert(string basePath, string htmlCode, FormatType formatType, OrientationType orientationType);
    }
}
