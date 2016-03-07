using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour
{
    Vector3 force;
    private float time;
    public float duration = 1.0f;
    bool wasKinematic;

	// Use this for initialization
	void Start () {
	    force = new Vector3(0, 0, 0);
        wasKinematic = GetComponent<Rigidbody>().isKinematic;
    }

    public void Throw(Vector3 direction)
    {
        force = direction;
        time = duration;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.VelocityChange);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (time <= 0)
        {
	        force = new Vector3(0, 0, 0);
            rigidbody.isKinematic = wasKinematic;
        }
	    time -= Time.deltaTime;
	}
}
