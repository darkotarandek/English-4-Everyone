using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class pastTenseScript : MonoBehaviour
{ 
    public int numberOfQuestions = 0;
    public static int countCorrectGuesses = 0;
    public int globalRandomNumber = 0;
    public List<int> listOfRandomNumbers = new List<int>();

    public string[] verbs;
    public string[] answers;
    public Text ans1Text;
    public Text ans2Text;
    public Text verb;

    //ref to the images which will display the time in fill type
    public Transform fillBar;
    //ref to the fill amount or bar 
    [HideInInspector] public float currentAmount;
    //ref to the time
    private float timeT;

    // Use this for initialization
    void Start()
    {
        timeT = 1;
        currentAmount = 1;

        int randomNumber = Random.Range(0, 20);
        globalRandomNumber = randomNumber;
        listOfRandomNumbers.Add(randomNumber);
        Play(randomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        //we reduce the time when quesition is asked with respect to game time
        currentAmount -= (timeT) * Time.deltaTime * 0.05f;

        fillBar.GetComponent<Image>().fillAmount = currentAmount;

        if (currentAmount <= 0)
        {
            //if the fill become zero , means the time is over and we go to next question
            currentAmount = 1;
            int randomNumber = Random.Range(0, 20);
            while (listOfRandomNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 20);
            }
            listOfRandomNumbers.Add(randomNumber);
            globalRandomNumber = randomNumber;
            numberOfQuestions++;
            Play(randomNumber);
        }
    }

    public void Play(int randomNumber)
    {
        currentAmount = 1;
        if (numberOfQuestions < 6)
        {
            verb.text = verbs[randomNumber];
            if (randomNumber < 10)
            {
                ans1Text.text = answers[randomNumber * 2];
                ans2Text.text = answers[randomNumber * 2 + 1];
            }
            else if (randomNumber >= 10 && randomNumber < 20)
            {
                ans1Text.text = answers[randomNumber * 2];
                ans2Text.text = answers[randomNumber * 2 + 1];
            }
        }
        else
        {
            SceneManager.LoadScene("EndScene");
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        }
    }
}
