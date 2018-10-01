using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeZoomFollow : MonoBehaviour {
    
    public float panningSpeed;
    public float zoomingSpeed;
    public float edgeBorder;
    public Transform target;

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
        Vector3 viewportPoint = c.WorldToViewportPoint(target.position);
        float panningDelta = panningSpeed * Time.deltaTime;
        float zoomingDelta = zoomingSpeed * Time.deltaTime;
        Vector3 cameraMovement =
            CloseToAnEdge(viewportPoint.x, edgeBorder) * panningDelta * Vector3.right +
            CloseToAnEdge(viewportPoint.y, edgeBorder) * panningDelta * Vector3.up;
        if (cameraMovement.magnitude > 0 && transform.position.z > minZ)
        {            
            cameraMovement += zoomingDelta * Vector3.back;
        }
        else
        {
            cameraMovement = Mathf.Clamp(initialZ - transform.position.z, 0, zoomingDelta) * Vector3.forward;
        }
        transform.position += cameraMovement;

    }
}
