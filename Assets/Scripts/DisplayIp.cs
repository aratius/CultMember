using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DisplayIp : MonoBehaviour
{
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
            if(Regex.IsMatch(addressStr, "[0-2]{0,1}[0-9]{1,2}.[0-2]{0,1}[0-9]{1,2}.[0-2]{0,1}[0-9]{1,2}.[0-2]{0,1}[0-9]{1,2}"))
            {
                Debug.Log($"ip = {addressStr}");
                ip = addressStr;
            }
        }
        this.GetComponent<Text>().text = ip;
    }

}
