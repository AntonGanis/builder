using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomWindows : MonoBehaviour
{
    int rer;
    public List<GameObject> blocks;

    void Start()
    {
        rer = Random.Range(0, blocks.Count);
        blocks[rer].SetActive(true);
    }
}
