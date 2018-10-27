using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pastTenseConnection : MonoBehaviour{

    [SerializeField]
    private AudioClip[] soundsToPlay;

    public GameObject enemy;
    public pastTenseScript connection;
    public AudioSource sound;
    public Text score;
    public Image returnBack;

    public void Start(){
        sound = GetComponent<AudioSource>();
        connection = enemy.GetComponent<pastTenseScript>();
    }

	void Update () {
	}
    public void enterReturn()
    {
        StartCoroutine("returnCouroutine");
    }

    public void enter(){
        StartCoroutine("pastTenseAnswersCouroutine");
	}

    IEnumerator pastTenseAnswersCouroutine()
    {
        if (gameObject.name == "ans1")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber < 10)
            {
                pastTenseScript.countCorrectGuesses++;
                sound.PlayOneShot(soundsToPlay[0]);
            } else
            {
                sound.PlayOneShot(soundsToPlay[1]);
            }
        }
        else if (gameObject.name == "ans2")
        {
            yield return new WaitForSeconds(ns.dwellTime);
            if (connection.globalRandomNumber >= 10 && connection.globalRandomNumber < 20)
            {
                pastTenseScript.countCorrectGuesses++;
                sound.PlayOneShot(soundsToPlay[0]);
            } else
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
        score.text = pastTenseScript.countCorrectGuesses.ToString();
        connection.Play(randomNumber);
    }

    IEnumerator returnCouroutine()
    {
        yield return new WaitForSeconds(ns.dwellTime);
        SceneManager.LoadScene("GameSelect");
    }
}
