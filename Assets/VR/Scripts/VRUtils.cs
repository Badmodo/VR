using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace BreadandButter.VR
{
    public class VRUtils
    {
        private static List<XRInputSubsystem> subsystems = new List<XRInputSubsystem>();

        public static void SetVREnabled(bool _enabled)
        {
            SubsystemManager.GetInstances<XRInputSubsystem>(subsystems);

            foreach(XRInputSubsystem subsystem in subsystems)
            {
                if(_enabled)
                {
                    subsystem.Start();
                }
                else
                {
                    subsystem.Stop();
                }
            }
        }

        public static bool VREnabled()
        {
            SubsystemManager.GetInstances<XRInputSubsystem>(subsystems);

            foreach (XRInputSubsystem subsystem in subsystems)
            {
                if(subsystem.running)
                { 
                    return true; 
                }
            }

            return false;
        }
    }
}