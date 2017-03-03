using UnityEngine;
using System.Collections;

public class Pentagram : MonoBehaviour
{
    public GameObject demon;
    public int itemsOffered = 0;
    public int maxItems = 3;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void CheckSummon()
    {
        if (itemsOffered >= maxItems)
        {
            Summon();

            int childCount = transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    void Summon()
    {
        demon.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (itemsOffered <= maxItems)
        {
            if (other.gameObject.layer == 10)
            {
                if (!other.transform.IsChildOf(transform))
                {
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.GetComponent<Pickup>().enabled = false;

                    other.transform.SetParent(transform, false);

                    itemsOffered++;

                    CheckSummon();
                }
            }
        }
    }
}
