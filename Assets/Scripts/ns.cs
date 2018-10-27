using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ns : MonoBehaviour {

	public static float dwellTime = 3.0f;

	// Use this for initialization
	void Start () {
        GameObject image = GameObject.FindGameObjectWithTag("endSceneImageTag");
        if (image)
        {
            string sceneName = PlayerPrefs.GetString("lastLoadedScene");
            if (sceneName == "PastTenseVerbs")
            {
                image.transform.Find("ScoreNumber").GetComponent<Text>().text = pastTenseScript.countCorrectGuesses.ToString();
            } else if (sceneName == "Prepositions")
            {
                image.transform.Find("ScoreNumber").GetComponent<Text>().text = prepositionsScript.countCorrectGuesses.ToString();
            } else if (sceneName == "GuessTime")
            {
                image.transform.Find("ScoreNumber").GetComponent<Text>().text = clockScript.countCorrectGuesses.ToString();
            } else if (sceneName == "FruitsVegetables")
            {
                image.transform.Find("ScoreNumber").GetComponent<Text>().text = fruitScript.countCorrectGuesses.ToString();
            } else if(sceneName == "OrderSentence")
            {
                image.transform.Find("ScoreNumber").GetComponent<Text>().text = orderSentenceScript.countCorrectGuesses.ToString();
            } else if(sceneName == "Hangman")
            {
                image.transform.Find("ScoreNumber").GetComponent<Text>().text = hangmanScript.countCorrectGuesses.ToString();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

	public void nScena(){
		if (gameObject.name == "Start" || gameObject.name == "PlayAgain") {
			StartCoroutine ("gameSelect");
		}

		if (gameObject.name == "Exit") {
			StartCoroutine ("izlaz");
		}

        if (gameObject.name == "Settings")
        {
            StartCoroutine("gameConfig");
        }

        if (gameObject.name == "1Second") {
			StartCoroutine ("oneSecond");
		}

		if (gameObject.name == "2Seconds") {
			StartCoroutine ("twoSeconds");
		}

		if (gameObject.name == "3Seconds") {
			StartCoroutine ("threeSeconds");
		}

		if (gameObject.name == "4Seconds") {
			StartCoroutine ("fourSeconds");
		}

		if (gameObject.name == "5Seconds") {
			StartCoroutine ("fiveSeconds");
		}

		if (gameObject.name == "6Seconds") {
			StartCoroutine ("sixSeconds");
		}
		
		if (gameObject.name == "7Seconds") {
			StartCoroutine ("sevenSeconds");
		}
		
		if (gameObject.name == "8Seconds") {
			StartCoroutine ("eightSeconds");
		}

		if (gameObject.name == "9Seconds") {
			StartCoroutine ("nineSeconds");
		}

        if(gameObject.name == "ReturnGameConfig" || gameObject.name == "ReturnGameSelect")
        {
            StartCoroutine("returnBackToMainMenu");
        }

    }

	IEnumerator gameConfig()
	{
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("GameConfig");
	}

	IEnumerator izlaz()
	{
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		Application.Quit ();
	}

    IEnumerator returnBackToMainMenu()
    {
        yield return new WaitForSeconds(dwellTime);
        Debug.Log(dwellTime);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator gameSelect()
    {
        yield return new WaitForSeconds(dwellTime);
        Debug.Log(dwellTime);
        SceneManager.LoadScene("GameSelect");
    }

    IEnumerator oneSecond()
	{
		dwellTime = 1.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator twoSeconds()
	{
		dwellTime = 2.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator threeSeconds()
	{
		dwellTime = 3.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator fourSeconds()
	{
		dwellTime = 4.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator fiveSeconds()
	{
		dwellTime = 5.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator sixSeconds()
	{
		dwellTime = 6.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator sevenSeconds()
	{
		dwellTime = 7.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator eightSeconds()
	{
		dwellTime = 8.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator nineSeconds()
	{
		dwellTime = 9.0f;
		yield return new WaitForSeconds(dwellTime);
		Debug.Log(dwellTime);
		SceneManager.LoadScene ("MainMenu");
	}
}
