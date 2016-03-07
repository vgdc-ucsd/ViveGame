using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour
{
    Vector3 force;
    private float time;
    public float duration = 0.5f;
    bool wasKinematic;

	// Use this for initialization
	void Start () {
	    force = new Vector3(0, 0, 0);
	}

    public void Throw(Vector3 direction)
    {
        force = direction;
        time = duration;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (time > 0)
	    {
	        rigidbody.MovePosition(transform.position + force*Time.deltaTime);
	        wasKinematic = rigidbody.isKinematic;
            rigidbody.isKinematic = false;
	    }
	    else
	    {
	        force = new Vector3(0, 0, 0);
            rigidbody.isKinematic = wasKinematic;
        }
	    time -= Time.deltaTime;
	}
}
