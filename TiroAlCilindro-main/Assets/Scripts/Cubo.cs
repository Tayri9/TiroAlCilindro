using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    bool isBig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Cubo"))
                {
                    Rigidbody rigidbodyCubo = hitInfo.collider.GetComponent<Rigidbody>();
                    
                    Vector3 escala = rigidbodyCubo.gameObject.transform.localScale;
                    if (escala.x == 1)
                    {
                        isBig = false;

                    } else
                    {
                        isBig = true;
                    }

                    if (!isBig)
                    {
                        LeanTween.scale(rigidbodyCubo.gameObject, Vector3.one * 4f, 0.5f).setEaseInBounce();
                        isBig = true;
                    } else if (isBig)
                    {
                        LeanTween.scale(rigidbodyCubo.gameObject, Vector3.one, 0.5f).setEaseInBounce();
                        isBig = false;
                    }           
                     
                }
            }

        }
    }
}
