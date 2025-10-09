using Api.Class;
using DAL.ModelControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class TokenAndDbAttribute : Attribute, IAsyncActionFilter
{
    private readonly string _dbPropName;

    // Por defecto buscará "nombreDB" en los argumentos del action
    public TokenAndDbAttribute(string dbPropName = "nombreDB")
    {
        _dbPropName = dbPropName;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var http = context.HttpContext;

        // ==============================================
        // 1️⃣ Validar TOKEN (Bearer o query ?token=)
        // ==============================================
        var auth = http.Request.Headers["Authorization"].ToString();
        var token = (!string.IsNullOrWhiteSpace(auth) && auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    ? auth.Substring(7).Trim()
                    : http.Request.Query["token"].ToString();

        if (string.IsNullOrWhiteSpace(token) || !await ClassToken.VereficarToken(token))
        {
            context.Result = new UnauthorizedObjectResult(new { mensaje = "¡El token no es válido o ha expirado!" });
            return;
        }

        // Guardar el token para uso interno (si se necesita)
        http.Items["BearerToken"] = token;

        // ==============================================
        // 2️⃣ Determinar nombre de la base de datos (DB)
        // ==============================================

        string dbName = null;

        // a) Intentar obtenerlo desde los argumentos del método
        foreach (var arg in context.ActionArguments.Values.Where(v => v != null))
        {
            var prop = arg.GetType().GetProperty(_dbPropName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop != null && prop.PropertyType == typeof(string))
            {
                dbName = prop.GetValue(arg) as string;
                if (!string.IsNullOrWhiteSpace(dbName))
                    break;
            }
        }

        // b) Si no lo encuentra en los argumentos, buscar en los headers personalizados
        if (string.IsNullOrWhiteSpace(dbName) && http.Request.Headers.ContainsKey("X-NombreDB"))
        {
            dbName = http.Request.Headers["X-NombreDB"].ToString()?.Trim();
        }

        // c) Si no viene ni en parámetros ni en header, error controlado
        if (string.IsNullOrWhiteSpace(dbName))
        {
            context.Result = new BadRequestObjectResult(new { mensaje = "No se recibió el nombre de la base de datos (X-NombreDB)." });
            return;
        }

        // d) Asignar la base al manejador global
        ClassDBCliente.baseCliente = dbName;

        // Continuar la ejecución del endpoint
        await next();
    }
}
