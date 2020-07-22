using UnityEngine;
using System.Collections;

namespace Unitycoding{
	public interface ICollectionEditor {
        string ToolbarName { get; }
		void OnGUI(Rect position);
        void OnDestroy();
	}
}