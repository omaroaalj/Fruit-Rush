using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private static bool charCollided = false;

    public static bool getCollisionPresent() {
        return charCollided;
    }

    public static void setCollisionPresent(bool collidedCondition) {
        charCollided = collidedCondition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            MathKeypadInput.setRandomNumbers();
            charCollided = true;
            Destroy(collision.gameObject);
        }
    }
}