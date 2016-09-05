using UnityEngine;
using System.Collections;

public class TouchMgr : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "BOX")
                {
                    Collider[] colls = Physics.OverlapSphere(hit.point, 10.0f, 1 << 8);
                    foreach (Collider coll in colls)
                    {
                        coll.GetComponent<Rigidbody>().AddExplosionForce(1200.0f, hit.point, 10.0f,1000.0f);
                    }
                }
            }
        }
	}
}
