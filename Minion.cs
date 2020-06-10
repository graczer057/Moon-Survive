using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{

    int hp = 15;
    float enemySpeed = 50f;

    List<GameObject> roadPath = new List<GameObject>();
    int currentPathPoint = 0;

    public void SetPath(List<GameObject> tempPath)
    {
        roadPath = tempPath;
    }

    void Update()
    {
        if (roadPath.Count != 0)
        {
            DetectPosition();
            DetectRotation();
        }
    }

    void DetectPosition()
    {
        float step = enemySpeed * Time.deltaTime;
        //print(Vector3.Distance(transform.position, roadPath[currentPathPoint].transform.position));
        if (Vector3.Distance(transform.position, roadPath[currentPathPoint].transform.position) > 2.5f)
        {
            //Idz w kierunku
            transform.position = Vector3.MoveTowards(
                                            transform.position,
                                            roadPath[currentPathPoint].transform.position,
                                            step);
        }
        else
        {
            //Szukaj nowego punktuf
            if (currentPathPoint < roadPath.Count - 1)
            {
                currentPathPoint++;
            }
            else
            {
                //Odbieramy jakies punkty
                Destroy(gameObject);
            }
        }
    }

    void DetectRotation()
    {
        Vector3 targetPoint;
        Quaternion targetRotation = new Quaternion();
        float step = enemySpeed * Time.deltaTime;

        targetPoint = new Vector3(
            roadPath[currentPathPoint].transform.position.x,
            transform.position.y,
            roadPath[currentPathPoint].transform.position.z)
            - transform.position;

        targetRotation = Quaternion.LookRotation(-targetPoint);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            step);



    }

    public void AddDamage(int value)
    {
        hp -= value;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
