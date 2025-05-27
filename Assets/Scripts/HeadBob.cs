using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    float Frequency = 10f, Amount = 0.002f, Smooth = 10.0f;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHeadBob();
        StopHeadBob();
    }

    private void CheckForHeadBob()
    {
        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        if(inputMagnitude>0)
        {
            StartHeadBob();
        }
    }

    private Vector3 StartHeadBob()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * Frequency) * Amount * 1.4f, Smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * Frequency / 2f) * Amount * 1.6f, Smooth * Time.deltaTime);
        transform.localPosition += pos;
        return pos;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == startPos) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, 1 * Time.deltaTime);
    }
}
