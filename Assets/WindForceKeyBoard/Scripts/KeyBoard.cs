using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour {
	AndroidJavaObject activity;
	AndroidJavaObject context;
	 private string temptext;
	[SerializeField]Text text;
	[SerializeField]Text placeholder;
	public int id;
	private InputFieldHandler handler;
	public int get_id(){
		return id;

	}

	public void set_id(int c){
		id = c;
	}

	// Pass execution context over to the Java UI thread.
	void Start()
	{
		handler = Component.FindObjectOfType<InputFieldHandler> ();
	}
	/*
	void runOnUiThread()
	{
		Debug.Log("I'm running on the Java UI thread!");
		var plugin = new AndroidJavaClass ("openkeyboard.windforceworld.com.keyboardplugin.PluginClass");
		Debug.Log( plugin.CallStatic<string>("OpenKeyBoard",context));
	}
*/

	// Use this for initialization
	public void OpenKeyBoard () {
		handler.set_currentField (id);
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		context = activity.Call<AndroidJavaObject>("getApplicationContext");

		var plugin = new AndroidJavaClass ("openkeyboard.windforceworld.com.keyboardplugin.PluginClass");
		Debug.Log(	plugin.CallStatic<string>("OpenKeyBoard",context));
	}
	


	void Update() {
		if (id == handler.get_currentField()) {
			if (text.text.Length <= 0 && !placeholder.IsActive ()) {
				placeholder.gameObject.SetActive (true);
				text.gameObject.SetActive (false);

			} else if (text.text.Length > 0 && !text.IsActive ()) {
				placeholder.gameObject.SetActive (false);

				text.gameObject.SetActive (true);


			}
			foreach (char c in Input.inputString) {
				if (c == '\b') { // has backspace/delete been pressed?
					if (text.text.Length != 0) {
						text.text = text.text.Substring (0, text.text.Length - 1);
					}
				} else if ((c == '\n') || (c == '\r')) { // enter/return
					print ("User entered their name: " + text.text);
				} else {
					text.text += c;
				}
				Debug.Log (text);
			}
		}
	
	}

}
