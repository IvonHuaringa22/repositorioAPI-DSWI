using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;
using Microsoft.Data.SqlClient;

namespace Proyecto_DSWI_API_GP3.Data.Repository
{
    public class EventosRepository : IEventos
    {
        private readonly IConfiguration _config;
        public EventosRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Eventos> Listar()
        {
            List<Eventos> listado = new List<Eventos>();
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("ListarEventos", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listado.Add(new Eventos()
                        {
                            IdEvento = Convert.ToInt32(reader["IdEvento"]),
                            NombreEvento = reader["NombreEvento"].ToString(),
                            TipoEvento = reader["TipoEvento"].ToString(),
                            Lugar = reader["Lugar"].ToString(),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Hora = TimeSpan.Parse(reader["Hora"].ToString()),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }
            }
            return listado;
        }

        public IEnumerable<Eventos> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return Listar(); // este ya trae todos los eventos
            }
            List<Eventos> listado = new List<Eventos>();
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("BuscarEventosPorNombre", conexion);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreEvento", string.IsNullOrEmpty(nombre) ? DBNull.Value : nombre);

                SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listado.Add(new Eventos()
                        {
                            IdEvento = Convert.ToInt32(reader["IdEvento"]),
                            NombreEvento = reader["NombreEvento"].ToString(),
                            TipoEvento = reader["TipoEvento"].ToString(),
                            Lugar = reader["Lugar"].ToString(),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Hora = TimeSpan.Parse(reader["Hora"].ToString()),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }
            }
            return listado;
        }

        public bool Editar(Eventos eventos)
        {
            bool exito = false;
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("ActualizarEvento", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEvento", eventos.IdEvento);
                command.Parameters.AddWithValue("@NombreEvento", eventos.NombreEvento);
                command.Parameters.AddWithValue("@TipoEvento", eventos.TipoEvento);
                command.Parameters.AddWithValue("@Lugar", eventos.Lugar);
                command.Parameters.AddWithValue("@Fecha", eventos.Fecha);
                command.Parameters.AddWithValue("@Hora", eventos.Hora);
                command.Parameters.AddWithValue("@Descripcion", eventos.Descripcion);
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
                SqlCommand command = new SqlCommand("EliminarEvento", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEvento", id);
                exito = command.ExecuteNonQuery() > 0;
            }
            return exito;
        }

        public bool Registrar(Eventos eventos)
        {
            bool exito = false;
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("RegistrarEvento", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreEvento", eventos.NombreEvento);
                command.Parameters.AddWithValue("@TipoEvento", eventos.TipoEvento);
                command.Parameters.AddWithValue("@Lugar", eventos.Lugar);
                command.Parameters.AddWithValue("@Fecha", eventos.Fecha);
                command.Parameters.AddWithValue("@Hora", eventos.Hora);
                command.Parameters.AddWithValue("@Descripcion", eventos.Descripcion);
                exito = command.ExecuteNonQuery() > 0;
            }
            return exito;
        }

        public Eventos ObtenerPorId(int id)
        {
            Eventos evento = new Eventos();
            using (var conexion = new SqlConnection(_config["ConnectionStrings:local"]))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("ObtenerEvento", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEvento", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        evento.IdEvento = Convert.ToInt32(reader["IdEvento"]);
                        evento.NombreEvento = reader["NombreEvento"].ToString();
                        evento.TipoEvento = reader["TipoEvento"].ToString();
                        evento.Lugar = reader["Lugar"].ToString();
                        evento.Fecha = Convert.ToDateTime(reader["Fecha"]);
                        evento.Hora = TimeSpan.Parse(reader["Hora"].ToString());
                        evento.Descripcion = reader["Descripcion"].ToString();
                    }
                }
            }
            return evento;
        }
    }
}
