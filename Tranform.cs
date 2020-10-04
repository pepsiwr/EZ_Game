using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Wall_Right")
        {
            transform.Translate(0, -0.005f, 0);
        }
        else if(gameObject.name == "Wall_Left")
        {
            transform.Translate(0, 0.005f, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player") 
        {
            Destroy(GameObject.Find("Character")); //ให้หาGameObjectที่ชื่อ "Character"แล้วลบ
        }
    }
}
