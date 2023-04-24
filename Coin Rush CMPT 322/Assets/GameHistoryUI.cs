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
        var logFile = File.ReadAllLines(filePath);
        foreach (string line in logFile) {
            Debug.Log("Line: " + line);
            mathLog += (line + "\n");
            //int lastUsernameChar = logFile.Length-18;
            //StreamReader streamText = new StreamReader(logFile);
            //Debug.Log("File reading complete!");
            //string line;
            //while ((line = streamText.ReadLine()) != null) {
            //    mathLog += (line + "\n");
            //}
            //mathLog += "-----\n";
        }
        Debug.Log("Math Log read complete.");
        logText.text = mathLog;
    }

    //public static void collectLogs() {
    //    string folderPath = @"MathLog";
    //    var logFiles = Directory.EnumerateFiles(folderPath);
    //}

    //private static int moveDownValue = 0;

    //private static GameObject container;
    //private static GameObject buttonTemplate;

    //public static void setContainer(GameObject currentContainer) {
    //    container = currentContainer;
    //}

    //public static void setMathLogButton(GameObject buttonToCopy) {
    //    buttonTemplate = buttonToCopy;
    //}

    //public static void createLogButtons() {
    //    for (int i = 0; i < 5; i++) {
    //        GameObject copyButton = Instantiate(buttonTemplate,container.transform);
    //        copyButton.transform.Translate(new Vector3(0,moveDownValue,0));
    //        moveDownValue -= 50;
    //    }
    //}

}
