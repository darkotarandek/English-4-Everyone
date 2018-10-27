using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//timer += Time.deltaTime;
		//Debug.Log (timer);
	}

	public void nScena(){
		
		if (gameObject.name == "PastTenseVerbs") {
			StartCoroutine ("PastTenseVerbs");
		}

		if (gameObject.name == "GuessTheTime") {
			StartCoroutine ("GuessTheTime");
		}
	
		if (gameObject.name == "OrderTheSentence") {
			StartCoroutine ("OrderTheSentence");
		}

		if (gameObject.name == "FruitsVegetables") {
			StartCoroutine ("FruitsVegetables");
		}

		if (gameObject.name == "Hangman") {
			StartCoroutine ("Hangman");
		}

		if (gameObject.name == "Prepositions") {
			StartCoroutine ("Prepositions");
		}

		if (gameObject.name == "Exit") {
			StartCoroutine ("izlaz");
		}
	}

	IEnumerator izlaz()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		Application.Quit ();
	}

	IEnumerator PastTenseVerbs()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		SceneManager.LoadScene ("PastTenseVerbs");
	}

	IEnumerator GuessTheTime()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		SceneManager.LoadScene ("GuessTime");
	}

	IEnumerator OrderTheSentence()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		SceneManager.LoadScene ("OrderSentence");
	}

	IEnumerator FruitsVegetables()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		SceneManager.LoadScene ("FruitsVegetables");
	}

	IEnumerator Hangman()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		SceneManager.LoadScene ("Hangman");
	}

	IEnumerator Prepositions()
	{
		yield return new WaitForSeconds(ns.dwellTime);
		Debug.Log(ns.dwellTime);
		SceneManager.LoadScene ("Prepositions");
	}
}
