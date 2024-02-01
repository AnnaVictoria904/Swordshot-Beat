using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class OverrideXRSim : XRDeviceSimulator
{
    private void Awake()
    {
        LeftDeviceDefaultInitialPosition = new Vector3(-0.407f, 0.08f, 0.507f);
        RightDeviceDefaultInitialPosition = new Vector3(0f, -0.05f, 0.3f);
        base.Awake();
    }
}
