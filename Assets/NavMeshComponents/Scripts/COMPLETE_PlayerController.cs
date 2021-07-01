using UnityEngine;
using UnityEngine.AI;

public class COMPLETE_PlayerController : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField]private NavMeshAgent agent;

    Vector3 mousePos;
    public Rigidbody rb;

    public GameObject bulletSpawn;
    public float rateOfFire;
    public GameObject bullet;

    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ra = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ra, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
     
    }

    void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }

}