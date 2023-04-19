using UnityEngine;
using TMPro;

public class PasswordFields : MonoBehaviour
{
    public TMP_InputField password;

    void Start()
    {
        password.contentType = TMP_InputField.ContentType.Password;
    }
}