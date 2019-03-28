using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManag : MonoBehaviour {

    public float maximumScore;

	void Update () {
		
        if (Score.score >= maximumScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
