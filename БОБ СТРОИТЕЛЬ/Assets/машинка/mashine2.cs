using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashine2 : MonoBehaviour
{
    public GameObject Move;
    public bool ws;

    public Transform point;
    public float dist;
    public float predel;

    public GameObject element;
    public Transform spawn;
    void Update()
    {
        Vector3 currentLocalPosition = transform.position;
        currentLocalPosition.y = 0.78f;
        transform.position = currentLocalPosition;

        dist = Vector3.Distance(point.position, transform.position);
        if (dist > predel)
        {
            GameObject Point2 = Instantiate(element) as GameObject;
            Point2.transform.parent = spawn.transform.parent.gameObject.transform;

            Point2.transform.localPosition = spawn.localPosition;

            Vector3 ss = spawn.localPosition;
            ss.x += 0.01537f;
            spawn.localPosition = ss;

            predel += 0.44f;
        }

        if (ws == false)
        {
            if (Move.GetComponent<RandomMovement>().dirX == 1)
            {
                gameObject.GetComponent<Animator>().SetInteger("ata", 1);
            }
            else if (Move.GetComponent<RandomMovement>().dirX == -1)
            {
                gameObject.GetComponent<Animator>().SetInteger("ata", -1);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetInteger("ata", 0);
            }
        }
        else
        {
            if (Move.GetComponent<RandomMovement>().dirZ == 1)
            {
                gameObject.GetComponent<Animator>().SetInteger("ata", 1);
            }
            else if (Move.GetComponent<RandomMovement>().dirZ == -1)
            {
                gameObject.GetComponent<Animator>().SetInteger("ata", -1);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetInteger("ata", 0);
            }
        }
    }
}
