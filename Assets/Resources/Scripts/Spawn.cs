using UnityEngine;

public class Spawn : MonoBehaviour
{
	private void Start ()
	{
		const string folderPathPrefabs = "Prefabs/";
		const string playerPath = folderPathPrefabs + "Characters/Player";
		const string cameraPath = folderPathPrefabs + "Main Camera";
		const string playerTag = "Player";
		const string cameraTag = "MainCamera";

		var player = GameObject.FindGameObjectWithTag(playerTag);
		var cam = GameObject.FindGameObjectWithTag(cameraTag);

		if (!player)
		{
			player = Instantiate(Resources.Load(playerPath, typeof(GameObject)), new Vector3(0.3f, 4, 0), Quaternion.identity) as GameObject;
		}

		if (!cam)
		{
			cam = Instantiate(Resources.Load(cameraPath, typeof(GameObject))) as GameObject;
		}
	}
}
