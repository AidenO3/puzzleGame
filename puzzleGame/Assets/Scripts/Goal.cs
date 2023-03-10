using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Map.Insert((int)this.transform.position.x, (int)this.transform.position.y, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
