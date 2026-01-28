using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource btnSFX;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject fadeIn;
    [SerializeField] GameObject optionsPanel;

    void Start()
    {
        fadeIn.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void StartGame()
    {
        btnSFX.Play();
        fadeOut.SetActive(true);
        StartCoroutine(ChangeScene());
    }

    public void OpenOptions()
    {
        btnSFX.Play();
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        btnSFX.Play();
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        btnSFX.Play();
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
