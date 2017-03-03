using UnityEngine;
using System.Collections;

public class DeleteObject : MonoBehaviour
{
    void OnTriggerEnter(Collider Other)
    {
        Debug.Log(Other.name);
        Destroy(Other.gameObject);
    }
}
