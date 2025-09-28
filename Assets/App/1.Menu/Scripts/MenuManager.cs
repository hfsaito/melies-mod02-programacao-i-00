namespace Assets.App.N1_Menu.Scripts
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public enum MENU
    {
        MAIN,
        CONFIG
    }

    public static class MenuManager
    {
        private static readonly Dictionary<MENU, GameObject> menuStore = new();
        private static GameObject activeMenu;

        public static void RegisterMenu(MENU id, GameObject gameObject, bool defaultActive)
        {
            if (defaultActive && activeMenu != null)
            {
                throw new ArgumentException("There is already a default active menu");
            }

            if (menuStore.ContainsKey(id))
            {
                throw new ArgumentException("Menu id already used");
            }

            menuStore.Add(id, gameObject);
            gameObject.SetActive(defaultActive);
            if (defaultActive)
            {
                activeMenu = gameObject;
            }
        }

        public static void OpenMenu(MENU menu)
        {
            activeMenu.SetActive(false);
            menuStore[menu].SetActive(true);
            activeMenu = menuStore[menu];
        }
    }
}
