using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace BreadandButter.VR
{
    [RequireComponent(typeof(SteamVR_Behaviour_Pose))]
    [RequireComponent(typeof(VRControllerInput))]
    [RequireComponent(typeof(Rigidbody))]
    public class VRController : MonoBehaviour
    {
        public Rigidbody Rigidbody => rigidbody;
        public VRControllerInput Input => input;
        public Vector3 Velocity => pose.GetVelocity();
        public Vector3 AngularVelocity => pose.GetAngularVelocity();

        public SteamVR_Input_Sources InputSource => pose.inputSource;

        private SteamVR_Behaviour_Pose pose;
        private VRControllerInput input;
        private new Rigidbody rigidbody;

        public void Initialised()
        {
            pose = gameObject.GetComponent<SteamVR_Behaviour_Pose>();
            input = gameObject.GetComponent<VRControllerInput>();
            rigidbody = gameObject.GetComponent<Rigidbody>();

            input.Initialise(this);
        }
    }
}
