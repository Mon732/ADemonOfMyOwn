using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public string objectToSpawn;
    public int attack;
    public int speed;
    public int defence;
    public Color colour;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (!enabled)
        {
            return;
        }

        if (other.tag == "Player")
        {
            Character character = other.GetComponent<Character>();

            if (!character.IsInventoryFull())
            {
                character.AddInventoryItem(objectToSpawn, attack, speed, defence, colour);
                Destroy(gameObject);
            }
        }
    }
}