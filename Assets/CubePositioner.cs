using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubePositioner : MonoBehaviour
{
    [SerializeField] string cubeName = "GameBoard";
    Transform cube;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find(cubeName).transform;
        text = cube.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        cube.position = transform.position;
        cube.localScale = transform.localScale;
        text.text = transform.position.ToString();
    }
}
