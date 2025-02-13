using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HrushovkaBlock : MonoBehaviour
{
    Transform closestHouseBlockTransform;
    bool off;

    void Update()
    {
        if (off == false)
        {
            HrushovkaBlock[] houseBlocks = FindObjectsOfType<HrushovkaBlock>();
            if (houseBlocks.Length != 1)
            {
                FindClosestHouseBlock(houseBlocks);
                float dist = Vector3.Distance(closestHouseBlockTransform.position, transform.position);
                if (dist < 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, closestHouseBlockTransform.position, 4 * Time.deltaTime);
                }
            }
        }
    }

    private void FindClosestHouseBlock(HrushovkaBlock[] houseBlocks)
    {
        Transform closestHouseBlock = null;
        float closestDistance = Mathf.Infinity;

        foreach (HrushovkaBlock houseBlock in houseBlocks)
        {
            if (houseBlock != this) // Исключаем самого себя из списка
            {
                float distance = Vector3.Distance(transform.position, houseBlock.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestHouseBlockTransform = houseBlock.transform;
                }
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<HrushovkaBlock>())
        {
            off = true;
            gameObject.GetComponent<HrushovkaBlock>().enabled = false;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<HrushovkaBlock>())
        {
            off = true;
            gameObject.GetComponent<HrushovkaBlock>().enabled = false;
        }
    }
}