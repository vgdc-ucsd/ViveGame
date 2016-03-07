using UnityEngine;
using System.Collections;
using Valve.VR;

public class Lightsaber : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public float forceRadius = 2.0f;
    public float forceRange = 25.0f;
    public float forceStrength = 5.0f;

    private int powers = 2;
    private int currentPower = 0;

    // Use this for initialization
    void Start ()
    {
        trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
	    var sound = GetComponent<AudioSource>().pitch = 1.0f + device.velocity.magnitude / 10.0f;
	    if (device.GetHairTriggerDown())
	    {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position + transform.up * forceRadius, forceRadius, transform.up);
	        foreach (var hit in hits)
	        {
	            var obj = hit.transform.GetComponent<Throwable>();
	            if (obj == null) continue;
	            var direction = (hit.transform.position - transform.position).normalized;
	            if (currentPower == 0)
	            {
	                obj.Throw(direction*forceStrength);
	            }
                else if (currentPower == 1)
                {
                    obj.Throw(direction * -forceStrength);
                }
	        }
        }
	    if (device.GetPress(EVRButtonId.k_EButton_SteamVR_Touchpad))
	    {
	        var vec = device.GetAxis();
	        if (vec != new Vector2(0.0f, 0.0f))
	        {
	            float angle = Mathf.Atan2(vec.y, vec.x) + Mathf.PI;
                currentPower = (int) (angle / (2*Mathf.PI/powers));
	            Debug.Log(currentPower);
	        }
	    }
    }

    void OnTriggerEnter(Collider other)
    {
        Destructible dest;
        if (dest = other.GetComponent<Destructible>())
        {
            dest.OnDamage(100);
        }
    }

    void OnTriggerStay(Collider other)
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        device.TriggerHapticPulse(2000);
    }
}
