using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject circle;

    public void ShowCircle()
    {
        circle.SetActive(true);
    }

    public void HideCircle()
    {
        circle.SetActive(false);
    }
}
