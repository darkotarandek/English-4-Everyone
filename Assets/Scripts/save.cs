﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class save : MonoBehaviour {


	public InputField waitTime;
	public Text defTime;
	public Button saveBtn;

	public string vrijeme = "3";
	public static string vrime = "3";
	EventTrigger trigger;

	public Button povratak;
	public Button izadi;


	// Use this for initialization
	void Start () {
		if (vrime == "") {
			vrime = "3";
		}
		/*Button btn = saveBtn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		defTime.text = "Set to: " + vrime + " seconds.";

		Button btnPovratak = povratak.GetComponent<Button>();
		trigger = btnPovratak.gameObject.AddComponent<EventTrigger>();
		var pointerEnterPovratak = new EventTrigger.Entry();
		pointerEnterPovratak.eventID = EventTriggerType.PointerEnter;
		string povratakBtn = btnPovratak.gameObject.name;
		pointerEnterPovratak.callback.AddListener((e) => povratakFunkcija());
		trigger.triggers.Add(pointerEnterPovratak);


		Button btnIzadi = izadi.GetComponent<Button>();
		trigger = btnIzadi.gameObject.AddComponent<EventTrigger>();
		var pointerEnterIzadi = new EventTrigger.Entry();
		pointerEnterIzadi.eventID = EventTriggerType.PointerEnter;
		//string povratakBtn = btnPovratak.gameObject.name;
		pointerEnterIzadi.callback.AddListener((e) => izadiFunkcija());
		trigger.triggers.Add(pointerEnterIzadi);*/


	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void TaskOnClick()
	{
		vrime = waitTime.GetComponent<InputField>().text;
		if (vrime == "") {
			vrime = "3";
		}
		defTime.text = "Set to: " + vrime + " seconds.";
		Debug.Log("Vrijeme: " + vrime);
	} 



	public void povratakFunkcija()
	{
		Invoke("vratiSeNakon3Sekunde", 3.0f);

	}


	private void vratiSeNakon3Sekunde() {
		SceneManager.LoadScene ("MainMenu");
	}


	public void izadiFunkcija()
	{
		Invoke("izadiNakon3Sekunde", 3.0f);
	
	}

	private void izadiNakon3Sekunde() {
		Debug.Log ("Izasao sam");
		Application.Quit ();
	}




}
