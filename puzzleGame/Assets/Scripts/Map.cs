using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    static public GameObject[,] map;
    public int camWidth = 24;
    public int camHeight = 12;
    public GameObject room;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        map = new GameObject[camWidth, camHeight];
        for (int i = 0; i < camWidth; i++)
        {
            for (int j = 0; j < camHeight; j++)
                map[i, j] = Instantiate(ground) as GameObject;
        }
        room = Instantiate<GameObject>(room);
    }

    // Update is called once per frame
    void Update()
    {

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
        GameObject box = Get(pos1);
        GameObject temp = Get(pos2);
        Box boxScript = (Box)box.GetComponent(typeof(Box));
        Insert(pos2, box);
        Insert(pos1, (GameObject)boxScript.getCoveredSpace());
        boxScript.setCoveredSpace(temp);
        boxScript.move(pos2);
    }
}