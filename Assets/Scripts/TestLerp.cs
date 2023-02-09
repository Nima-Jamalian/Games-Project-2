using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLerp : MonoBehaviour
{
    //[SerializeField] float starPoint;
    //[SerializeField] float endPoint;
    //[SerializeField] float t;
    //[SerializeField] float output;

    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] float t;
    [SerializeField] float duration;
    [SerializeField] Color outputColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(t < duration)
        {
            outputColor = Color.Lerp(startColor, endColor, t / duration);
            t += Time.deltaTime;
        }
    }
}
