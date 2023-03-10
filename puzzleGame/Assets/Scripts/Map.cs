using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    static private Map M;
    public Player P;

    public int levelMax = 2;
    public int level = 1;
    static public GameObject[,] map;
    public GameObject[] levels;
    public GameObject currentLevel;

    public GameObject ground;
    public GameObject player;
    static public int[] boxStorage = {22, 10};
    public int camWidth = 24;
    public int camHeight = 12;

    void Start()
    {
        M = this;
        map = new GameObject[camWidth, camHeight];
        level = 0;
        loadLevel(level);
    }

    static public void Insert(int[] pos, GameObject obj)
    {
        map[pos[0], pos[1]] = obj;
    }

    static public void Insert(int x, int y, GameObject obj)
    {
        map[x, y] = obj;
    }

    static public GameObject Get(int[] pos)
    {
        return map[pos[0], pos[1]];
    }

    static public GameObject Get(int x, int y)
    {
        return map[x, y];
    }

    static public void moveBox(int[] pos1, int[] pos2)
    {
        if (Get(pos1).tag == "Box" && Get(pos2).tag != "Wall" && Get(pos2).tag != "Box")
        {
            GameObject box = Get(pos1);
            GameObject temp = Get(pos2);
            Box boxScript = (Box)box.GetComponent(typeof(Box));
            Insert(pos2, box);
            Insert(pos1, (GameObject)boxScript.getCoveredSpace());
            boxScript.setCoveredSpace(temp);
            boxScript.move(pos2);
        }
    }

    static public void getGoal(int[] pos)
    {
        if(M.level < M.levelMax - 1)
        {
            M.level++;
            M.loadLevel(M.level);
        }
        else
        {
            SceneManager.LoadScene("End");
        }

    }

    public void loadLevel(int  x)
    {

        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        for (int i = 0; i < camWidth; i++)
        {
            for (int j = 0; j < camHeight; j++)
                map[i, j] = Instantiate(ground) as GameObject;
        }
        currentLevel = Instantiate<GameObject>(levels[x]);
        currentLevel.transform.position = Vector2.zero;

        P = (Player)currentLevel.GetComponent(typeof(Player));


    }

    public void Restart()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        for (int i = 0; i < camWidth; i++)
        {
            for (int j = 0; j < camHeight; j++)
                map[i, j] = Instantiate(ground) as GameObject;
        }
        currentLevel = Instantiate<GameObject>(levels[level]);
        currentLevel.transform.position = Vector2.zero;

        P = (Player)currentLevel.GetComponent(typeof(Player));

    }

}