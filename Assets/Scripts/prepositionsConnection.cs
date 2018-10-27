using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class prepositionsConnection : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundsToPlay;

    public GameObject enemy;
    public prepositionsScript connection;
    public AudioSource sound;
    public Text score;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
        connection = enemy.GetComponent<prepositionsScript>();
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
        StartCoroutine("prepositionsCouroutine");
    }

    IEnumerator prepositionsCouroutine()
    {
        if (gameObject.name == "ans1")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber >= 4 && connection.globalRandomNumber < 8)
            {
                prepositionsScript.countCorrectGuesses++;
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
            if (connection.globalRandomNumber < 4 || (connection.globalRandomNumber >= 12 && connection.globalRandomNumber < 16))
            {
                prepositionsScript.countCorrectGuesses++;
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
            if ((connection.globalRandomNumber >= 8 && connection.globalRandomNumber < 12) ||
                (connection.globalRandomNumber >= 16 && connection.globalRandomNumber < 20))
            {
                prepositionsScript.countCorrectGuesses++;
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
        score.text = prepositionsScript.countCorrectGuesses.ToString();
        connection.Play(randomNumber);
    }

    IEnumerator returnCouroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        SceneManager.LoadScene("GameSelect");
    }
}
