using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTarget : MonoBehaviour
{
    public bool hasSent;
    public void HasFinishedAnimation()
    {
        this.hasSent = true;
        GetComponentInParent<SceneController>().DetectFinishedAnimation();
    }
}
