using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Latas : MonoBehaviour
{
    [SerializeField]
    public GameObject lata;    

    [SerializeField]
    public float timeMin, timeMax;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("CreateTarget", timeMin, Random.Range(timeMin, timeMax));
    }

    // Update is called once per frame
    void Update()
    {
        //timer              
        Debug.Log(time);
        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            DropLata();
        }
        
    }

    void CreateTarget()
    {
        Instantiate(lata, gameObject.transform.position, Quaternion.identity);
    }

    void DropLata()
    {
        Instantiate(lata, transform.position, transform.rotation);
    }
}
