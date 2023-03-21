using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collectables = 0;

    [SerializeField] private Text collectablesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {

	
        if (collision.gameObject.CompareTag("Collectable"))
        {
        	Destroy(collision.gameObject);
            	collectables++;
            	Debug.Log("Items: " + collectables);
            	collectablesText.text = "Items: " + collectables;
	}
	
	
    }
}
