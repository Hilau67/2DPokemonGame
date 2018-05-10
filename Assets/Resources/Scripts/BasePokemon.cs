using System;
using System.Collections.Generic;

[Serializable]
public class BasePokemon
{
	public enum Types
	{
		Normal = 1,
		Fire = 2,
		Water = 3,
		Fighting = 4,
		Flying = 5,
		Grass = 6,
		Poison = 7,
		Electric = 8,
		Ground = 9,
		Psychic = 10,
		Rock = 11,
		Ice = 12,
		Bug = 13,
		Dragon = 14,
		Ghost = 15,
		Dark = 16,
		Steel = 17,
		Fairy = 18
	}

	protected string pokemonName;
	protected int level;
	protected int levelRequiredToEvolve;
	protected int health;
	//protected List<Skill> skills;
	//protected Sprite sprite;
	protected List<Types> types;
	protected int experience = 0;
	protected int experienceNeededToLevelUp = 10;

	//protected void AddSkill(Skill skill)
	//{
	//	if (skills.Count < 4)
	//	{
	//		skills.Add(skill);
	//	}
	//	else
	//	{
	//		// Ask the user to forget one skill and learn the new

	//		// IF YES
	//		// Dialog to choose the skill to forget
	//		//RemoveSkill(skillToForget);
	//		//AddSkill(skill);
	//	}
	//}

	//protected void RemoveSkill(Skill skill)
	//{
	//	skills.Remove(skill);
	//}

	protected bool IsPokemonAlive()
	{
		return health > 0;
	}

	protected bool CanPokemonEvolve()
	{
		return level >= levelRequiredToEvolve;
	}

	protected bool CanLevelUp()
	{
		return experience >= experienceNeededToLevelUp;
	}

	protected void LevelUp()
	{
		level += 1;
		experience = 0;
		experienceNeededToLevelUp *= 2;
	}

	protected void PopulatePokemon()
	{
		DatabaseHandler.Connection();
		var pokemon = DatabaseHandler.GetPokemonByName(pokemonName);
		DatabaseHandler.Close();
	}
}