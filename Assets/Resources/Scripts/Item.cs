using System;

[Serializable]
public class Item
{
	public string itemName;

	public Item(InventoryItem item)
	{
		itemName = item.itemName;
	}
}