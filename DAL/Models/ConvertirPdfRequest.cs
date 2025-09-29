using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    // Models/ConvertirPdfRequest.cs
    public class ConvertirPdfRequest
    {
        /// <summary>String Base64 del PDF. Puede venir con prefijo data:application/pdf;base64,</summary>
        public string PdfBase64 { get; set; }

        /// <summary>Nombre sugerido para el archivo (opcional). Ej: "factura_123.pdf"</summary>
        public string FileName { get; set; }
    }

}
