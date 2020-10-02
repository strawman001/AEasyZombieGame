using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    public GameObject player;
    public int brains;

    public void KillPlayer()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
