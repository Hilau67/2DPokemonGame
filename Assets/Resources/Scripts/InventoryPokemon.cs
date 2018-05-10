using UnityEngine;
using System.Collections.Generic;

public class InventoryPokemon : InventoryController
{
	public string pokemonName;

	protected override bool OnTriggerStay2D(Collider2D collision)
	{
		if (!HasUserTookStarter())
		{
			if (base.OnTriggerStay2D(collision))
			{
				SetButtonsAction(YesEvent, NoEvent);
			}			
		}

		return false;
	}
	
	public void YesEvent()
	{
		base.Event();

		//BasePokemon.Types type = pokemonName == "Squirtle" ? BasePokemon.Types.Water : pokemonName == "Charmander" ? BasePokemon.Types.Fire : BasePokemon.Types.Grass;
		//List<BasePokemon.Types> types = new List<BasePokemon.Types>() { type };
		Pokemon pokemon = new Pokemon(pokemonName, 5);
		AddPokemon(pokemon);
		Destroy(transform.parent.gameObject);
	}

	public void NoEvent()
	{
		base.Event();
	}
}
