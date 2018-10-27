using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clockConnection : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] soundsToPlay;

    public GameObject enemy;
    public clockScript connection;
    public AudioSource sound;
    public Text score;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
        connection = enemy.GetComponent<clockScript>();
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
        StartCoroutine("clockCouroutine");
    }

    IEnumerator clockCouroutine()
    {
        if (gameObject.name == "ans1")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber >= 5 && connection.globalRandomNumber < 10)
            {
                clockScript.countCorrectGuesses++;
                sound.PlayOneShot(soundsToPlay[0]);
            }
            else
            {
                sound.PlayOneShot(soundsToPlay[1]);
            }
        }
        else if (gameObject.name == "ans2")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber < 5)
            {
                clockScript.countCorrectGuesses++;
                sound.PlayOneShot(soundsToPlay[0]);
            }
            else
            {
                sound.PlayOneShot(soundsToPlay[1]);
            }
        }
        else if (gameObject.name == "ans3")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber >= 10 && connection.globalRandomNumber < 15)
            {
                clockScript.countCorrectGuesses++;
                sound.PlayOneShot(soundsToPlay[0]);
            }
            else
            {
                sound.PlayOneShot(soundsToPlay[1]);
            }
        }
        else if (gameObject.name == "ans4")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber >= 15 && connection.globalRandomNumber < 20)
            {
                clockScript.countCorrectGuesses++;
                sound.PlayOneShot(soundsToPlay[0]);
            }
            else
            {
                sound.PlayOneShot(soundsToPlay[1]);
            }
        }
        int randomNumber = Random.Range(0, 20);
        while (connection.listOfRandomNumbers.Contains(randomNumber))
        {
            randomNumber = Random.Range(0, 20);
        }
        connection.listOfRandomNumbers.Add(randomNumber);
        connection.globalRandomNumber = randomNumber;
        connection.numberOfQuestions++;
        score.text = clockScript.countCorrectGuesses.ToString();
        connection.Play(randomNumber);
    }

    IEnumerator returnCouroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        SceneManager.LoadScene("GameSelect");
    }
}
