using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

public class ConexionSQL
{
    private readonly string connectionString;
    private static bool mensajeMostrado = false;

    public ConexionSQL()
    {
        // Verifica si la cadena de conexión está presente en App.config
        var conexionConfig = ConfigurationManager.ConnectionStrings["ConexionDB"];
        if (conexionConfig == null)
        {
            MessageBox.Show("Error: No se encontró la cadena de conexión en App.config.",
                            "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new InvalidOperationException("No se encontró la cadena de conexión en App.config.");
        }

        connectionString = conexionConfig.ConnectionString;
    }

    public SqlConnection ObtenerConexion()
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("La cadena de conexión no ha sido inicializada.");
        }
        return new SqlConnection(connectionString);
    }

    public void ProbarConexion()
    {
        if (!mensajeMostrado)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    //MessageBox.Show("✅ Conexión exitosa a la base de datos.",
                    //                "Conectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mensajeMostrado = true;  // Marca que el mensaje ya fue mostrado
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"⚠️ Error SQL: {sqlEx.Number}\n{sqlEx.Message}",
                                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error General:\n{ex.Message}\nStackTrace:\n{ex.StackTrace}",
                                    "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}


