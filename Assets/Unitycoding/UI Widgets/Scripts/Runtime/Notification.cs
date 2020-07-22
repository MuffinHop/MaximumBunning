using UnityEngine;
using System.Collections;

namespace Unitycoding.UIWidgets
{
	public class Notification : UIContainer<NotificationOptions>
	{
		public bool fade = true;
        public string timeFormat = "HH:mm:ss";

        #if UNITY_EDITOR
        [UnityEditor.MenuItem ("Tools/Unitycoding/UI Widgets/Components/Message Container")]
		static void AddWidgetComponent ()
		{
			UnityEditor.Selection.activeGameObject.AddComponent<Notification> ();
		}

		[UnityEditor.MenuItem ("Tools/Unitycoding/UI Widgets/Components/Message Container", true)]
		static bool ValidateAddWidgetComponent ()
		{
			return UnityEditor.Selection.activeGameObject != null;
		}
#endif

        public virtual bool AddItem(NotificationOptions item, params string[] replacements) {
            NotificationOptions options = new NotificationOptions(item);
            for (int i = 0; i < replacements.Length; i++) {
                options.text = options.text.Replace("{"+i+"}", replacements[i]);
            }
            return base.AddItem(options);
        }

        public virtual bool AddItem(string text, params string[] replacements)
        {
            NotificationOptions options = new NotificationOptions();
            options.text = text;
            for (int i = 0; i < replacements.Length; i++)
            {
                options.text = options.text.Replace("{" + i + "}", replacements[i]);
            }
            return base.AddItem(options);
        }
    }
}