using UnityEngine;

public class Door : BaseTrigger
{
	protected override void Start()
	{
		base.Start();
	}

	protected override bool OnTriggerStay2D(Collider2D collision)
	{
		return base.OnTriggerStay2D(collision);
	}
}
