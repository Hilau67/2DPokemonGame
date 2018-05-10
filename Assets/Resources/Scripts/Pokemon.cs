using System;
using System.Collections.Generic;

[Serializable]
public class Pokemon : BasePokemon
{
	public string name;
	public List<Types> type;

	// TODO : Gérer le sprite du Pokémon
	public Pokemon(string pokemonName, int level, int levelRequiredToEvolve, /*List<Skill> skills,*/ List<Types> types)
	{
		this.pokemonName = name = pokemonName;
		this.level = level;
		this.levelRequiredToEvolve = levelRequiredToEvolve;
		health = this.level * 10;
		//this.skills = skills;
		this.types = type = types;
		experienceNeededToLevelUp = 5 * (int)Math.Pow(2, level);
	}

	public Pokemon(string pokemonName, int level)
	{
		this.pokemonName = pokemonName;
		this.level = level;
		health = this.level * 10;
		PopulatePokemon();
	}
}