using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Material hitMaterial;
    public AudioClip shotSound;
    public AudioClip disparoLata;
    private AudioSource gunAudioSource;
    public int puntos = 0;

    [SerializeField]
    TextMeshProUGUI textoPuntuacion;

    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            //gunAudioSource.PlayOneShot(shotSound);
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            { 
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Lata"))
                {
                    gunAudioSource.PlayOneShot(disparoLata);
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody>();
                    rigidbodyLata.AddForce(rayo.direction * 50f, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    puntos += 10;
                }
                else
                {
                    gunAudioSource.PlayOneShot(shotSound);
                    puntos -= 5;
                }
            }
            else
            {
                gunAudioSource.PlayOneShot(shotSound);
                puntos -= 5;
            }
            textoPuntuacion.text = puntos.ToString();

        }
    }
}
