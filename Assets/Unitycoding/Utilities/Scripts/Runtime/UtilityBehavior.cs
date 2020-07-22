using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycoding
{
    public class UtilityBehavior : MonoBehaviour
    {
        public void QuitApplication() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}