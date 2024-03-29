using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossMove : MonoBehaviour
{
    public Animator animator;
    public float RunSpeed = 5;
    public GameObject Fire;

    void AnimationBoss(string animationName)
    {
        animator.SetBool("RightRun", false);
        animator.SetBool("LeftRun", false);
        animator.SetBool("Idle", false);
        animator.SetBool(animationName, true);
    }

    // Update is called once per frame
    void Update()
    {
        //bastığım sürece çalışsın basılı kaldığımda
        if (Input.GetKey(KeyCode.D))
        {
            AnimationBoss("RightRun");
            transform.Translate(Vector3.right * Time.deltaTime * RunSpeed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            AnimationBoss("LeftRun");
            transform.Translate(Vector3.left * Time.deltaTime * RunSpeed);

        }
        /*
        //bi kere çalışsın diye.
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * JumpForce);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up);
            //animator.SetTrigger("Jump");
        }
        */
        //arka arkaya basıldığında bir kere çalışsın diye
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("RAttack");
            Invoke(nameof(Attack), 0.5f);
            //0.5 saniye beklesin.
        }
        
        else if (Input.anyKey == false)
        {
            AnimationBoss("Idle");
        }
      
    }
   void Attack()
    {
      
        GameObject newFire = Instantiate(Fire, transform.position, Quaternion.identity);
        //oluşan fire'ım karakterin üzerinde oluşsun ve rotaionu 0 0 olsun.
        newFire.SetActive(true);
    }

}