using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	[SerializeField] private MessageWindow _messageWindow;
	[SerializeField] private string _timeServiceUrl = "https://www.timeanddate.com/worldclock/russia/moscow";

	private string _dateRequest = "date";

	private void Start()
	{
		Button button = GetComponent<Button>();

		if (button != null)
		{
			button.onClick.AddListener(() => StartCoroutine(GetMoscowTime()));
		}
		else
		{
			Debug.LogError("Button component not found.");
		}
	}

	private IEnumerator GetMoscowTime()
	{
		UnityWebRequest webRequest = UnityWebRequest.Get(_timeServiceUrl);

		yield return webRequest.SendWebRequest();

		if (webRequest.result == UnityWebRequest.Result.Success)
		{
			string time = webRequest.GetResponseHeader(_dateRequest);
			_messageWindow.Alert("Moscow time received: " + time);
		}
		else
		{
			Debug.LogError("Failed to get Moscow time: " + webRequest.error);
		}
	}
}
