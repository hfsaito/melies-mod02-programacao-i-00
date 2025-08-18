using UnityEngine;

public class Soldier : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material.color = Random.ColorHSV();
        }
    }
}
