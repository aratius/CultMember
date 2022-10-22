using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionController : MonoBehaviour
{

  [SerializeField] private Histories _histories;

  void Start()
  {
    OscReceiver.Instance.onSign.AddListener(this._onSign);
  }

  /// <summary>
  /// on sign
  /// </summary>
  /// <param name="address"></param>
  private void _onSign(string address)
  {
    // TODO: 音再生

    if(address == "/leftHandUp")
    {

    } else if (address == "/leftHandDown")
    {

    } else if (address == "/rightHandUp")
    {

    } else if (address == "/rightHandDown")
    {

    } else if (address == "/standUp")
    {

    } else if (address == "/standDown")
    {

    } else {
      Debug.LogWarning("undefined instruction");
      return;
    };

    this._histories.Set(DateTime.Now.ToString("HH:mm:ss"), address, "undefined");
  }

}