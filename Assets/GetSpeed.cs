using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeed : MonoBehaviour {
    public Vector2 heroSpeed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        heroSpeed = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        Debug.Log("VITESSE " + heroSpeed);
    }
}
