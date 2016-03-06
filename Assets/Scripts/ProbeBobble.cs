using UnityEngine;
using System.Collections;

public class ProbeBobble : MonoBehaviour {

    public float heightAmount = 0.05f;
    public float heightFrequency = 2f;
    public float driftAmountX = 0.025f;
    public float driftAmountY = 0.025f;
    public float driftFrequencyX = 0.64f;
    public float driftFrequencyY = 0.32f;
    public float bobbleAmountY = 3f;
    public float bobbleAmountZ = 10f;
    public float bobbleYFreq = 2f;
    public float bobbleZFreq = 1.28f;

    private float time;
    private float currentHeight;
    private float currentDriftX;
    private float currentDriftY;
    private float currentRotationY;
    private float currentRotationZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        float oldHeight = currentHeight;
        float oldX = currentDriftX;
        float oldY = currentDriftY;
        float oldRotationY = currentRotationY;
        float oldRotationZ = currentRotationZ;
        currentHeight = heightAmount * Mathf.Sin(heightFrequency * time);

        currentDriftX = driftAmountX * Mathf.Sin(driftFrequencyX * time);
        currentDriftY = driftAmountY * Mathf.Cos(driftFrequencyY * time);

        currentRotationY = bobbleAmountY * Mathf.Cos(bobbleYFreq * time);
        currentRotationZ = bobbleAmountZ * Mathf.Sin(bobbleZFreq * time);
        this.transform.Rotate(0, currentRotationY - oldRotationY, currentRotationZ - oldRotationZ);

        this.transform.Translate(currentDriftX - oldX, currentHeight - oldHeight, currentDriftY - oldY, Space.World);
	}
}
