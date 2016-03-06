using UnityEngine;
using System.Collections;

public class Lightsaber : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Destructible dest;
        if (dest = other.GetComponent<Destructible>())
        {
            dest.OnDamage(100);
        }
    }
}
