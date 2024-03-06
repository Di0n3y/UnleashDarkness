using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveText : MonoBehaviour
{
    [SerializeField]  TMP_InputField inputField;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button saveButton;
    private Vector3 playerPos = Vector3.zero;
    public GameObject player;

    private string textToSave;
    
    void Start()
    {

        text.text = textToSave = PlayerPrefs.GetString("Text", "No_Save_Data");


        var tempPos = PlayerPrefs.GetString("PlayerPos", "Error");
        if(tempPos.Equals("Error"))
        {

            playerPos = player.transform.position;
            PlayerPrefs.SetString("PlayerPos",JsonUtility.ToJson(playerPos));
        }
        else
        {

            playerPos = JsonUtility.FromJson<Vector3>(tempPos);
            player.transform.position = playerPos;
        }
     
        
        
        
        saveButton.onClick.AddListener(SaveButton);
        
        
        /*
        if(PlayerPrefs.HasKey("Text")) 
        {
        
        textToSave = PlayerPrefs.GetString("Text");
            text.text = textToSave;
        }
        else
        {
            textToSave = PlayerPrefs.GetString("Text", "No Save Data");
            textToSave = PlayerPrefs.GetString("Text");
            text.text = textToSave;
        }
        */
    }

    public void SaveButton()
    
    { 
    if (string.IsNullOrEmpty(inputField.text)||
            !string.IsNullOrWhiteSpace(inputField.text))
        { 
        textToSave = inputField.text;
                PlayerPrefs.SetString("Text", textToSave);
            text.text = textToSave;


        }
    
    
    }

   
 
}
