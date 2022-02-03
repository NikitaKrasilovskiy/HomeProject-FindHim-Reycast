using UnityEngine;
using UnityEngine.AI;

public class EnemyReycast : MonoBehaviour
{
    [SerializeField] private float Distance = 8f;
    [SerializeField] private float radius = 3f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask Wall;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject finish;
    [SerializeField] private Material redMaterial;
    private NavMeshAgent agent;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject glaz;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = finish.transform.position;
    }    
    void Update()
    {
        Ray rray = new Ray(transform.position, Vector3.right);
        Ray lray = new Ray(transform.position, Vector3.left);
        RaycastHit hit;

        if (Physics.Raycast(rray, out hit, 1, Wall))
        {
            agent.destination = start.transform.position;
        }
        if (Physics.Raycast(lray, out hit, 1, Wall))
        {
            agent.destination = finish.transform.position;
        }

        Ray ray = new Ray(glaz.transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.red);
        if (Physics.Raycast(ray, out hit, Distance, layerMask))
        {
            Debug.Log("you were found");
            hit.transform.gameObject.GetComponent<Renderer>().material = redMaterial;
            agent.destination = player.transform.position;
        }
        if (Physics.SphereCast(ray, radius, 3, layerMask))
        {
            Debug.Log("you were found");
            player.gameObject.GetComponent<Renderer>().material = redMaterial;
            agent.destination = player.transform.position;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(glaz.transform.position.x, glaz.transform.position.y, glaz.transform.position.z), 3);
    }
}
