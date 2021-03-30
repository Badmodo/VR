using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace BreadandButter.VR
{
    [RequireComponent(typeof(SteamVR_Behaviour_Pose))]
    [RequireComponent(typeof(VRControllerInput))]
    public class VRController : MonoBehaviour
    {
        public VRControllerInput Input => input;
        public Vector3 Velocity => pose.GetVelocity();
        public Vector3 AngularVelocity => pose.GetAngularVelocity();

        public SteamVR_Input_Sources InputSource => pose.inputSource;

        private SteamVR_Behaviour_Pose pose;
        private VRControllerInput input;

        public void Initialised()
        {
            pose = gameObject.GetComponent<SteamVR_Behaviour_Pose>();
            input = gameObject.GetComponent<VRControllerInput>();

            input.Initialise(this);
        }
    }
}
