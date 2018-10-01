using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rightward()
    {
        PushTowards(Vector3.right);
    }

    public void Leftward()
    {
        PushTowards(Vector3.left);
    }

    public void Upward()
    {
        PushTowards(Vector3.up);
    }

    public void Downward()
    {
        PushTowards(Vector3.down);
    }

    private void PushTowards(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(2.5f * direction, ForceMode.Impulse);
    }
    
}
