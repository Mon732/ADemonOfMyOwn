using UnityEngine;
using System.Collections;

public class DemonAI : MonoBehaviour
{
    public GameObject body;
    public float baseSpeed = 2;
    public float baseTurn = 5;

    int attack = 0;
    int speed = 0;
    int defence = 0;
    Color colour = Color.black;

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        FacePlayer();
        MoveForwards();
	}

    void FacePlayer()
    {
        if (player != null)
        {
            Quaternion rot = Quaternion.LookRotation(player.transform.position - transform.position, transform.up);
            rot = new Quaternion(0, rot.y, 0, rot.w);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, baseTurn * Time.deltaTime);
        }
    }

    void MoveForwards()
    {
        Vector3 movementVector = new Vector3(0, 0, baseSpeed);
        transform.Translate(movementVector * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");

        if (other.gameObject.layer == 8)
        {
            Debug.Log("Player");
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 5);
            Destroy(other.gameObject);
        }
    }
}
