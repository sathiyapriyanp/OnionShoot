using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")  
        {
            Debug.Log("collision enter");
            
            
            
            Destroy(gameObject);
            Destroy(collision.gameObject);
            UI.instance.AddScore();

        }
    }

    void Update()
    {
       
    }
}
