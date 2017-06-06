using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

    //to see enemy positions on scene view
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.0f);
    }
}
