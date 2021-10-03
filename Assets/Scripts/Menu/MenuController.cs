using UnityEngine;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        public string menuName;

        [Tooltip("An array of other menus that should be activated")]
        public string[] requiredMenus;

        private void Awake()
        {
            MenuManager.Singleton?.AddMenu(this);
        }

        public void ChangeMenu(string menuName)
        {
            MenuManager.Singleton?.ChangeMenu(menuName);
        }
    }
}