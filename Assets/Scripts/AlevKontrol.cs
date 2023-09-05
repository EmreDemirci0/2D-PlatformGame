using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlevKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Taban")
        {
            //Debug.Log("Girdi");
            Destroy(gameObject);
        }
    }
}

