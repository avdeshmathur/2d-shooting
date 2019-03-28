using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }    
    }

    public void startGame()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
      anim.SetTrigger("end");
      yield return new WaitForSeconds(1.2f);
      SceneManager.LoadScene("Level1");
    }
}
