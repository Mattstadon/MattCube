using UnityEngine;

public class SpawnPrefabWithText : MonoBehaviour
{
    public GameObject mainPrefab; // The main prefab you want to spawn
    public GameObject textPrefab; // The text element prefab
    public Vector3 textOffset = new Vector3(0, 1, 0); // Offset for the text position relative to the main prefab

    public void SpawnPrefabAndText()
    {
        // Instantiate the main prefab
        GameObject mainInstance = Instantiate(mainPrefab);

        // Instantiate the text element prefab
        GameObject textInstance = Instantiate(textPrefab, mainInstance.transform.position + textOffset, Quaternion.identity);

        // Optionally, set the parent of the text instance to the main instance
        // This is useful if you want the text to follow the main prefab
        textInstance.transform.SetParent(mainInstance.transform);
    }
}
