using DAL.Models.DBCliente;
using DAL_P.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class v_UsuarioControl
    {
        public static v_Usuario ConsultarUser(string usuario,string clave)
        {
            try
            {
                var user = new v_Usuario();
                user = Task.Run(async() => {
                    string query = $"select *from v_Usuario where cuentaUsuario='{usuario}' and claveUsuario='{clave}'";
                    var cn =new ConnectionSQL();
                    string resp=await cn.EjecutarConsulta(query,false);
                    v_Usuario? v_Usuario = new v_Usuario();
                    v_Usuario=JsonSerializer.Deserialize<v_Usuario>(resp);
                    if (v_Usuario != null) 
                    {
                        return v_Usuario;
                    }
                    else
                    {
                        return new v_Usuario();
                    }
                }).Result;
                return user;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new v_Usuario();
            }
        }
        public static V_Usuario ConsultarUserP(string usuario, string clave)
        {
            try
            {
                var user = new V_Usuario();
                user = Task.Run(async () => {
                    string query = $"select *from V_Usuario where cuenta_usuario='{usuario}' and clave_usuario='{clave}'";
                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query, false);
                    V_Usuario? v_Usuario = new V_Usuario();
                    v_Usuario = JsonSerializer.Deserialize<V_Usuario>(resp);
                    if (v_Usuario != null)
                    {
                        return v_Usuario;
                    }
                    else
                    {
                        return new V_Usuario();
                    }
                }).Result;
                return user;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new V_Usuario();
            }
        }

    }
}
