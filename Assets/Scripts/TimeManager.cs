using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void SlowTimeSpeed()
    {
        // Check later if slow value is a good fit.
        Time.timeScale = 0.75f;
    }

    public void ResetTimeSpeed()
    {
        Time.timeScale = 1f;
    }
}
