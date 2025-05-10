using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;
using Proyecto_DSWI_API_GP3.Models.DTO;
using Microsoft.Data.SqlClient;
using Proyecto_DSWI_API_GP3.Models.DTO.Usuario;

namespace Proyecto_DSWI_API_GP3.Data.Repository
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly IConfiguration _config;
        public UsuariosRepository(IConfiguration config)
        {
            _config = config;
        }
        public bool Actualizar(ActualizarDTO usuario)
        {
            bool exito = false;

            Usuarios user = ObtenerPorId(usuario.IdUsuario);

            if (user == null) {
                return exito;
            }

            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("ActualizarUsuario", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                exito = command.ExecuteNonQuery() > 0;
            }
            return exito;
        }

        public bool Eliminar(int id)
        {
            bool exito = false;
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("EliminarUsuario", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", id);
                exito = command.ExecuteNonQuery() > 0;
            }
            return exito;
        }

        public IEnumerable<Usuarios> Listar()
        {
            List<Usuarios> listado = new List<Usuarios>();
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("ListarUsuarios", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listado.Add(new Usuarios()
                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Correo = reader.GetString(2),
                            Contraseña = reader.GetString(3),
                            TipoUsuario = reader.GetString(4)
                        });
                    }
                }

            }
            return listado;
        }

        public Usuarios ObtenerPorId(int id)
        {
            Usuarios usuarios = null;
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("ObtenerUsuario", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    reader.Read();
                    usuarios = new Usuarios()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Correo = reader.GetString(2),
                        Contraseña = reader.GetString(3),
                        TipoUsuario = reader.GetString(4)
                    };
                }
            }
            return usuarios;
        }

        public bool Registrar(RegistrarDTO usuarios)
        {
            bool exito = false;

            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("RegistrarUsuario", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
                command.Parameters.AddWithValue("@Correo", usuarios.Correo);
                command.Parameters.AddWithValue("@Contraseña", usuarios.Contraseña);
                command.Parameters.AddWithValue("@TipoUsuario", usuarios.TipoUsuario);
                exito = command.ExecuteNonQuery() > 0;
            }
            return exito;
        }
    }
}
