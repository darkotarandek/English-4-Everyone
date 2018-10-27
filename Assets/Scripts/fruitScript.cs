using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fruitScript : MonoBehaviour {

    public static int countCorrectGuesses = 0;
    public int numberOfQuestions = 0;
    public int globalRandomNumber = 0;
    public int clickedLetters = 0;
    public List<int> listOfRandomNumbers = new List<int>();

    public Transform puzzleField;
    public GameObject letterButton;

    //ref to the images which will display the time in fill type
    public Transform fillBar;
    //ref to the fill amount or bar 
    [HideInInspector] public float currentAmount;
    //ref to the time
    private float timeT;

    public Sprite[] fruitImages;
    public Image fruitImage;
    public AudioClip[] fruitSounds;
    public AudioSource fruitSound;
    public Text answer;

    // Use this for initialization
    void Start()
    {
        timeT = 1;
        currentAmount = 1;

        int randomNumber = Random.Range(0, 20);
        fruitImage.GetComponent<Image>().sprite = fruitImages[randomNumber];
        fruitSound = GetComponent<AudioSource>();
        fruitSound.PlayOneShot(fruitSounds[randomNumber]);
        globalRandomNumber = randomNumber;
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
            int randomNumber = Random.Range(0, 20);
            while (listOfRandomNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 20);
            }
            listOfRandomNumbers.Add(randomNumber);
            globalRandomNumber = randomNumber;
            numberOfQuestions++;
            answer.text = "";
            clickedLetters = 0;
            Play(randomNumber);
        }
    }

    public void Play(int randomNumber)
    {
        currentAmount = 1;
        deleteButtons();
        if (numberOfQuestions < 3)
        {
            fruitImage.GetComponent<Image>().sprite = fruitImages[randomNumber];
            var currentImageName = fruitImages[randomNumber].name;
            fruitSound = GetComponent<AudioSource>();
            fruitSound.PlayOneShot(fruitSounds[randomNumber]);
            List<GameObject> lettersToSort = new List<GameObject>();
            for (int i = 0; i < currentImageName.Length; i++)
            {
                GameObject letter = Instantiate(letterButton);
                letter.GetComponentInChildren<Text>().text = currentImageName[i].ToString().ToUpper();
                letter.name = "" + currentImageName[i].ToString().ToUpper();
                lettersToSort.Add(letter);
            }
            var unsortedLetters = ShuffleList<GameObject>(lettersToSort);
            foreach(var letter in unsortedLetters)
            {
                letter.transform.SetParent(puzzleField);
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
        GameObject[] lettersToDelete = GameObject.FindGameObjectsWithTag("Player");
        foreach (var letter in lettersToDelete)
        {
            if (letter.GetComponentInChildren<Text>().text != "")
            {
                Destroy(letter);
            }
        }
    }
}