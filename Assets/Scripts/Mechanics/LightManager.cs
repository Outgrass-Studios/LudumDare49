using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public static class LightManager
    {
        public static List<LightSwitchController> switches = new List<LightSwitchController>();
        public static List<int> enabledSwitches = new List<int>();

        public static int AddSwitch(LightSwitchController lightSwitch)
        {
            switches.Add(lightSwitch);
            return switches.Count - 1;
        }

        public static void DisableRandom()
        {
            if (enabledSwitches.Count == 0) return;
            int index = enabledSwitches[Random.Range(0, enabledSwitches.Count)];

            switches[index].DisableSwitch();
        }
    }
}