using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    // Constructor
    public Golem()
    {
        health = 10f;
    }

    protected override void Die()
    {
        Debug.Log("Golem died");
        this.gameObject.SetActive(false);
    }
}
