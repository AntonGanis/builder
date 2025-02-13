using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBlock : MonoBehaviour
{
    Transform closestHouseBlockTransform;
    bool off;
    public GameObject beton;
    public GameObject door;
    public GameObject window;

    void Start()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("дверь");

        if (doors.Length > 1)
        {
            window.SetActive(true);
            door.SetActive(false);
        }
    }

    void Update()
    {
        if (off == false)
        {
            HouseBlock[] houseBlocks = FindObjectsOfType<HouseBlock>();
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

    private void FindClosestHouseBlock(HouseBlock[] houseBlocks)
    {
        Transform closestHouseBlock = null;
        float closestDistance = Mathf.Infinity;

        foreach (HouseBlock houseBlock in houseBlocks)
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
        if (col.gameObject.GetComponent<HouseBlock>())
        {
            off = true;
            if (gameObject.transform.position.y >= 2f)
            {
                beton.SetActive(false);
            }
            gameObject.GetComponent<HouseBlock>().enabled = false;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<HouseBlock>())
        {
            if (gameObject.transform.position.y < 2f)
            {
                beton.SetActive(true);
            }
            off = true;
            gameObject.GetComponent<HouseBlock>().enabled = false;
        }
    }
}
