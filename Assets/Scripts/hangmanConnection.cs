using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class hangmanConnection : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundsToPlay;

    public GameObject enemy;
    public hangmanScript connection;
    public AudioSource sound;
    public Text score;
    public Sprite redImage;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
        connection = enemy.GetComponent<hangmanScript>();
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
        StartCoroutine("hangmanCoroutine");
    }

    IEnumerator hangmanCoroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        var currentCorrectLetters = connection.correctLetters;
        Debug.Log("currentCorrectLetters: " + currentCorrectLetters);
        Debug.Log("connection.correctLetters: " + connection.correctLetters);
        GameObject[] letters = GameObject.FindGameObjectsWithTag("PuzzleButton");
        foreach (var letter in letters)
        {
            if(letter.name != "emptyLetter")
            {
                if (gameObject.name == letter.name)
                {
                    connection.correctLetters++;
                    letter.GetComponentInChildren<Text>().text = gameObject.name;
                }

                gameObject.GetComponent<Image>().sprite = redImage;
                gameObject.GetComponent<EventTrigger>().enabled = false;
            }
        }

        Debug.Log("currentCorrectLetters: " + currentCorrectLetters);

        if (currentCorrectLetters == connection.correctLetters)
        {
            connection.clickedWords++;
            connection.hangmanImage.GetComponent<Image>().sprite = connection.hangmans[connection.clickedWords];
        }

        Debug.Log("clickedWords: " + connection.clickedWords);

        if (connection.correctLetters == connection.currentWordsLength)
        {
            sound.PlayOneShot(soundsToPlay[0]);
            yield return new WaitForSeconds(1.0f);
            hangmanScript.countCorrectGuesses++;
            score.text = hangmanScript.countCorrectGuesses.ToString();
            
            int randomNumber = Random.Range(0, 30);
            while (connection.listOfRandomNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 30);
            }
            connection.listOfRandomNumbers.Add(randomNumber);
            connection.globalRandomNumber = randomNumber;
            connection.numberOfQuestions++;
            connection.answer = "";
            connection.correctLetters = 0;
            connection.clickedWords = 0;

            connection.hangmanImage.GetComponent<Image>().sprite = connection.hangmans[0];
            connection.Play(randomNumber);
        }

        if(connection.clickedWords == 6)
        {
            sound.PlayOneShot(soundsToPlay[1]);
            yield return new WaitForSeconds(1.0f);
            score.text = hangmanScript.countCorrectGuesses.ToString();

            int randomNumber = Random.Range(0, 30);
            while (connection.listOfRandomNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 20);
            }
            connection.listOfRandomNumbers.Add(randomNumber);
            connection.globalRandomNumber = randomNumber;
            connection.numberOfQuestions++;
            connection.answer = "";
            connection.correctLetters = 0;
            connection.clickedWords = 0;

            connection.hangmanImage.GetComponent<Image>().sprite = connection.hangmans[0];
            connection.Play(randomNumber);
        }
    }

    IEnumerator returnCouroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        SceneManager.LoadScene("GameSelect");
    }

}
