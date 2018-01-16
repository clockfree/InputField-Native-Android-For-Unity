using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldHandler : MonoBehaviour {
	public KeyBoard[] Inputs;
	private int count;
	private int currentField;
	// Use this for initialization
	void Start () {
		count = 0;
		Inputs = Component.FindObjectsOfType<KeyBoard> ();
		Ini_Inputs ();
	}

	private void Ini_Inputs(){
		if (Inputs != null) {
			for (int i = 0; i < Inputs.Length; i++) {

				Inputs [i].set_id (count);
				count++;
			}

		}

	}

	public void set_currentField(int id){

		currentField = id;
	}

	public int get_currentField(){

		return currentField;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
