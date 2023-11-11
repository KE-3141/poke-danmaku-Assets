using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneController : MonoBehaviour
{
    public string nextSceneName;
    public bool hasTriggered = false;
    public List<TransitionTarget> transitionTargets;
    public bool hasFinishedAnimation;

    public void Start()
    {
        this.transitionTargets = new List<TransitionTarget>(
            FindObjectsOfType<TransitionTarget>()
        );
    }

    protected virtual void Trigger()
    {
        this.hasTriggered = true;
    }

    protected virtual void StartTransition()
    {
    }

    protected virtual void CompleteTransition()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Invoked by TargetTransition
    public void DetectFinishedAnimation()
    {
        this.hasFinishedAnimation = true;
    }

    public void Update()
    {
        if (!this.hasTriggered)
        {
            this.Trigger();

            if (this.hasTriggered)
            {
                this.StartTransition();
            }
        }

        if (this.hasFinishedAnimation)
        {
            this.CompleteTransition();
        }
    }
}
