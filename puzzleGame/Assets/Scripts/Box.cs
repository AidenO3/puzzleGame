using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public int[] pos = { 0, 0 };
    public GameObject coveredSpace;
    public GameObject ground;
    // Start is called before the first frame update
    void Awake()
    {
        coveredSpace = Instantiate(ground) as GameObject;
        pos[0] = (int)this.transform.position.x;
        pos[1] = (int)this.transform.position.y;
        Map.Insert(pos, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getCoveredSpace()
    {
        return coveredSpace;
    }

    public void setCoveredSpace(GameObject obj)
    {
        coveredSpace = obj;
    }

    public void move(int[] pos)
    {
        this.transform.position = new Vector2(pos[0], pos[1]);
    }
}
