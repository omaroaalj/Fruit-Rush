using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHistoryUI : MonoBehaviour
{
    private static int moveDownValue = 0;

    private static GameObject container;
    private static GameObject buttonTemplate;

    public static void setContainer(GameObject currentContainer) {
        container = currentContainer;
    }

    public static void setMathLogButton(GameObject buttonToCopy) {
        buttonTemplate = buttonToCopy;
    }

    public static void createLogButtons() {
        for (int i = 0; i < 5; i++) {
            GameObject copyButton = Instantiate(buttonTemplate,container.transform);
            copyButton.transform.Translate(new Vector3(0,moveDownValue,0));
            moveDownValue -= 50;
        }
    }

}
