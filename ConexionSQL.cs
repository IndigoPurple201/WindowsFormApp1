using System;
using Microsoft.Data.SqlClient;

public class ConexionSQL
{
    // Cadena de conexión para Windows Authentication
    private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";

    // Método para obtener la conexión
    public SqlConnection ObtenerConexion()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }

    // Método para probar la conexión a la base de datos y mostrar un mensaje
    public void ProbarConexion()
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            try
            {
                connection.Open();
                // Si la conexión es exitosa, muestra un mensaje de éxito
                MessageBox.Show("Conexión exitosa con la base de datos.");
            }
            catch (Exception ex)
            {
                // Si hay algún error, muestra el mensaje de error
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }
    }
}

