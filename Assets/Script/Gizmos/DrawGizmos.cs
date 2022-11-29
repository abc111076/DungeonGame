using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        // Draws a blue line from this transform to the target
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.forward * 50.0f);
    }
}
