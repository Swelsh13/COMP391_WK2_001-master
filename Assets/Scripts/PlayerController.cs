using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class PlayerController : MonoBehaviour {
    // Public fields
    public float speed;
    public Boundary boundary;

    public GameObject laser;
    public Transform laserSpawn;

    // Private fields
    private Rigidbody2D rb;

    // Time delay for shooting
    public float nextFire = 0.25f;
    private float myTime = 0.0f;

    // Runs ONCE, when object is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Called once per frame (NON PHYSICS)
    void Update()
    {
        myTime += Time.deltaTime;

        if(Input.GetButton("Fire1") && myTime > nextFire)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);

            myTime = 0.0f;
        }
    }

    // Update is called once per frame (USED FOR PHYSICS)
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}
}
