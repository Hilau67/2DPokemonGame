using UnityEngine;

public class InventoryItem : InventoryController
{
	public string itemName;

	protected override bool OnTriggerStay2D(Collider2D collision)
	{
		if (base.OnTriggerStay2D(collision))
		{
			SetButtonsAction(YesEvent, NoEvent);
		}

		return false;
	}

	public void YesEvent()
	{
		base.Event();
		AddItem(this);
	}

	public void NoEvent()
	{
		base.Event();
	}
}
