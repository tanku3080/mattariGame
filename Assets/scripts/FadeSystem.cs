using System.Collections;
using UnityEngine;

/// <summary>フェード機能を非同期処理で実装している</summary>
public class FadeSystem : MonoBehaviour
{
    public enum FADE
    {
        FADE_IN, FADE_OUT
    }
    /// <summary>フェード処理が終わったかどうかを返す</summary>
    [HideInInspector] public bool FadeStop { get { return fadeStopFlag; } set { FadeStop = fadeStopFlag; } }
    private bool fadeStopFlag = false;


    /// <summary>フェードを行う
    /// </summary>
    /// <param name="status">どんなフェードを行いたいか</param>
    /// <param name="fadeSpeed">Fadeの速度</param>
    /// <param name="canvas">Fadeさせるオブジェクト</param>
    public void FadeStart(FADE status, float fadeSpeed = 0.02f, CanvasGroup canvas = null)
    {
        StartCoroutine(StartFadeSystem(status, fadeSpeed, canvas));
    }
    private IEnumerator StartFadeSystem(FADE _STATUS, float fadeSpeed = 0.02f, CanvasGroup obj = null)
    {
        //非同期処理で行う事で他の処理で不具合が発生した場合でも処理を実行する事が出来る。
        CanvasGroup group;
        if (obj != null)
        {
            group = obj.GetComponent<CanvasGroup>();
        }
        else
        {
            group = GetComponent<CanvasGroup>();
        }

        fadeStopFlag = false;
        switch (_STATUS)
        {
            case FADE.FADE_IN:
                while (true)
                {
                    yield return null;
                    if (group.alpha >= 1)
                    {
                        fadeStopFlag = true;
                        break;
                    }
                    else group.alpha += fadeSpeed;
                }
                break;
            case FADE.FADE_OUT:
                while (true)
                {
                    yield return null;
                    if (group.alpha <= 0)
                    {
                        fadeStopFlag = true;
                        break;
                    }
                    else group.alpha -= fadeSpeed;
                }
                break;
        }
        yield return 0;
    }
}
