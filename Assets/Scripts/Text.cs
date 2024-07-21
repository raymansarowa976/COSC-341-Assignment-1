using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Text : MonoBehaviour
    
{
    public string text = "Score: 0";
    public static int score = 0;
    public GameObject OurTextMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = "Score: " + Mathf.Round(score);
        OurTextMesh.GetComponent<TextMeshProUGUI>().text = text;
    }
}
