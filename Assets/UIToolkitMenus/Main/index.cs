using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class index : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button startButton;
    private Button configButton;
    private Button creditsButton;
    private Button exitButton;

    private void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();

        startButton = uiDocument.rootVisualElement.Q<Button>("startButton");
        configButton = uiDocument.rootVisualElement.Q<Button>("configButton");
        creditsButton = uiDocument.rootVisualElement.Q<Button>("creditsButton");
        exitButton = uiDocument.rootVisualElement.Q<Button>("exitButton");
        // _inputFields.RegisterCallback<ChangeEvent<string>>(InputMessage);

        startButton.clicked += StartClicked;
        exitButton.clicked += ExitClicked;
    }

    private void StartClicked()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }

    private void ExitClicked()
    {
        Application.Quit();
    }
}
