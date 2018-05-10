using UnityEngine;
using System;
using MySql.Data.MySqlClient;

public static class DatabaseHandler
{
	private static string connectionString = "Server=localhost;Database=pokemongame;User=root;Password=;SslMode=none";

	private static MySqlConnection connection = null;
	private static MySqlCommand command = null;
	private static MySqlDataReader dataReader = null;

	public static void Connection()
	{
		connection = new MySqlConnection(connectionString);
		connection.Open();
	}

	public static void Close()
	{
		connection.Close();
		connection.Dispose();
	}

	public static Pokemon GetPokemonByName(string pokemonName)
	{
		try
		{
			string query = "SELECT * FROM pokemons WHERE name = @name";
			command = new MySqlCommand(query, connection);
			command.Parameters.AddWithValue("@name", pokemonName);
			dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				Debug.Log(dataReader[0] + " -- " + dataReader["name"]);
			}

			dataReader.Close();
		}
		catch (Exception e)
		{
			Debug.Log(e);
		}

		return null;
	}
}