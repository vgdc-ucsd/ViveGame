using UnityEngine;
using System.Collections;

public class ScorchSpawner : MonoBehaviour {

    public Transform scorchPrefab;
    public float rayDist = 0.9f;
    public float sampleTime = 0.00f;
    public float placeEvery = 0.05f;

    private float currentDelay;
    private Collider lastCollider;
    private Vector3 lastHitPt;
    private Quaternion lastHitQ;
    private RaycastHit hitInfo;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = transform.parent.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        } else {
            if (Physics.Raycast(transform.position, transform.up, out hitInfo, rayDist)) {
                
                Vector3 hitPt = hitInfo.point;
                Quaternion hitQ = Quaternion.LookRotation(hitInfo.normal);

                float distance = (hitPt - lastHitPt).magnitude;
                if (lastCollider != hitInfo.collider)
                {
                    distance = 0;
                }

                for (int points = 0; points < distance / placeEvery; ++points) {
                    Vector3 pos = Vector3.Lerp(hitPt, lastHitPt, (points * placeEvery) / distance);
                    Quaternion rotation = Quaternion.Lerp(hitQ, lastHitQ, (points * placeEvery) / distance);
                    Transform scorchMark = Instantiate(scorchPrefab, pos, rotation) as Transform;
                    scorchMark.parent = hitInfo.collider.transform;
                    scorchMark.localScale = new Vector3(1/scorchMark.parent.localScale.x, 1/ scorchMark.parent.localScale.y, 1/ scorchMark.parent.localScale.z);
                    //scorchMark.Translate(0, 0f, 0f, Space.Self);
                }

                currentDelay = sampleTime;
                lastHitPt = hitPt;
                lastHitQ = hitQ;
                lastCollider = hitInfo.collider;
            }
        }
    }
}
