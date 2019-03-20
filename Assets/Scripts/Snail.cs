using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {

    public float speed = 5f;
    Vector2 direction = Vector2.right;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction;    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);

        direction = new Vector2(-1 * direction.x, direction.y);
    }

    void OnCollisionEnter2D(Collision2D col)  
    {
        if(col.gameObject.name == "Manny")
        {
            if(col.contacts[0].point.y > transform.position.y)
            {
                GetComponent<Animator>().SetTrigger("Dead");
                GetComponent<Collider2D>().enabled = false;
                direction = new Vector2(direction.x, -1);

                DestroyObject(gameObject, 2);
            }
            else
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.mannyDies);
                DestroyObject(col.gameObject, .5f);
            }
        }
    }
}
