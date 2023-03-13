using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelCounter : MonoBehaviour
{
    public int level = 0;
    private Text uiText;
    public string[] levelNames;

    private void Start()
    {
        level = 0;
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = ("Level " + (level + 1) + ": " + levelNames[level]);
    }
}
