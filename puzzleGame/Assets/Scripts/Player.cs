using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int[] pos = { 0, 0 };
    bool freeToMove;
    bool pushBox;
    // Start is called before the first frame update
    void Awake()
    {
        freeToMove = false;
        pos[0] = (int)this.transform.position.x;
        pos[1] = (int)this.transform.position.y;
    }

    void Update()
    {
        int[] newPos = { pos[0], pos[1] };

        //move with arrow keys
        if (Input.GetKeyDown("up"))
            newPos[1]++;
        if (Input.GetKeyDown("down"))
            newPos[1]--;
        if (Input.GetKeyDown("right") && newPos[1] == pos[1])
            newPos[0]++;
        if (Input.GetKeyDown("left") && newPos[1] == pos[1])
            newPos[0]--;

        //check for walls or boxes

        if (pos[0] != newPos[0] || pos[1] != newPos[1])
        {
            freeToMove = false;
            pushBox = false;
            int[] nextSpace = { 2 * newPos[0] - pos[0], 2 * newPos[1] - pos[1] };
            switch (Map.Get(newPos).tag)
            {
                case "Ground":
                case "PlayerBox":
                default:
                    freeToMove = true;
                    break;

                case "Wall":
                    freeToMove = false;
                    break;
                case "Box":
                    string x = Map.Get(nextSpace).tag;
                    if (x != "Wall" && x != "Box")
                    {
                        freeToMove = true;
                        pushBox = true;
                    }
                    break;


            }
            if (freeToMove)
            {
                if (pushBox)
                    Map.moveBox(newPos, nextSpace);
                pos[0] = newPos[0];
                pos[1] = newPos[1];
                this.transform.position = new Vector2(pos[0], pos[1]);
            }
        }


    }
}
