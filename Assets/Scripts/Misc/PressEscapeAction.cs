
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PressEscapeAction : MonoBehaviour
{

    [SerializeField] UnityEvent onEscapePressedEvent;
    [SerializeField] string mainMenuSceneName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onEscapePressedEvent.Invoke();
        }
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}