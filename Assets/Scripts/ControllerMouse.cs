using UnityEngine;
using UnityEngine.AI;

public class ControllerMouse : MonoBehaviour
{
    [SerializeField] private GameObject pointToMove;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                pointToMove.transform.position = hit.point;
                agent.destination = hit.point;
            }
        }
    }
}
