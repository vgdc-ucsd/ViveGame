using UnityEngine;
using System.Collections;

public class FlyAt : MonoBehaviour
{
    public string targetTag;
    public float speed = 1;
    private float currentSpeed;

    private Rigidbody rigidbody;
    private Transform target;

	// Use this for initialization
	void Start ()
	{
	    rigidbody = GetComponent<Rigidbody>();
	    target = GameObject.FindGameObjectWithTag(targetTag).transform;
	    currentSpeed = speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 direction = (target.position - transform.position);
	    direction.y = 0;
	    direction = Vector3.Normalize(direction);
        rigidbody.MovePosition(transform.position + direction*speed*Time.deltaTime);
	}
}
