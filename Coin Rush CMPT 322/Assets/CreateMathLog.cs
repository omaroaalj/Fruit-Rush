using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateMathLog : MonoBehaviour
{

    private static string mathLog = "";
    private static int correctAnswer;
    private static int userAnswer;

    public static void writeRandomNumbers(int x, string sign, int y, int calculatedAnswer) {
        correctAnswer = calculatedAnswer;
        mathLog += (x + " " + sign + " " + y + " (correct answer: " + correctAnswer + ", ");
        Debug.Log("Random numbers in mathLog variable.");
    }

    public static void logUserAnswer(int answer) {
        userAnswer = answer;
        mathLog += ("user answer: " + userAnswer + ") [");
        if (correctAnswer == userAnswer) {
            Debug.Log("Correct Answer!");
            mathLog += ("Correct!]\n");
        } else {
            Debug.Log("Incorrect Answer.");
            mathLog += ("Incorrect]\n");
        }
    }

    public static void logPoints(int points) {
        mathLog += ("Points: " + points + "\n");
    }

    public static void writeToFile(string username) {
        string logPath = "MathLog/" + username + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
        File.WriteAllText(logPath, mathLog);
        Debug.Log("Log file complete!");
        mathLog = "";
    }
}
