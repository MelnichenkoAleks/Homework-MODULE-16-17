using System.Collections.Generic;
using UnityEngine;

public class LowerTatgetSelector : ITargetSelector
{
    public Transform SelectFrom(List<Transform> targets)
    {
        Transform selectedTarget = targets[0];

        foreach (Transform target in targets)
            if (target.transform.position.y < selectedTarget.transform.position.y)
                selectedTarget = target;

        return selectedTarget;
    }
}
