using UnityEngine;
using System;
using System.Collections;
using UnityStandardAssets.Cameras;

public class CharacterCamera : AutoCam
{
    [SerializeField] private targetData[] targets;
    int targetIndex = 0;

	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Z))
        {
            targets[targetIndex].scriptName.enabled = false;
            
            targetIndex++;
            targetIndex %= targets.Length;
            m_Target = targets[targetIndex].target.transform;

            targets[targetIndex].scriptName.enabled = true;
        }
	}

    [System.Serializable]
    struct targetData
    {
        public GameObject target;
        public MonoBehaviour scriptName;
    }
}
