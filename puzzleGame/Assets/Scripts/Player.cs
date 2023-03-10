using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    int[] pos = { 0, 0 };
    bool freeToMove;
    bool pushBox;
    bool stomachFull;
    int[] stomachLocation;
    int[] lookingDir = new int[2];
    // Start is called before the first frame update
    void Awake()
    {
        stomachLocation = Map.boxStorage;
        freeToMove = false;
        pos[0] = (int)this.transform.position.x;
        pos[1] = (int)this.transform.position.y;
        lookingDir[0] = pos[0] + 1;
        lookingDir[1] = pos[1];
    }

    void Update()
    {
        //move with arrow keys
        int[] newPos = { pos[0], pos[1] };
        if (Input.GetKeyDown("up"))
        {
            newPos[1]++;
            lookingDir[0] = pos[0];
            lookingDir[1] = pos[1] + 1;
        }
        if (Input.GetKeyDown("down"))
        {
            newPos[1]--;
            lookingDir[0] = pos[0];
            lookingDir[1] = pos[1] - 1;
        }
        if (Input.GetKeyDown("right") && newPos[1] == pos[1])
        {
            newPos[0]++;
            lookingDir[0] = pos[0] + 1;
            lookingDir[1] = pos[1];
        }
        if (Input.GetKeyDown("left") && newPos[1] == pos[1])
        {
            newPos[0]--;
            lookingDir[0] = pos[0] - 1;
            lookingDir[1] = pos[1];
        }

        //check for walls or boxes
        if (pos[0] != newPos[0] || pos[1] != newPos[1])
        {
            freeToMove = false;
            pushBox = false;
            int[] nextSpace = { 2 * newPos[0] - pos[0], 2 * newPos[1] - pos[1] };
            switch (Map.Get(newPos).tag)
            {
                default:
                    freeToMove = true;
                    break;

                case "Goal":
                    freeToMove = true;
                    Map.getGoal(newPos);
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
                {
                    Map.moveBox(newPos, nextSpace);
                }
                lookingDir[0] += newPos[0] - pos[0];
                lookingDir[1] += newPos[1] - pos[1];
                pos[0] = newPos[0];
                pos[1] = newPos[1];

                this.transform.position = new Vector2(pos[0], pos[1]);
             
            }

            Debug.Log(newPos[0] + " , " + newPos[1]);
        }

        //eat box

        if (Input.GetKeyDown("space"))
        {
            if (!stomachFull)
            {
                Map.moveBox(lookingDir, stomachLocation);
                stomachFull = true;
            }
            else
            {
                Map.moveBox(stomachLocation, lookingDir);
                stomachFull = false;
            }
        }
    }

    public void resetPlayer(int[] x)
    {
        stomachFull = false;
        pos[0] = x[0];
        pos[1] = x[1];

        lookingDir[0] = pos[0] + 1;
        lookingDir[1] = pos[1];

        this.transform.position = new Vector2(pos[0], pos[1]);
    }
}
