using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>シーン切り替えを行う</summary>
public class SceneChange : MonoBehaviour
{
    public enum SCENE
    {
        START,GAME,GAME_OVER,GAME_CLEAR
    }

    /// <summary>シーン切り替えを行う
    /// </summary>
    /// <param name="scene"切り替えたいシーン></param>
    public void SceneChangeSystem(SCENE scene)
    {
        string changeName = null;
        var nowSceneName = SceneManager.GetActiveScene().name;
        switch (scene)
        {
            case SCENE.START:
                changeName = "Start";
                break;
            case SCENE.GAME:
                changeName = "Game";
                break;
            case SCENE.GAME_OVER:
                changeName = "GameOver";
                break;
            case SCENE.GAME_CLEAR:
                changeName = "GameClear";
                break;
        }
        SceneManager.LoadScene(changeName);
    }
}
