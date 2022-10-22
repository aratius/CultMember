using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OscConfig : MonoBehaviour
{

    [SerializeField] private Text _portText;
    [SerializeField] private Button _submitButton;

    void Awake()
    {
        this._submitButton.onClick.AddListener(this._OnClick);
    }

    /// <summary>
    /// on click
    /// </summary>
    private void _OnClick()
    {
        try {
            int port = Int32.Parse(this._portText.text);
            OscReceiver.Instance.Set(port);
        } catch(FormatException)
        {
            Debug.LogWarning("Unable to parse");
        }
    }

}
