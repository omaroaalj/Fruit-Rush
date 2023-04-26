using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordInputField : MonoBehaviour
{
    // A public reference to the input field where the password will be entered
    public TMP_InputField inputField;
    public TMP_InputField inputField1;

    // A public reference to the Teacher Container game object
    public GameObject teacherContainer;

     public GameObject teacherDialog;

    // A public reference to the Menu Containers game object
    public GameObject incorrectPass;

    // A method that is called when the "Check" button is pressed
    public void CheckInput()
    {
        // Check if the input field text matches the password
        if (inputField.text == "password")
        {
            // Log a message to the console indicating that the password was accepted
            Debug.Log("Password accepted");

            // Set the active state of the Teacher Container game object to true, causing it to appear in the scene
            teacherContainer.SetActive(true);
            teacherDialog.SetActive(false);
            inputField.text = "";
            inputField1.text = "";
        }
        else
        {
            // Log a message to the console indicating that the password was incorrect
            
            teacherDialog.SetActive(false);
            // Activate the Menu Containers game object
            incorrectPass.SetActive(true);
            inputField.text = "";
            inputField1.text = "";
        }
    }
}

