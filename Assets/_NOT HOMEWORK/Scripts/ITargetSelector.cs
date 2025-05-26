using System.Collections.Generic;
using UnityEngine;

public interface ITargetSelector
{
    Transform SelectFrom(List<Transform> targets);
}
