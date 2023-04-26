using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class MenuControls : MonoBehaviour
{
    [Header("Levels To Load")]
    public string newGameLevel;
    private string levelToLoad;

    [SerializeField]
    private GameObject noSavedGameDialog = null;

    public void NewGamePlay()
    {
        SceneManager.LoadScene(newGameLevel);
        CreateMathLog.writeUserName(PlayerPrefs.GetString("user_name"));
    }

   // public void LoadGameDialogYes()
   // {
   //     if (PlayerPrefs.HasKey("SavedLevel"))
   //     {
   //        levelToLoad = PlayerPrefs.GetString("SavedLevel");
   //         SceneManager.LoadScene(levelToLoad);
   //     }
   //     else
   //     {
   //         noSavedGameDialog.SetActive(true);
   //     }
   // }

    public void ExitButton()
    {
        Application.Quit();
    }
}