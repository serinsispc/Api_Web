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

    // por defecto buscará "nombreDB" en los argumentos del action
    public TokenAndDbAttribute(string dbPropName = "nombreDB")
    {
        _dbPropName = dbPropName;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // 1) Validar token (igual que en TokenAuthorize)
        var http = context.HttpContext;
        var auth = http.Request.Headers["Authorization"].ToString();
        var token = (!string.IsNullOrWhiteSpace(auth) && auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    ? auth.Substring(7).Trim()
                    : http.Request.Query["token"].ToString();

        if (string.IsNullOrWhiteSpace(token) || !await ClassToken.VereficarToken(token))
        {
            context.Result = new UnauthorizedObjectResult(new { mensaje = "¡El token no es válido!" });
            return;
        }
        http.Items["BearerToken"] = token;

        // 2) Intentar setear ClassDBCliente.baseCliente desde cualquier argumento que tenga la propiedad indicada
        foreach (var arg in context.ActionArguments.Values.Where(v => v != null))
        {
            var prop = arg.GetType().GetProperty(_dbPropName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop != null && prop.PropertyType == typeof(string))
            {
                var dbName = prop.GetValue(arg) as string;
                if (!string.IsNullOrWhiteSpace(dbName))
                {
                    ClassDBCliente.baseCliente = dbName;
                    break;
                }
            }
        }

        await next();
    }
}
