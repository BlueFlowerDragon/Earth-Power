using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListLight : MonoBehaviour
{
    public bool targeted;
    public GameObject IMG;
    // Start is called before the first frame update
    void Awake()
    {
        targeted = false;
    }
    public void Refresh()
    {
        if(targeted == true)
        {
            IMG.SetActive(true);
        }
        else
        {
            IMG.SetActive(false);
        }
    }
}
