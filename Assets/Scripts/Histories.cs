using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct HistoryValues
{
  public string ts;
  public string address;
  public string value;
  public HistoryValues(string _ts, string _address, string _value)
  {
    this.ts = _ts;
    this.address = _address;
    this.value = _value;
  }
}

public class Histories : MonoBehaviour
{

  [SerializeField] private History[] _histories;

  /// <summary>
  /// set newest value
  /// </summary>
  /// <param name="ts"></param>
  /// <param name="address"></param>
  /// <param name="value"></param>
  public void Set(string ts, string address, string value)
  {
    HistoryValues lastHistoryValues = new HistoryValues(ts, address, value);
    foreach(History history in this._histories)
    {
      HistoryValues thisHistoryValues = history.Get();
      history.Set(lastHistoryValues);
      lastHistoryValues = thisHistoryValues;
    }
  }

}
