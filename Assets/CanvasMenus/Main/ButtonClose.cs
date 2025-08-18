using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClose : MonoBehaviour
{
    public Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(HandleClick);
    }


    void HandleClick()
    {
        Application.Quit();
    }
}
