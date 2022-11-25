using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    //Data Types
    /* public/private typeOfData GiveItAName
     * 
     * Int: 1,2,3,000
     * Float: 1.3, 0.1, 4.44
     * Boolean: true, flase (1,0)
     * String: sfsafas
     * */

    private int health = 100;
    float power = 20.5f;
    bool isPlayerAlive = true;
    string helloWorld = "Hello World!";

    [Header("My Calculator")]
    [SerializeField] int[] values = new int[2];

    [SerializeField] List<GameObject> myObjectList = new List<GameObject>();

    [SerializeField] int day;
    // Start is called before the first frame update
    void Start()
    {
        //for(int i =values.Length - 1; i >= 0; i--)
        //{
        //    Debug.Log(values[i]);
        //}

        //var dynamic value
        //var myNumber = 23;
        //foreach(int value in values)
        //{
        //    Debug.Log(value);
        //}

        //int a = 0;
        //while(a<10)
        //{
        //    a++;
        //    Debug.Log(a);
        //}

        //Debug.Log(myObjectList[1]);
        //MyDebugMessages();
        //Debug.Log(CheckPlayerStatus());
        //Debug.Log(Addition(values[0], values[1]));


    }

    bool isObjectActive = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isObjectActive == true)
            {
                foreach (var myObject in myObjectList)
                {
                    myObject.SetActive(false);
                }
                isObjectActive = false;
            } else{
                foreach (var myObject in myObjectList)
                {
                    myObject.SetActive(true);
                }
                isObjectActive = true;
            }
        }

        switch (day)
        {
            case 1:
                Debug.Log("Monday");
                break;
            case 2:
                Debug.Log("Tuesday");
                break;
            case 3:
                Debug.Log("Wednesday");
                break;
            case 4:
                Debug.Log("Thursday");
                break;
            case 5:
                Debug.Log("Friday");
                break;
            case 6:
                Debug.Log("Saturday");
                break;
            case 7:
                Debug.Log("Sunday");
                break;
            default:
                break;
        }
    }


    private void MyDebugMessages()
    {
        Debug.Log(helloWorld);
        Debug.Log("My health is: " + health);
        Debug.Log("My Power is: " + power);
        Debug.Log("Is Player Alive? " + isPlayerAlive);
    }

    bool CheckPlayerStatus()
    {
        Debug.Log("Is Player Alive?");
        return isPlayerAlive;
    }
    
    int Addition(int a=0, int b=1)
    {
        int sum = a + b;
        return sum;
    }

}

