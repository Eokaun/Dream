using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCloudCollision : MonoBehaviour {
    GetSpeed radar;
    Vector2 vitesse;
	// Use this for initialization
	void Start () {
        radar = GameObject.Find("Radar").GetComponent<GetSpeed>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        vitesse = radar.heroSpeed;
        Debug.Log(vitesse);
        Debug.Log("I'm in !");
        // If the object we hit is the enemy
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("I'm in !");
            // Calculate Angle Between the collision point and the player
            Vector2 dir = transform.position - c.transform.position;
            Debug.Log(dir);
            // We then get the opposite (-Vector3) and normalize it
            Debug.Log("Normalized -dir "+dir + "Force" + vitesse);
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            c.gameObject.GetComponent<Rigidbody2D>().AddForce(dir*vitesse*65);
        }
    }
}

