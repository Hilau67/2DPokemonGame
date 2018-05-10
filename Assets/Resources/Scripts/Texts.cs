using System.Collections.Generic;

public static class Texts
{
	public static Dictionary<int, string[]> texts = new Dictionary<int, string[]>();

	public static void PopulateTexts()
	{
		if (texts.Count == 0)
		{
			string[] texts = new string[] { "Hey, you should see the Professor. He is in the Pokemon Lab." };
			Texts.texts.Add(1, texts);
			texts = new string[] { "Choose one Pokémon" };
			Texts.texts.Add(2, texts);
			texts = new string[] { "Choose this one ?" };
			Texts.texts.Add(3, texts);
			texts = new string[] { "Rival's home", "test" };
			Texts.texts.Add(4, texts);
			texts = new string[] { "Your home" };
			Texts.texts.Add(5, texts);
			texts = new string[] { "Pokémon Lab" };
			Texts.texts.Add(6, texts);
		}
	}

	public static string[] GetTexts(int npcId)
	{
		return texts[npcId] ?? null;
	}
}