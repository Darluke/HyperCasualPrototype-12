using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool shouldRotate;

    void Update()
    {
        if(shouldRotate)transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }

    public void SetRotation()
    {
        StartCoroutine("SetRotaionDelay");
    }

    IEnumerator SetRotaionDelay()
    {
        yield return new WaitForSeconds(1.5f);
        shouldRotate = true;
    }
}
