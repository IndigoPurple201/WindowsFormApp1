using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

public class ConexionSQL
{
    private string connectionString;
    private static bool mensajeMostrado = false;

    public ConexionSQL()
    {
        connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
    }

    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(connectionString);
    }

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

