using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameHistoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI logText;

    public void setLogText() {
        string mathLog = "";
        string filePath = @"MathLog.txt";
        try {
            var logFile = File.ReadAllLines(filePath);
            foreach (string line in logFile) {
                Debug.Log("Line: " + line);
                mathLog += (line + "\n");
            }
            Debug.Log("Math Log read complete.");
            logText.text = mathLog;
        } catch (FileNotFoundException e) {
            Debug.Log(e.Message);
        }
        //foreach (string line in logFile) {
        //    Debug.Log("Line: " + line);
        //    mathLog += (line + "\n");
        //}
        //Debug.Log("Math Log read complete.");
        //logText.text = mathLog;
    }
}
