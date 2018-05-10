using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseTrigger : MonoBehaviour
{
	public float x, y;
	public Object sceneToLoad;

	protected GameObject player;
	protected const string playerTag = "Player";

	protected virtual void Start()
	{
		player = GameObject.FindGameObjectWithTag(playerTag);
	}

	private void PlacePlayer()
	{
		player.transform.position = new Vector3(x, y, 0);
	}

	protected virtual bool OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag(playerTag) && Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Single);
			PlacePlayer();

			return true;
		}

		return false;
	}
}
