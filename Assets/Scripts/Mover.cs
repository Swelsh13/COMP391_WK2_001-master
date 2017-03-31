using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is my mover script for the laser bean
 * 
 * */

public class Mover : MonoBehaviour {
    // Public fields
    public float speed;

    // Private fields
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
	}
}
