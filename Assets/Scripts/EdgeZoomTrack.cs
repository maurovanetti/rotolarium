using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeZoomTrack : MonoBehaviour {

    public Transform target;
    public float edgeBorder;
    public float minVelocityForZoom;

    private float initialZ;
    private float minZ;
    private Camera c;

	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();
        if (c == null)
        {
            c = Camera.main;
        }
        initialZ = transform.position.z;
        minZ = initialZ - (c.farClipPlane / 2);
    }
	
    private int CloseToAnEdge(float viewportCoordinate, float edgeBorder)
    {
        if (edgeBorder >= 0.5f)
        {
            Debug.LogError("Edge border must be below 0.5!");
        }
        float offset = viewportCoordinate - 0.5f;
        float maxOffset = 0.5f - edgeBorder;
        if (offset > maxOffset)
        {
            return +1;
        }
        else if (offset < -maxOffset)
        {
            return -1;
        }
        return 0;
    }

	// Update is called once per frame
	void Update () {
        float x, y, velocity, z;
        Vector3 viewportPoint = c.WorldToViewportPoint(target.position);
        if (CloseToAnEdge(viewportPoint.x, edgeBorder)  != 0 || CloseToAnEdge(viewportPoint.y, edgeBorder) != 0)
        {
            x = target.position.x;
            y = target.position.y;
        }
        else
        {
            x = transform.position.x;
            y = transform.position.y;
        }
        velocity = target.GetComponent<Rigidbody>().velocity.magnitude;
        if (velocity < minVelocityForZoom)
        {
            velocity = 0;
        }
        z = initialZ - velocity;
        transform.position = new Vector3(x, y, z);
    }
}
