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
    Sound.LoadSe("standUp", "standUp");
    Sound.LoadSe("sitDown", "sitDown");
    Sound.LoadSe("handsUp", "handsUp");
    Sound.LoadSe("handsDown", "handsDown");
    Sound.LoadSe("tutorial", "tutorial");
    Sound.LoadSe("finish", "finish");
  }

  /// <summary>
  /// on sign
  /// </summary>
  /// <param name="address"></param>
  private void _onSign(string address)
  {
    // TODO: 音再生

    if(address == "/handsUp")
    {
      Sound.PlaySe("handsUp");
    } else if (address == "/handsDown")
    {
      Sound.PlaySe("handsDown");
    } else if (address == "/standUp")
    {
      Sound.PlaySe("standUp");
    } else if (address == "/sitDown")
    {
      Sound.PlaySe("sitDown");
    } else if(address == "/tutorial")
    {
      Sound.PlaySe("tutorial");
    } else if (address == "/finish")
    {
      Sound.PlaySe("finish");
    } else if(address == "/stop") {
      Sound.StopSe();
    } {
      Debug.LogWarning("undefined instruction");
      return;
    };

    this._histories.Set(DateTime.Now.ToString("HH:mm:ss"), address, "undefined");
  }

}
