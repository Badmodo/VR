using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreadandButter.VR
{
    public class VRRig : MonoBehaviour
    {
        public static VRRig instance = null;

        public Transform LeftController => leftController;
        public Transform RightController => rightController;
        public Transform Headset => headset;
        public Transform PlayArea => playArea;

        [SerializeField]
        private Transform leftController;
        [SerializeField]
        private Transform rightController;
        [SerializeField]
        private Transform headset;
        [SerializeField]
        private Transform playArea;

        private VRController left;
        private VRController right;

        //this function is called when the script is loaded or a value is changed
        private void OnValidate()
        {
            //check if the set object isnt a VR Controller
            if(leftController != null && leftController.GetComponent<VRController>() == null)
            {
                leftController = null;
                Debug.LogWarning("the object you are trying to set as left controller does not have the VRController script");
            }
            if(rightController != null && rightController.GetComponent<VRController>() == null)
            {
                rightController = null;
                Debug.LogWarning("the object you are trying to set as right controller does not have the VRController script");
            }
        }

        //basic singleton
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else if(instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        void Start()
        {
            //validate all the transform comenants
            ValidateComponant(leftController);
            ValidateComponant(rightController);
            ValidateComponant(headset);
            ValidateComponant(playArea);

            //get the VR controller comements for the relavent controllers
            left = leftController.GetComponent<VRController>();
            right = rightController.GetComponent<VRController>();

            left.Initialised();
            right.Initialised();
        }

        void Update()
        {

        }

        private void ValidateComponant<T>(T _component) where T : Component
        {
            //if the component is null then log out the name of the component in an error
            if(_component == null)
            {
                Debug.LogError($"Component { nameof(_component)} is null! This has to be set.");
#if UNITY_EDITOR
                //the component was null and we are in the editor so stop the editor from playing
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}