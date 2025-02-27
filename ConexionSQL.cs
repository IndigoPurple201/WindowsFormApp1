using System;
using Microsoft.Data.SqlClient;

public class ConexionSQL
{
    // Cadena de conexión para Windows Authentication
    private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";
    private static bool mensajeMostrado = false;

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
                if (!mensajeMostrado)
                {
                    MessageBox.Show("Conexión exitosa a la base de datos.", "Conectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mensajeMostrado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

