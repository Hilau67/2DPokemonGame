using System.Collections;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	public delegate void Method();
	public bool hasChoice;
	public Sprite sprite;
	public int textId;

	private DialogManager dialogManager;
	private string[] texts;
	private const string playerTag = "Player";
	private Inventory inventory;

	protected void Start()
	{
		inventory = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Inventory>();
		dialogManager = FindObjectOfType<DialogManager>();
		Texts.PopulateTexts();
	}

	protected virtual bool OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag(playerTag) && Input.GetKeyDown(KeyCode.Return) && !Player.isSpeaking)
		{
			ShowDialogBox();
			return true;
		}

		return false;
	}

	protected void ShowDialogBox()
	{
		Player.isSpeaking = true;
		ToggleDialog();
		texts = Texts.GetTexts(textId);

		StartCoroutine(SetText());
	}

	protected IEnumerator SetText()
	{
		foreach (string text in texts)
		{
			dialogManager.SetText(text);
			yield return StartCoroutine(WaitForKeyDown());
		}

		Player.isSpeaking = false;
		ToggleDialog();
	}

	protected IEnumerator WaitForKeyDown()
	{
		while (!Input.GetKeyDown(KeyCode.Space) && Player.isSpeaking)
		{
			yield return null;
		}
	}

	protected void ToggleDialog()
	{
		dialogManager.ToggleDialogBox();

		if (hasChoice)
		{
			dialogManager.ToggleButtons();
		}

		if (sprite != null)
		{
			dialogManager.SetImage(sprite);
			dialogManager.ToggleImage();
		}
	}

	protected void AddItem(InventoryItem item)
	{
		Item itemToAdd = new Item(item);
		inventory.items.Add(itemToAdd);
	}

	protected void RemoveItem(InventoryItem item)
	{
		Item itemToRemove = new Item(item);
		inventory.items.Remove(itemToRemove);
	}

	protected void AddPokemon(Pokemon pokemon)
	{
		if (inventory.pokemons.Count <= 5)
		{
			inventory.pokemons.Add(pokemon);
		}
	}

	protected void RemovePokemon(Pokemon pokemon)
	{
		if (inventory.pokemons.Count > 1)
		{
			inventory.pokemons.Remove(pokemon);
		}
	}

	protected virtual void Event()
	{
		Player.isSpeaking = false;
		ToggleDialog();
	}

	protected void SetButtonsAction(Method yesEvent, Method noEvent)
	{
		dialogManager.SetButtonsAction(yesEvent, noEvent);
	}

	protected bool HasUserTookStarter()
	{
		return inventory.pokemons.Count > 0;
	}
}
