using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRT_Player : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;

    float xInput, yInput;
    public float speed = 5;
    float speedJump = 7;
    private AudioSource audioSource;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localScale;
        if(Input.GetButton("Horizontal"))
        {
            xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            MoveHorizontal();

            if(Input.GetAxis("Horizontal")<0)
            {
                characterScale.x = 0.055f;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = -0.055f;
            }
            transform.localScale = characterScale;
        }
        else
        {
            anim.SetBool("BoolWalk", false);
        }
        if (Input.GetButton("Jump"))
        {
           // yInput = Input.GetAxis("Jump") * speedJump * Time.deltaTime;
            
            audioSource.PlayOneShot(SoundManager.Instance.Jump);  //ใส่เสียงให้การกระโดด
            MoveJump();
        }
        else
        {
            anim.SetBool("BoolJump", false);
        }
    }


    void  MoveHorizontal()
    {
        anim.SetBool("BoolWalk", true);
        transform.Translate(xInput, 0, 0);
    }
    void MoveJump()
    {
        anim.SetBool("BoolJump", true);
        //transform.Translate(0, yInput, 0);
        if(Input.GetButtonDown("Jump")&& isGrounded==true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstruction")
        {
            Destroy(GameObject.Find("Character")); //ให้หาGameObjectที่ชื่อ "Character"แล้วลบ
        }
    }
}
