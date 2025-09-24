using DAL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.ModelControl.Admin
{
    public class V_UsuarioDBControl
    {
        public static List<V_UsuarioDB> ListaDB(int idusuario,int idTipoSistema)
        {
            var listaDB =new List<V_UsuarioDB>();
            listaDB= Task.Run(async () => 
            {
                try
                {
                    string query = $"select *from V_UsuarioDB where idUsuario={idusuario} and IdTipoSistema={idTipoSistema}";
                    var cn = new ConnectionSQL();
                    string resp=await cn.EjecutarConsulta(query,true);
                    List<V_UsuarioDB>? listaDB = new List<V_UsuarioDB>();
                    listaDB=JsonSerializer.Deserialize<List<V_UsuarioDB>>(resp);
                    if (listaDB.Count > 0)
                    {
                        return listaDB;
                    }
                    else
                    {
                        return new List<V_UsuarioDB>();
                    }
                    
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    return new List<V_UsuarioDB>();
                }

            }).Result;
            return listaDB;
        }
    }
}
