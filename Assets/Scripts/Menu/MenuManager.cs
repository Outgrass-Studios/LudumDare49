using System.Collections.Generic;
using UnityEngine;
using qASIC;
using System;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        public string defaultMenu = "main";
        public List<MenuController> menus = new List<MenuController>();

        public static MenuManager Singleton { get; private set; }

        private void Awake()
        {
            if(Singleton != null)
            {
                qDebug.LogWarning("There are multiple menu managers in the scene");
                Destroy(gameObject);
                return;
            }
            Singleton = this;
        }

        private void Start() =>
            ChangeMenu(defaultMenu);

        public void AddMenu(MenuController menu) =>
            menus.Add(menu);

        public void ChangeMenu(string menuName)
        {
            int? menuIndex = null;
            for (int i = 0; i < menus.Count; i++)
            {
                menus[i].gameObject.SetActive(false);
                if (menus[i].menuName != menuName) continue;
                menuIndex = i;
            }

            if (menuIndex == null)
            {
                qDebug.LogError($"Menu {menuName} does not exist!");
                return;
            }

            MenuController menu = menus[(int)menuIndex];
            menu.gameObject.SetActive(true);

            for (int i = 0; i < menus.Count; i++)
            {
                if (Array.IndexOf(menu.requiredMenus, menus[i].menuName) == -1) continue;
                menus[i].gameObject.SetActive(true);
            }
        }
    }
}