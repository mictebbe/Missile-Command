using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingCursor : MonoBehaviour
{

   
    private InputField inputField;

    void Start()
    {
        inputField = gameObject.GetComponent<InputField>();
        inputField.Select();
        inputField.caretWidth = 5;

    }
    
}