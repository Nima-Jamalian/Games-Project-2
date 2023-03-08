using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputSystem : MonoBehaviour
{
    [SerializeField] bool w, a, s, d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            w = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            w = false;
        }

    }
}
