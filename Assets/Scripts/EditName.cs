using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditName : MonoBehaviour
{

    [SerializeField] private TMP_InputField _inputField;

    public void SaveName()
    {
        GameManager.Instance.SetTopNames(_inputField.text);
    }

}
