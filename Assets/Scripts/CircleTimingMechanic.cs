using UnityEngine;

public class CircleTimingMechanic : MonoBehaviour
{
    public GameObject outerCircle;
    public GameObject innerCircle;
    public float perfectThreshold = 1f;
    public float timePassed;
    public bool isPerfect = false;
    public bool readyToShrink = false;

    public float shrinkSpeed = 2f;
    private Vector3 outerCircleInitialScale;

    void Start()
    {
        outerCircleInitialScale = outerCircle.transform.localScale;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(outerCircle.activeSelf && innerCircle.activeSelf)
        {
            readyToShrink = true;
        }
        else
        {
            readyToShrink = false;
        }

        if(readyToShrink)
            ShrinkCircle();

        if(timePassed * 2 > 2.1f)
        {
            ResetCircle();
            timePassed = 0;
        }

        if(GetDistance() <= perfectThreshold)
        {
            isPerfect = true;
        }
        else
        {
            isPerfect = false;
        }

        if (isPerfect && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Perfect!");
            ResetCircle();
        }
        else if (!isPerfect && Input.GetKeyDown(KeyCode.X))
        {
            //Debug.Log("Time passed: " + timePassed * 2);
            Debug.Log("Distance: " + GetDistance() + " , Perfect Threshold: " + perfectThreshold);
            Debug.Log("Missed!");
            ResetCircle();
        }
    }

    public float ShrinkCircle()
    {
        float timeToShrink = shrinkSpeed * Time.deltaTime;
        outerCircle.transform.localScale = Vector3.Lerp(outerCircle.transform.localScale, innerCircle.transform.localScale, timeToShrink);
        return timeToShrink;
    }

    public void ResetCircle()
    {
        outerCircle.transform.localScale = outerCircleInitialScale;
    }

    public float GetDistance()
    {
        float distance = outerCircle.transform.localScale.x - innerCircle.transform.localScale.x;
        return distance;
    }

}
