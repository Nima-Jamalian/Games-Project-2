using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMangerMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClick()
    {
        if(nameInputField.text == "")
        {
            nameInputField.placeholder.color = Color.red;
        } else
        {
            UserData.name = nameInputField.text;
            SceneManager.LoadScene(1);
            //Debug.Log(nameInputField.text);
            //Debug.Log("Play button pressed.");
        }
    }

    public void OnHowToPlayerButtonClick()
    {
        Debug.Log("How to play button pressed");
    }
}
