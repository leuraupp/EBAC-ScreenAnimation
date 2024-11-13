using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core;
using Ebac.Core.Singleton;

namespace Screens {
    public class ScreenManager : Singleton<ScreenManager> {
        public List<ScreenBase> screens;
        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase currentScreen;

        private void Start() {
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType screenType) {
            if (currentScreen != null) {
                currentScreen.Hide();
            }

            ScreenBase nextScreen = screens.Find(s => s.screenType == screenType);
            if (nextScreen != null) {
                nextScreen.Show();
            }
            currentScreen = nextScreen;
        }

        public void HideAll() {
            screens.ForEach(s => s.Hide());
        }

    }
}

