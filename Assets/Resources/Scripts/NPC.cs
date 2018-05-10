using System.Collections;
using UnityEngine;

public class NPC : BaseTrigger
{
	public bool hasChoice;
	public int npcId;

	private DialogManager dialogManager;
	private string[] texts;

	protected override void Start()
	{
		dialogManager = FindObjectOfType<DialogManager>();
		Texts.PopulateTexts();
		EventMethods.InitializeDictionnaries();
	}

	private void ShowDialogBox()
	{
		Player.isSpeaking = true;
		ToggleDialog();
		texts = Texts.GetTexts(npcId);

		StartCoroutine(SetText());
	}

	IEnumerator SetText()
	{
		foreach (string text in texts)
		{
			dialogManager.SetText(text);
			yield return StartCoroutine(WaitForKeyDown());
		}

		Player.isSpeaking = false;
		ToggleDialog();
	}

	IEnumerator WaitForKeyDown()
	{
		while (!Input.GetKeyDown(KeyCode.Space))
		{
			yield return null;
		}
	}

	protected override bool OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag(playerTag) && Input.GetKeyDown(KeyCode.Return) && !Player.isSpeaking)
		{
			ShowDialogBox();
		}

		return false;
	}

	private void ToggleDialog()
	{
		dialogManager.ToggleDialogBox();

		if (hasChoice)
		{
			dialogManager.ToggleButtons();
		}
	}

	public void YesEvent()
	{
		var methodToExecute = EventMethods.GetYesMethod(npcId);

		if(methodToExecute != null)
		{
			methodToExecute();
		}

		Player.isSpeaking = false;
		ToggleDialog();
	}

	public void NoEvent()
	{
		var methodToExecute = EventMethods.GetNoMethod(npcId);

		if(methodToExecute != null)
		{
			methodToExecute();
		}

		Player.isSpeaking = false;
		ToggleDialog();
	}
}
