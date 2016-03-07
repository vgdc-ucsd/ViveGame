using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour {
    public float shrinkTime = 2.5f;
    public float deleteTime = 5f;

    private float time = 0;

    private Vector3 fullSize = new Vector3(1, 1, 1);
    private Vector3 zeroSize = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        fullSize = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > shrinkTime)
        {
            transform.localScale = Vector3.Lerp(fullSize, zeroSize, (time - shrinkTime) / (deleteTime - shrinkTime));
        }
        if (time > deleteTime)
        {
            Destroy(this.gameObject);
        }
	}
}
