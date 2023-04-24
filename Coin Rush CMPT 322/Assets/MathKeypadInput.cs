using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MathKeypadInput : MonoBehaviour
{
    private int userAnswer = -1;
    [SerializeField] private TextMeshProUGUI randomNumbersText;
    [SerializeField] private GameObject mathUI;
    [SerializeField] private Text collectablesText;
    [SerializeField] private Text triesText;
    private int tries = 3;
    private int collectables = 0;
    private static int randomX;
    private static int randomY;
    private static int correctAnswer;
    private static string menuUI = "UIMenu";
    private static int mathProblemType;
    private static string mathSign;

    public void setUserAnswer(int buttonInput) {
        userAnswer = buttonInput;
    }

    public int getUserAnswer() {
        return userAnswer;
    }

    public static void setRandomNumbers() {
        mathProblemType = Random.Range(1,3);
        if (mathProblemType == 1) { // addition
            do {
                randomX = Random.Range(1,9);
                randomY = Random.Range(1,10);
            } while (randomX + randomY > 9);
            correctAnswer = randomX + randomY;
            mathSign = " + ";
            Debug.Log("Addition Random numbers: " + randomX + " and " + randomY);
            CreateMathLog.writeRandomNumbers(randomX, mathSign, randomY, correctAnswer);
        } else if (mathProblemType == 2) { // subtraction
            do {
                randomX = Random.Range(1,10);
                randomY = Random.Range(1,9);
            } while (randomX <= randomY || randomX + randomY > 9);
            correctAnswer = randomX - randomY;
            mathSign = " - ";
            Debug.Log("Subtraction Random numbers: " + randomX + " and " + randomY);
            CreateMathLog.writeRandomNumbers(randomX, mathSign, randomY, correctAnswer);
        } else {
            Debug.Log("Error: mathProblemType not 1 or 2!");
        }
    }

    void Start() {
        Debug.Log("Starting math UI...");
        mathUI.SetActive(false);
    }

    void Update() {
        if (ItemCollector.getCollisionPresent()) {
            if (userAnswer <= -1) {
                mathUI.SetActive(true);
                Time.timeScale = 0f;
                randomNumbersText.text = randomX + mathSign + randomY + " =";
            } else {
                Time.timeScale = 1f;
                if (userAnswer == correctAnswer) {
                    CreateMathLog.logUserAnswer(userAnswer);
                    collectables++;
                    collectablesText.text = "Items: " + collectables;
                }
                else {
                    tries--;
                    triesText.text = "Tries: " + tries;
                    CreateMathLog.logUserAnswer(userAnswer);
                    if (tries <= 0) {
                        Time.timeScale = 1f;
                        Debug.Log("Loading menu and log...");
                        string currentUsername = PlayerPrefs.GetString("user_name");
                        CreateMathLog.writeToFile(currentUsername);
                        SceneManager.LoadScene(menuUI);
                    }
                }
                mathUI.SetActive(false);
                userAnswer = -1;
                ItemCollector.setCollisionPresent(false);
            }
        }
    }
}