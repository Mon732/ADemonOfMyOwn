using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnInterval = 10;
    public float radius = 1;

    [SerializeField] float spawnTime;

	// Use this for initialization
	void Start ()
    {
        spawnTime = Time.time + spawnInterval;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (spawnTime < Time.time)
        {
            Debug.Log("Spawning");

            Vector2 circle = Random.insideUnitCircle;
            Vector3 position = new Vector3(circle.x, 0, circle.y);
            position *= radius;

            GameObject objectToSpawn = objectsToSpawn[(int)(Random.value * objectsToSpawn.Length)];

            Instantiate(objectToSpawn, transform.position + position, Quaternion.identity);

            spawnTime = Time.time + spawnInterval;
        }
	}
}
