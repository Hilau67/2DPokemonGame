using UnityEngine;

public class Stairs : BaseTrigger
{
	protected override void Start()
	{
		base.Start();
	}

	protected override bool OnTriggerStay2D(Collider2D collision)
	{
		bool hasMove = base.OnTriggerStay2D(collision);

		if(hasMove)
		{
			Player.direction = Direction.Down;
		}

		return false;
	}
}
