using UnityEngine;
using System.Collections;

public class Lightsaber : MonoBehaviour
{
    public Transform explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Destructible>())
        {
            var explosion = Instantiate(explosionPrefab);
            explosion.position = other.transform.position;
            Destroy(other.gameObject);
            Destroy(other.gameObject, 1);
        }
    }
}
