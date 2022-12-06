using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DisplayIp : MonoBehaviour
{
    List<string> _ips = new List<string>();
    int _crr = 0;

    void Start()
    {
        // ホスト名を取得する
        string hostname = Dns.GetHostName();
        Debug.Log($"hostname = {hostname}");

        // ホスト名からIPアドレスを取得する
        IPAddress[] adrList = Dns.GetHostAddresses(hostname);
        string ip = "";
        foreach (IPAddress address in adrList)
        {
            string addressStr = address.ToString();
            if(Regex.IsMatch(addressStr, @"\d{1,3}(\.\d{1,3}){3}(/\d{1,2})?"))
            {
                Debug.Log($"ip = {addressStr}");
                this._ips.Add(addressStr);
            }
        }
        if(this._ips.Count > 0) this._Show();
    }

    public void Next()
    {
        this._crr++;
        this._Show();
    }

    private void _Show()
    {
        this.GetComponent<Text>().text = this._ips[this._crr % this._ips.Count];
    }

}
