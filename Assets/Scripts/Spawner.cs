using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform objectToSpawn;
    public float spawnTime;

    private float remaining;

	// Use this for initialization
	void Start ()
	{
	    remaining = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
	    if (remaining < 0)
	    {
	        remaining = spawnTime;
	        Instantiate(objectToSpawn, this.transform.position, this.transform.rotation);
	    }
	    remaining -= Time.deltaTime;
	}
}
