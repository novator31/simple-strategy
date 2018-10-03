using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    public GameObject getPlane;
    public float scaleSpeed;
    private Transform curentGetPlane;

    public List<NavMeshAgent> AIs;

    public bool choosing;

    Ray ray;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        AIs = new List<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = new RaycastHit();
        setGetPlane();
        
        if (Input.GetMouseButton(0))
        {
            if(curentGetPlane != null)
            {
                curentGetPlane.localScale += new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y") * -1) * scaleSpeed;
            }
        }

        if (AIs.Count > 0)
        {
            foreach (NavMeshAgent AI in AIs)
            {
                if (!choosing)
                {
                    AI.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    if (Input.GetMouseButtonUp(1))
                    {
                        if (Physics.Raycast(ray, out hit, 1000))
                        {
                            if (hit.transform.name == "Terrain")
                            {
                                if (AI.GetComponent<Infinitry>())
                                {
                                    AI.GetComponent<Infinitry>().Move(hit.point);
                                }
                            }
                        }
                    }
                }
            }
            choosing = true;
        }
    }

    void setGetPlane()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
            if (choosing)
            {
                UnSelect();
            }
               
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.transform.name == "Terrain")
                    {
                        curentGetPlane = Instantiate(getPlane, hit.point, Quaternion.identity).transform;
                        Transform Sizer = curentGetPlane.GetChild(0);
                        Sizer.parent = null;
                        curentGetPlane.parent = Sizer;
                        curentGetPlane = Sizer;
                    }
                }

            }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (curentGetPlane != null)
                Destroy(curentGetPlane.gameObject);
        }
        }
    void UnSelect()
    {
        foreach (NavMeshAgent AI in AIs)
        {
          
                AI.transform.GetChild(0).gameObject.SetActive(false);
           
            
        }
        AIs.Clear();
        choosing = false;
    }
}
