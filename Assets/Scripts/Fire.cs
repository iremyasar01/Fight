using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            collision.GetComponent<Animator>().SetBool("Vanish", true);
            this.gameObject.SetActive(false);
        }
    }
}
