using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OscJack;
using Cysharp.Threading.Tasks;

public class OscReceiver : SingletonMonoBehaviour<OscReceiver>
{

    public UnityEvent<string> onSign = new UnityEvent<string>();
    [SerializeField] private int _defaultPort;
    private List<string> _history = new List<string>();

    private OscServer _server;

    void Start()
    {
        this.Set(this._defaultPort);
    }

    /// <summary>
    /// set
    /// </summary>
    /// <param name="port"></param>
    public void Set(int port)
    {
        if(this._server != null) this._server.Dispose();

        this._server = new OscServer(port);
        this._server.MessageDispatcher.AddCallback(
            "",
            this._OnReceiveSign
        );
        Debug.Log($"Start listening, port : {port}");
    }

    /// <summary>
    /// On receive osc
    /// </summary>
    /// <param name="address"></param>
    /// <param name="data"></param>
    private async void _OnReceiveSign(string address, OscDataHandle data)
    {
        await UniTask.WaitForFixedUpdate();
        if(!this._history.Contains(address))
        {
            Debug.Log("add");
            this.onSign.Invoke(address);
            this._history.Add(address);
            this._AvoidSameTimer(address);
        }
    }

    private async void _AvoidSameTimer(string address)
    {
        await UniTask.Delay(100);
        this._history.Remove(address);
    }

}
