using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGizmo : MonoBehaviour {
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
