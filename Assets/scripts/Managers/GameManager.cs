using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ゲームシーンで使用するメソッドや値を管理するクラス</summary>
public class GameManager : MonoBehaviour
{
    /// <summary>ゲームの経過時間を格納する</summary>
    public static float gameTime;

    /// <summary>イベントが発生したらtrue</summary>
    public bool eventFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
    }

    /// <summary>呼び出した側が引数に設定したオブジェクトの位置を返す</summary>
    /// <param name="target"></param>
    public float CharaDistance(GameObject target)
    {
        return (gameObject.transform.position - target.transform.position).sqrMagnitude;
    }
}
