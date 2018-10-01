using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    public string[] tags;
    public string message;

	// Use this for initialization
	void Start () {
	}


    // Update is called once per frame
    void Update() {
    }

    private void BroadcastMessage()
    {
        Fungus.Flowchart.BroadcastFungusMessage(message);
    }

    private bool FilterCollisionByTag(GameObject gameObject)
    {
        if (tags.Length == 0)
        {
            BroadcastMessage();
            return true;
        }
        foreach (string tag in tags)
        {
            if (gameObject.CompareTag(tag))
            {
                BroadcastMessage();
                return true;                    
            }
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        FilterCollisionByTag(collision.collider.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        FilterCollisionByTag(other.gameObject);
    }
}
