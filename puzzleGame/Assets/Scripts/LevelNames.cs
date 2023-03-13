using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelNames : MonoBehaviour
{
    public string[] levelNames;
    public int level;
    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        uiText = GetComponent<Text>();
        uiText.text = (levelNames[level]);
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = (levelNames[level]);
    }
}
