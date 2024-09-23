using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndPos;
    private Vector2 _charpos;
    private Vector2 _epos;
    private static bool _end;
    void Start()
    {
        _end = false;
    }

   
    void Update()
    {
        _charpos = this.Player.transform.position;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Tutorial")
        {
            if (_end == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("1-1");
                _end = false;
            }
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-1")
        {
            if (_end == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("1-2");
                _end = false;
            }
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-2")
        {
            if (_end == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("1-3");
                _end = false;
            }
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-3")
        {
            if (_end == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Boss");
                _end = false;
            }
        }
    }

    public void StageEnd()
    {
        _end = true;
    }
}
