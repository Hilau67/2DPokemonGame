using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DialogManager : MonoBehaviour
{
	public delegate void Method();

	private GameObject dialogBox;
	private Button[] buttons;
	private Text text;
	private Image image;
	private const string dialogManagerTag = "DialogManager";
	private const string dialogBoxTag = "DialogBox";
	private const string buttonTag = "Buttons";

	private void Start ()
	{
		dialogBox = GameObject.FindGameObjectWithTag(dialogBoxTag);
		text = dialogBox.GetComponentInChildren<Text>();		
		dialogBox.SetActive(false);

		var children = GameObject.FindGameObjectWithTag(dialogManagerTag).GetComponentsInChildren<Image>();
		image = children.First(o => o.name == "Image");

		HideElements();
	}

	private void HideElements()
	{
		GameObject[] buttonsGameObject = GameObject.FindGameObjectsWithTag(buttonTag);
		buttons = new Button[2];
		
		// For is faster than foreach
		for(int i = 0; i < buttonsGameObject.Length; i++)
		{
			buttons[i] = buttonsGameObject[i].GetComponent<Button>();
			buttons[i].gameObject.SetActive(false);
		}

		image.gameObject.SetActive(false);
	}

	public void ToggleDialogBox()
	{
		Time.timeScale = !Player.isSpeaking ? 1f : 0f;
		dialogBox.SetActive(Player.isSpeaking);
	}

	public void ToggleButtons()
	{
		// For is faster than foreach
		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].gameObject.SetActive(Player.isSpeaking);
			buttons[i].onClick.RemoveAllListeners();
		}
	}

	public void SetButtonsAction(InventoryController.Method yesEvent, InventoryController.Method noEvent)
	{
		buttons[0].onClick.AddListener(() => { noEvent(); });
		buttons[1].onClick.AddListener(() => { yesEvent(); });
	}

	public void ToggleImage()
	{
		image.gameObject.SetActive(Player.isSpeaking);
	}

	public void SetText(string text)
	{
		this.text.text = text;
	}

	public void SetImage(Sprite sprite)
	{
		image.sprite = sprite;
	}
}
