using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsernameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI username;

    public void setUsername(string newUsername) {
        username.text = newUsername;
    }

    void Start() {
        setUsername(PlayerPrefs.GetString("user_name", "NAME NOT FOUND"));
    }
}
