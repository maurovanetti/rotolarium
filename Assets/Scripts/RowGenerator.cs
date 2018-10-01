using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowGenerator : MonoBehaviour {
    public int size;
    public GameObject prefab;

	// Use this for initialization
	void Start () {
        float center = transform.position.x;
        float width = prefab.GetComponentInChildren<Renderer>().bounds.size.y;
		for (int i = 0; i < size; i++)
        {
            float x;
            if (i % 2 == 0)
            {
                x = center + width * i;
            }
            else
            {
                x = center - width * (i + 1);
            }
            GameObject gameObject = Instantiate<GameObject>(prefab, this.transform);
            gameObject.transform.position = new Vector3(x, transform.position.y, transform.position.z);
            gameObject.name += " (item #" + i + ")";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
