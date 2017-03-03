using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour
{
    public GameObject body;
    public float baseSpeed = 5;
    public float baseTurn = 100;

    int attack = 0;
    int speed = 0;
    int defence = 0;
    Color colour = Color.black;

    // Use this for initialization
    void Start ()
    {
        SetColour(colour);
	}
	
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 movementVector = new Vector3(0, 0, v);
        Vector3 turnVector = new Vector3(0, h, 0);

        movementVector *= baseSpeed;
        turnVector *= baseTurn;

        transform.Translate(movementVector * Time.deltaTime);
        transform.Rotate(turnVector * Time.deltaTime);
    }

    public void SetColour(Color colour)
    {
        body.GetComponent<Renderer>().material.color = colour;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");

        if (other.gameObject.layer == 9)
        {
            Debug.Log("Demon");
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 5);
            Destroy(other.gameObject, 1);
        }
    }
}