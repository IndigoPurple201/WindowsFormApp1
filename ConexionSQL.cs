﻿using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

public class ConexionSQL
{
    private readonly string connectionString;
    private static bool mensajeMostrado = false;

    public ConexionSQL()
    {
        try
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("No se pudo leer la cadena de conexión.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"❌ Error al leer el archivo UDL: {ex.Message}",
                            "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
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



