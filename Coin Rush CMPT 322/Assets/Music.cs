using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
   private void Awake() {
    GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
    if (musicObj.Length > 1) {
        Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
   }
}
