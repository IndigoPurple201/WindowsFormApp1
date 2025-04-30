using System;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

public class ConexionSQL
{
    private readonly string connectionString;
    private static bool mensajeMostrado = false;

    public ConexionSQL(string udlFilePath)
    {
        try
        {
            // Leer la cadena OLE DB desde el archivo .udl
            string oleDbConnectionString = File.ReadAllLines(udlFilePath)
                                               .FirstOrDefault(line => line.StartsWith("Provider=", StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(oleDbConnectionString))
                throw new InvalidOperationException("No se pudo leer la cadena de conexión desde el archivo UDL.");

            // Convertirla a formato SqlConnection
            connectionString = ConvertirOleDbAdoNet(oleDbConnectionString);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"❌ Error al leer el archivo UDL: {ex.Message}",
                            "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }

    private string ConvertirOleDbAdoNet(string oleDbConnectionString)
    {
        var builder = new OleDbConnectionStringBuilder(oleDbConnectionString);

        string servidor = builder.ContainsKey("Data Source") ? builder["Data Source"].ToString() : "";
        string db = builder.ContainsKey("Initial Catalog") ? builder["Initial Catalog"].ToString() : "";
        string usuario = builder.ContainsKey("User ID") ? builder["User ID"].ToString() : "";
        string contraseña = builder.ContainsKey("Password") ? builder["Password"].ToString() : "";
        bool integrado = builder.ContainsKey("Integrated Security") &&
                         builder["Integrated Security"].ToString().ToLower().Contains("sspi");

        if (integrado)
        {
            return $"Server={servidor};Database={db};Integrated Security=True;";
        }
        else
        {
            return $"Server={servidor};Database={db};User Id={usuario};Password={contraseña};";
        }
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
                    mensajeMostrado = true;
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



