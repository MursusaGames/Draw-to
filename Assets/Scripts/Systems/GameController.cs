using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private MatchData data;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(data.level);
    }
    
}
