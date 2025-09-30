using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System;

namespace Api.Controllers
{
    // DTO que coincide con TU JSON (nombres y tipos)
    public class VentaExportDto
    {
        public int id { get; set; }
        public DateTime fechaVenta { get; set; }
        public string tipoFactura { get; set; } = "";
        public string prefijo { get; set; } = "";
        public string numeroVenta { get; set; } = "";
        public string nit { get; set; } = "";
        public string nombreCliente { get; set; } = "";
        public decimal iva { get; set; }
        public decimal totalVenta { get; set; }
        public decimal propina { get; set; }
        public string estadoFE { get; set; } = "";
        public string cufe { get; set; } = "";
    }

    [ApiController]
    [Route("api/export")]
    public class ExportController : ControllerBase
    {
        [HttpPost("ventas-excel")]
        public IActionResult ExportarVentasExcel([FromBody] List<VentaExportDto> ventas)
        {
            if (ventas == null || ventas.Count == 0)
                return BadRequest("No se recibieron datos para exportar.");

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Ventas");

            // Encabezados
            var headers = new[]
            {
                "Id","Fecha Venta","Tipo Factura","Prefijo","Número Venta","NIT",
                "Nombre Cliente","IVA","Total Venta","Propina","Estado FE","CUFE"
            };
            for (int c = 0; c < headers.Length; c++)
                ws.Cell(1, c + 1).Value = headers[c];

            // Datos
            int r = 2;
            foreach (var v in ventas)
            {
                ws.Cell(r, 1).SetValue(v.id);
                ws.Cell(r, 2).SetValue(v.fechaVenta);
                ws.Cell(r, 3).SetValue(v.tipoFactura ?? "");
                ws.Cell(r, 4).SetValue(v.prefijo ?? "");
                ws.Cell(r, 5).SetValue(v.numeroVenta ?? "");
                ws.Cell(r, 6).SetValue(v.nit ?? "");
                ws.Cell(r, 7).SetValue(v.nombreCliente ?? "");
                ws.Cell(r, 8).SetValue(v.iva);
                ws.Cell(r, 9).SetValue(v.totalVenta);
                ws.Cell(r, 10).SetValue(v.propina);
                ws.Cell(r, 11).SetValue(v.estadoFE ?? "");
                ws.Cell(r, 12).SetValue(v.cufe ?? "");
                r++;
            }

            // Formatos
            ws.Column(2).Style.DateFormat.Format = "yyyy-MM-dd HH:mm:ss";
            ws.Columns(8, 10).Style.NumberFormat.Format = "#,##0.00";
            ws.RangeUsed().SetAutoFilter();
            ws.SheetView.FreezeRows(1);
            ws.Columns().AdjustToContents();

            // Descargar
            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            var bytes = ms.ToArray();
            var fileName = $"ventas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            return File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
