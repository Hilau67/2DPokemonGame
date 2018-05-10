using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private GameObject player;
	private Inventory inventory;
	private PlayerData playerData;
	
	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
		SceneManager.sceneUnloaded += OnLevelFinishedUnloading;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
		SceneManager.sceneUnloaded -= OnLevelFinishedUnloading;
	}

	private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		playerData.LoadData();
		inventory.items = playerData.items ?? new List<Item>();
		inventory.pokemons = playerData.pokemons ?? new List<Pokemon>();
		playerData.sceneName = scene.name;
	}

	private void OnLevelFinishedUnloading(Scene scene)
	{
		playerData.items = inventory.items;
		playerData.pokemons = inventory.pokemons;		
		playerData.SaveData();
	}

	private void Awake()
	{
		playerData = new PlayerData();
		playerData.LoadData();
		player = gameObject;
		player.transform.position = new Vector3(playerData.x, playerData.y);
		inventory = player.GetComponent<Inventory>();

		if (playerData.sceneName != null)
		{
			SceneManager.LoadScene(playerData.sceneName, LoadSceneMode.Single);
		}

		DontDestroyOnLoad(this);
	}

	private void OnDestroy()
	{
		playerData.x = player.transform.position.x;
		playerData.y = player.transform.position.y;
		playerData.SaveData();
	}
}
