using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class orderSentenceConnection : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundsToPlay;

    public GameObject enemy;
    public orderSentenceScript connection;
    public AudioSource sound;
    public Text score;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
        connection = enemy.GetComponent<orderSentenceScript>();
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
        StartCoroutine("wordCoroutine");
    }

    IEnumerator wordCoroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        if(connection.clickedWords == connection.currentWordsLength - 1)
        {
            connection.answer.text += gameObject.name;
        } else
        {
            connection.answer.text += gameObject.name + " ";
        }
        connection.clickedWords++;
        if (connection.clickedWords == connection.currentWordsLength)
        {
            if (connection.answer.text == connection.sentences[connection.globalRandomNumber])
            {
                orderSentenceScript.countCorrectGuesses++;
                score.text = orderSentenceScript.countCorrectGuesses.ToString();
                sound.PlayOneShot(soundsToPlay[0]);
                yield return new WaitForSeconds(1.0f);
            }
            else
            {
                sound.PlayOneShot(soundsToPlay[1]);
                yield return new WaitForSeconds(1.0f);
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
            connection.clickedWords = 0;
            connection.Play(randomNumber);
        }
    }

    IEnumerator returnCouroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        SceneManager.LoadScene("GameSelect");
    }
}
