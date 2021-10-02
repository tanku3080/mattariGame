using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>HTTP通信でデータをロードするクラス</summary>
public class DataLoad
{
    private IEnumerator Get()
    {
        using var get = new UnityWebRequest("url");

        if (get.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("システムエラー");
        }
        else if (get.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("ステータスエラー");
        }
        else
        {
            Debug.Log(get.downloadHandler.text);
        }
        yield return 0;
    }
}
