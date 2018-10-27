using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hangmanScript : MonoBehaviour
{
    public static int countCorrectGuesses = 0;
    public int numberOfQuestions = 0;
    public int globalRandomNumber = 0;
    public int clickedWords = 0;
    public int currentWordsLength = 0;
    public int correctLetters = 0;
    public string answer = "";
    public List<int> listOfRandomNumbers = new List<int>();

    public string[] alphabet;
    public string[] animals;
    public Transform puzzleField;
    public Transform letterField;
    public GameObject alphabetButton;
    public GameObject emptyLetterButton;
    public Sprite emptySpaceImage;
    public Image hangmanImage;
    public Sprite[] hangmans;

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

        int randomNumber = Random.Range(0, 30);
        globalRandomNumber = randomNumber;
        hangmanImage.GetComponent<Image>().sprite = hangmans[0];
        listOfRandomNumbers.Add(randomNumber);
        Play(randomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        //we reduce the time when quesition is asked with respect to game time
        currentAmount -= (timeT) * Time.deltaTime * 0.001f;

        fillBar.GetComponent<Image>().fillAmount = currentAmount;

        if (currentAmount <= 0)
        {
            //if the fill become zero , means the time is over and we go to next question
            currentAmount = 1;
            int randomNumber = Random.Range(0, 30);
            while (listOfRandomNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 30);
            }
            listOfRandomNumbers.Add(randomNumber);
            globalRandomNumber = randomNumber;
            numberOfQuestions++;
            answer = "";
            correctLetters = 0;
            clickedWords = 0;
            hangmanImage.GetComponent<Image>().sprite = hangmans[0];
            Play(randomNumber);
        }
    }

    public void Play(int randomNumber)
    {
        currentAmount = 1;
        deleteButtons();
        if (numberOfQuestions < 5)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                GameObject word = Instantiate(alphabetButton);
                word.GetComponentInChildren<Text>().text = alphabet[i].ToString();
                word.name = "" + alphabet[i];
                word.transform.SetParent(puzzleField);
            }

            answer = animals[randomNumber];
            currentWordsLength = answer.Length;
            for (int j = 0; j < answer.Length; j++)
            {
                GameObject emptyLetter = Instantiate(emptyLetterButton);
                emptyLetter.GetComponent<Image>().sprite = emptySpaceImage;
                emptyLetter.name = "" + answer[j];
                emptyLetter.transform.SetParent(letterField);
            }
        }
        else
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("EndScene");
        }
    }

    public void deleteButtons()
    {
        GameObject[] lettersToDelete = GameObject.FindGameObjectsWithTag("Player");
        foreach (var letter in lettersToDelete)
        {
            if (letter.GetComponentInChildren<Text>().text != "")
            {
                Destroy(letter);
            }
        }

        GameObject[] puzzlesToDelete = GameObject.FindGameObjectsWithTag("PuzzleButton");
        foreach (var puzzle in puzzlesToDelete)
        {
            if (puzzle.name != "emptyLetter")
            {
                Destroy(puzzle);
            }
        }
    }
}