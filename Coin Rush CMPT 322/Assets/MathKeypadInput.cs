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
    private static string mathLog = "";

    public void setUserAnswer(int buttonInput) {
        userAnswer = buttonInput;
    }

    public int getUserAnswer() {
        return userAnswer;
    }

    public static void setRandomNumbers() {
        do {
            randomX = Random.Range(1,9);
            randomY = Random.Range(1,10);
        } while (randomX + randomY > 9);
        correctAnswer = randomX + randomY;
        Debug.Log("Random numbers: " + randomX + " and " + randomY);
        mathLog += (randomX + " + " + randomY + " (correct answer: " + correctAnswer + ", ");
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
                randomNumbersText.text = randomX + " + " + randomY + " =";
            } else {
                Time.timeScale = 1f;
                if (userAnswer == correctAnswer) {
                    Debug.Log("Correct Answer!");
                    mathLog += ("user answer: " + userAnswer + ") [Correct!]\n");
                    collectables++;
                    collectablesText.text = "Items: " + collectables;
                }
                else {
                    tries--;
                    triesText.text = "Tries: " + tries;
                    Debug.Log("Incorrect Answer.");
                    mathLog += ("user answer: " + userAnswer + ") [Incorrect]\n");
                    if (tries <= 0) {
                        Time.timeScale = 1f;
                        Debug.Log("Loading menu and log...");
                        string logPath = "MathLog/Game" + System.DateTime.Now.ToString("yyyMMddHHmmss") + ".txt";
                        File.WriteAllText(logPath, mathLog);
                        mathLog = "";
                        SceneManager.LoadSceneAsync(menuUI);
                    }
                }
                mathUI.SetActive(false);
                userAnswer = -1;
                ItemCollector.setCollisionPresent(false);
            }
        }
    }
}