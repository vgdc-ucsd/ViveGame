using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

    public Transform[] destructionRemains;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDamage(float damage)
    {
        foreach (Transform obj in destructionRemains)
        {
            var explosion = Instantiate(obj);
            explosion.position = transform.position;
        }
        Destroy(this.gameObject);

    }
}
