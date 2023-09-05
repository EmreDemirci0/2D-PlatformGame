using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DENEEM : MonoBehaviour
{
    public RaycastHit2D hit;
    public Vector2 vec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vec = new Vector2(transform.position.x + 100f, 0);
        hit= Physics2D.Raycast(transform.position,new Vector2(10000, 0) , 100f);
        Debug.DrawRay(transform.position, hit.point, Color.red);
    }
}
