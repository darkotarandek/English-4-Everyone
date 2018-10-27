using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class orderSentenceScript : MonoBehaviour
{
    public static int countCorrectGuesses = 0;
    public int numberOfQuestions = 0;
    public int globalRandomNumber = 0;
    public int clickedWords = 0;
    public int currentWordsLength = 0;

    public string[] sentences;
    public Transform puzzleField;
    public GameObject wordButton;
    public Text answer;
    public List<int> listOfRandomNumbers = new List<int>();

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
        currentAmount -= (timeT) * Time.deltaTime * 0.1f;

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
            answer.text = "";
            clickedWords = 0;
            Play(randomNumber);
        }
    }

    public void Play(int randomNumber)
    {
        currentAmount = 1;
        deleteButtons();
        if (numberOfQuestions < 5)
        {
            var currentSentence = sentences[randomNumber];
            var currentWords = currentSentence.Split();
            currentWordsLength = currentWords.Length;
            List<GameObject> wordsToSort = new List<GameObject>();
            for (int i = 0; i < currentWords.Length; i++)
            {
                GameObject word = Instantiate(wordButton);
                word.GetComponentInChildren<Text>().text = currentWords[i].ToString();
                word.name = "" + currentWords[i];
                wordsToSort.Add(word);
            }
            var unsortedWords = ShuffleList<GameObject>(wordsToSort);
            foreach (var word in unsortedWords)
            {
                word.transform.SetParent(puzzleField);
            }
        }
        else
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("EndScene");
        }
    }

    public List<E> ShuffleList<E>(List<E> inputList)
    {
        List<E> randomList = new List<E>();

        System.Random r = new System.Random();
        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
            randomList.Add(inputList[randomIndex]); //add it to the new, random list
            inputList.RemoveAt(randomIndex); //remove to avoid duplicates
        }

        return randomList; //return the new random list
    }

    public void deleteButtons()
    {
        GameObject[] wordsToDelete = GameObject.FindGameObjectsWithTag("Player");
        foreach (var word in wordsToDelete)
        {
            if (word.GetComponentInChildren<Text>().text != "")
            {
                Destroy(word);
            }
        }
    }
}