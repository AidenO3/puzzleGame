using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelCounter : MonoBehaviour
{
    public int level = 0;
    private Text uiText;

    private void Start()
    {
        level = 0;
        uiText = GetComponent<Text>();
        uiText.text = ("Level " + (0 + 1) + ":");
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = ("Level " + (level + 1) + ":");
    }
}
