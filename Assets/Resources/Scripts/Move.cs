using UnityEngine;

public class Move : MonoBehaviour
{
	public Sprite NorthSprite;
	public Sprite SouthSprite;
	public Sprite WestSprite;
	public Sprite EastSprite;

	private const float speed = 1.5f;
	private Rigidbody2D rigidBody;
	private Animator animator;
	private SpriteRenderer spriteRendererPlayer;
	private Bounds boundsMap;
	private Camera cam;
	private const string mapTag = "Map";
	private const string cameraTag = "MainCamera";
	private const string idleState = "Idle";

	private void Start ()
	{		
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spriteRendererPlayer = GetComponent<SpriteRenderer>();
		boundsMap = GameObject.FindGameObjectWithTag(mapTag).GetComponentInChildren<MeshRenderer>().bounds;
		cam = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
		DontDestroyOnLoad(this);
		DontDestroyOnLoad(cam);
	}
	
	private void Update ()
	{
		animator.SetFloat("SpeedX", 0);
		animator.SetFloat("SpeedY", 0);
		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");

		if (x < 0 || x > 0) // Left or right
		{
			rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
			transform.Translate(Vector3.right * x * speed * Time.deltaTime);
			animator.SetFloat("SpeedX", x);
			Player.direction = (x > 0) ? Direction.Right : Direction.Left;
		}
		else if (y < 0 || y > 0) // Up or down
		{
			rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
			transform.Translate(Vector3.up * y * speed * Time.deltaTime);
			animator.SetFloat("SpeedY", y);
			Player.direction = (y > 0) ? Direction.Up : Direction.Down;
		}
	}

	private void LateUpdate()
	{
		ReloadSprite();
		PlaceCamera();
	}

	private void ReloadSprite()
	{
		AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

		if (currentState.IsName(idleState))
		{
			switch (Player.direction)
			{
				case Direction.Right:
					spriteRendererPlayer.sprite = EastSprite;
					break;

				case Direction.Left:
					spriteRendererPlayer.sprite = WestSprite;
					break;

				case Direction.Up:
					spriteRendererPlayer.sprite = NorthSprite;
					break;

				case Direction.Down:
					spriteRendererPlayer.sprite = SouthSprite;
					break;
			}
		}

	}

	private void PlaceCamera()
	{
		float camVertExtent = cam.orthographicSize;
		float camHorzExtent = cam.aspect * camVertExtent;

		float leftBound = boundsMap.min.x + camHorzExtent;
		float rightBound = boundsMap.max.x - camHorzExtent;
		float bottomBound = boundsMap.min.y + camVertExtent;
		float topBound = boundsMap.max.y - camVertExtent;

		float camX = Mathf.Clamp(transform.position.x, leftBound, rightBound);
		float camY = Mathf.Clamp(transform.position.y, bottomBound, topBound);

		cam.transform.position = new Vector3(camX, camY, cam.transform.position.z);
	}
}