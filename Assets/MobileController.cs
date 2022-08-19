using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{

    GameObject g;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        /*
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x < Screen.width / 2f)
            {
                transform.Translate(Vector3.forward * 5f * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * -5f * Time.deltaTime);

            }
            Debug.Log("se tocó pantalla");
        }
        */
        if((Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            Physics.Raycast(rayo, out hit);

            if (hit.collider != null)
            {

                Color C = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                hit.collider.GetComponent<MeshRenderer>().material.color = C;

                g = hit.collider.gameObject;

            }
        }

        if ((Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            g = null;

        }

        if (g != null && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            Ray rayo = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            Physics.Raycast(rayo, out hit, layer);

            if (hit.collider != null)
            {
                Vector3 P = hit.point;
                P.z = g.transform.position.z;
                g.transform.position = P;
            }

        }

    }
}
