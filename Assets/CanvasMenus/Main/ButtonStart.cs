using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(HandleClick);
    }


    void HandleClick()
    {
        SceneManager.LoadScene("ScenePlay", LoadSceneMode.Single);
    }
}
