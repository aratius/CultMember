using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class History : MonoBehaviour
{

    [SerializeField] private Text _tsText;
    [SerializeField] private Text _addressText;
    [SerializeField] private Text _valueText;

    /// <summary>
    /// set values
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="address"></param>
    /// <param name="value"></param>
    public void Set(HistoryValues history)
    {
        this._tsText.text = history.ts;
        this._addressText.text = history.address;
        this._valueText.text = history.value;
    }

    /// <summary>
    /// get values
    /// </summary>
    /// <returns></returns>
    public HistoryValues Get() {
        return new HistoryValues(
            this._tsText.text,
            this._addressText.text,
            this._valueText.text
        );
    }

}
