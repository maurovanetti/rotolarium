using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoveFollow : MonoBehaviour {

    public Transform target;
    public float range;
    public float shove;

    private Transform t;
    private Rigidbody rb;    

	// Use this for initialization
	void Start () {        
        t = transform;
        t.SetPositionAndRotation(target.position, t.rotation);
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = (target.position - t.position);
        if ((target.position - t.position).magnitude > range)
        {
            rb.AddForce(delta * shove);
        }
	}
}
