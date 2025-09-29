using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        // Ajusta el límite si esperas PDFs grandes (10 MB en el ejemplo)
        [HttpPost("desde-base64")]
        [RequestSizeLimit(10_000_000)] // 10 MB
        public IActionResult DesdeBase64([FromBody] ConvertirPdfRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.PdfBase64))
                return BadRequest(new { mensaje = "PdfBase64 es requerido." });

            try
            {
                // 1) Limpia posibles prefijos tipo: data:application/pdf;base64,AAAA...
                var base64 = LimpiarPrefijoDataUri(req.PdfBase64);

                // 2) Quita espacios/blancos que a veces rompen el decode
                base64 = base64.Trim();

                // 3) Decodifica
                byte[] bytes;
                try
                {
                    bytes = Convert.FromBase64String(base64);
                }
                catch (FormatException)
                {
                    return BadRequest(new { mensaje = "El contenido no es Base64 válido." });
                }

                if (bytes.Length == 0)
                    return BadRequest(new { mensaje = "El contenido Base64 está vacío." });

                // 4) Nombre de archivo
                var fileName = string.IsNullOrWhiteSpace(req.FileName) ? "documento.pdf" : SanearNombre(req.FileName);

                // 5) Retorna el PDF como archivo (descarga o inline)
                // Para forzar descarga:
                // return File(bytes, "application/pdf", fileName);

                // Para mostrar inline en el navegador:
                Response.Headers["Content-Disposition"] = $"inline; filename=\"{fileName}\"";
                return File(bytes, "application/pdf");
            }
            catch (Exception ex)
            {
                // Loguea ex si corresponde
                return StatusCode(500, new { mensaje = "Error al convertir el PDF.", detalle = ex.Message });
            }
        }

        private static string LimpiarPrefijoDataUri(string input)
        {
            // Remueve: data:application/pdf;base64,   (o cualquier data:*;base64,)
            var match = Regex.Match(input, @"^data:.*;base64,", RegexOptions.IgnoreCase);
            return match.Success ? input.Substring(match.Length) : input;
        }

        private static string SanearNombre(string fileName)
        {
            // Evita caracteres problemáticos
            foreach (var c in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c, '_');

            // Asegura extensión .pdf
            if (!fileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                fileName += ".pdf";

            return fileName;
        }
    }
}
