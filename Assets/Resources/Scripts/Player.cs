using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Player
{
	public static Direction direction;
	public static bool isSpeaking;
}

[Serializable]
public class PlayerData
{
	public Direction direction;
	public List<Item> items;
	public List<Pokemon> pokemons;
	public string sceneName;
	public float x;
	public float y;

	public void SaveData()
	{
		direction = Player.direction;

		var bf = new BinaryFormatter();
		var file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.OpenOrCreate);
		bf.Serialize(file, this);
		file.Close();
	}

	public void LoadData()
	{
		if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
		{
			var bf = new BinaryFormatter();
			var file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			direction = Player.direction = data.direction;
			items = data.items;
			pokemons = data.pokemons;
			sceneName = data.sceneName;
			x = data.x;
			y = data.y;
		}
	}
}
