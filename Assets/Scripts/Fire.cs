using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public int FireSpeed = 4;
 


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * FireSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Astronaut"))
        {
            if(collision.gameObject.GetComponent<AstMove>().Health > 0)
            {
                if (collision.gameObject.GetComponent<AstMove>().OnBlock)
                {
                    collision.gameObject.GetComponent<AstMove>().Health -= 2;
                }
                else
                {
                    collision.gameObject.GetComponent<AstMove>().Health -= 15;
                }
                if (collision.gameObject.GetComponent<AstMove>().Health <= 0)
                {
                    collision.GetComponent<Animator>().SetBool("Vanish", true);
                    this.gameObject.SetActive(false);
                }
            }
            

        }
    }
}

 