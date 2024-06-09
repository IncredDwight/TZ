using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColliderSorter
{
    public static Collider[] GetSortedCollidersByDistance(Collider[] colliders, Vector3 position)
    {
        return colliders
            .OrderBy(collider => Vector3.Distance(collider.transform.position, position))
            .ToArray();
    }
}
