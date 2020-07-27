using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void OnGoalEnter()
    {
        SceneManager.LoadScene("GameWin", LoadSceneMode.Additive);
    }
}