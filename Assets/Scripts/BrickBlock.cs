using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour {

    private SpriteRenderer sr;

    public Sprite explodedBlock;

    public float secBeforeSpriteChange = 0.2f;

	void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.contacts[0].point.y < transform.position.y)
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.rockSmash);

            sr.sprite = explodedBlock;
            DestroyObject(gameObject, secBeforeSpriteChange);
        }
    }
}
