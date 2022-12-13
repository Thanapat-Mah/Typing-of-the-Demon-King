using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator animator;
    public AudioSource clickSound;

    private string sceneName;

    public void OnClick_MoveToScene(string scene)
    {
        clickSound.Play();
        sceneName = scene;
        animator.SetTrigger("FadeOut");
    }

    public void TransitionComplete()
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void OnClick_StartGame()
    {
        StatManager.Instance.StartCalculateStatistic();
    }
}