using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramform_Y : MonoBehaviour
{
    public GameObject[] Floor;
    float y;
    string Status = "Up";
    float Up, Down;
    // Start is called before the first frame update

    void Start()
    {
        Up = -3.5f;
        Down = -5f;

    }

    // Update is called once per frame
    void Update()
    {
        MoveX(Floor[0], Up, Down);  //เรียกใช้งาน โดนรับค่าบน ล่าง มา
        MoveX(Floor[1], Up, Down);
        MoveX(Floor[2], Up, Down);
    }
    void MoveX(GameObject Floor, float Up, float Down) //รับค่า GOJ,Up<Down
    {
        if (Floor.transform.position.y <= Down) //ถ้าFloor ตำแหน่ง X มากกว่าหรือเท่ากับ Down 
        {
            Status = "Up"; //Status เท่ากับ Left
        }
        if (Floor.transform.position.y >= Up) //ถ้าFloor ตำแหน่ง X น้อยกว่าหรือเท่ากับ Up
        {
            Status = "Down";
        }

        if (Status == "Down") //ถ้าStatus เท่ากับ Down
        {
            y = -0.009f; //ให้ X เท่ากับ -0,1f
        }
        if (Status == "Up")//ถ้าStatus เท่ากับ Up
        {
            y = 0.009f; //ให้ X เท่ากับ 0,1f
        }
        Floor.transform.position += new Vector3(0, y, 0); //คำสั่งเคลื่อนที่ 
    }
}
