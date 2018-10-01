using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeFollow : MonoBehaviour {

    public float panningSpeed;
    public float edgeBorder;
    public Transform target;
    private Camera c;

	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();
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
        transform.position +=
            CloseToAnEdge(viewportPoint.x, edgeBorder) * panningDelta * Vector3.right +
            CloseToAnEdge(viewportPoint.y, edgeBorder) * panningDelta * Vector3.up;
    }
}
