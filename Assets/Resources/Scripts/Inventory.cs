using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	public List<Item> items;
	public List<Pokemon> pokemons;

	public void AddItem(InventoryItem item)
	{
		Item itemToAdd = new Item(item);
		items.Add(itemToAdd);
	}

	public void RemoveItem(InventoryItem item)
	{
		Item itemToRemove = new Item(item);
		items.Remove(itemToRemove);
	}

	public void AddPokemon(Pokemon pokemon)
	{
		if (pokemons.Count <= 5)
		{
			pokemons.Add(pokemon);
		}
	}

	public void RemovePokemon(Pokemon pokemon)
	{
		if (pokemons.Count > 1)
		{
			pokemons.Remove(pokemon);
		}
	}
}