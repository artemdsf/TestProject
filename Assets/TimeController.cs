using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	[SerializeField] private string _timeServiceUrl = "https://www.timeanddate.com/worldclock/russia/moscow";

	private string _dateRequest = "date";

	[DllImport("__Internal")]
	private static extern void Alert(string message);

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
			
			Alert("Moscow time received: " + time);
		}
		else
		{
			Debug.LogError("Failed to get Moscow time: " + webRequest.error);
		}
	}
}
