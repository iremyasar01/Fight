using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AstMove : MonoBehaviour
{
    public Animator animator;
    public float WalkSpeed = 5, JumpForce= 30;
    public Rigidbody2D rb;
    public bool OnBlock;
    public int Health = 100;
    public Slider HealthBar;


    // Start is called before the first frame update
    void Start()
    {
       
    }
    void AnimationReset(string animationName)
    {
        animator.SetBool("Walk", false);
        //animator.SetBool("RightRun", false);
        //animator.SetBool("LeftRun", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Block", false);
        animator.SetBool(animationName, true);
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = Health;
        //HealthBar.value = (float)Health / 100.0f;

        //bastığım sürece çalışsın basılı kaldığımda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AnimationReset("Walk");
            transform.Translate(Vector3.left*Time.deltaTime*WalkSpeed);
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AnimationReset("Walk");
            transform.Translate(Vector3.right * Time.deltaTime * WalkSpeed);
           
        }
        //bi kere çalışsın diye.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * JumpForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("Slide");
        }
        if (Input.GetKey(KeyCode.B))
        {
            animator.SetTrigger("Block");
            OnBlock = true;
        }
        else if (Input.anyKey == false)
        {
            AnimationReset("Idle");
            OnBlock = false;
        }
        
    }
}
