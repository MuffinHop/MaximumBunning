using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycoding
{
    public interface ISelectable
    {
        Vector3 position { get; }
        void OnSelect();
        void OnDeselect();
    }
}