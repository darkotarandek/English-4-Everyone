using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fruitConnection : MonoBehaviour
{
    public GameObject enemy;
    public fruitScript connection;
    public AudioSource sound;
    public Text score;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
        connection = enemy.GetComponent<fruitScript>();
    }

    void Update()
    {
    }
    public void enterReturn()
    {
        StartCoroutine("returnCouroutine");
    }
    public void enter()
    {
        StartCoroutine("fruitCoroutine");
    }

    IEnumerator fruitCoroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        connection.answer.text += gameObject.name;
        connection.clickedLetters++;
        if (connection.clickedLetters == connection.fruitImages[connection.globalRandomNumber].name.Length)
        {
            yield return new WaitForSeconds(1.0f);
            if (connection.answer.text == connection.fruitImages[connection.globalRandomNumber].name.ToUpper())
            {
                fruitScript.countCorrectGuesses++;
                score.text = fruitScript.countCorrectGuesses.ToString();
            }
            int randomNumber = Random.Range(0, 20);
            while (connection.listOfRandomNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 20);
            }
            connection.listOfRandomNumbers.Add(randomNumber);
            connection.globalRandomNumber = randomNumber;
            connection.numberOfQuestions++;
            connection.answer.text = "";
            connection.clickedLetters = 0;
            connection.Play(randomNumber);
        }
    }

    IEnumerator returnCouroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        SceneManager.LoadScene("GameSelect");
    }
}
