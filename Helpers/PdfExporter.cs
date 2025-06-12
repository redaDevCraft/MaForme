using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MaForme.Helpers
{
    public static class PdfExporter
    {
        public static void ExportForm<T>(T data, string outputPath, string title, IEnumerable<string> staticTexts)
        {
            using (PdfWriter writer = new PdfWriter(outputPath))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf, PageSize.A4))
            {
                // Set margins: 2 cm all around (adjust as needed)
                document.SetMargins(50, 50, 50, 50);

                // Title / Header
                document.Add(new Paragraph(title)
                    .SetFontSize(22)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20));

                // Dynamic Fields (use reflection to make it generic)
                foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var value = prop.GetValue(data)?.ToString() ?? "";
                    document.Add(new Paragraph($"{prop.Name}: {value}")
                        .SetFontSize(12)
                        .SetMarginBottom(5));
                }

                // Add spacing before static content
                document.Add(new Paragraph(" ").SetMarginBottom(20));

                // Static content (Company, date, signature, etc.)
                foreach (var staticText in staticTexts)
                {
                    document.Add(new Paragraph(staticText)
                        .SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginBottom(5));
                }

                document.Close();
            }
        }
    }
}
