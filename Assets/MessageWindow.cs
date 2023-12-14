using TMPro;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void Awake()
	{
		Close();
	}

	public void Alert(string message)
	{
		_text.text = message;
		gameObject.SetActive(true);
	}

	public void Close()
	{
		_text.text = "";
		gameObject.SetActive(false);
	}
}
