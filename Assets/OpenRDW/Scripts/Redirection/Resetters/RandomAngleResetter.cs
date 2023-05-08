using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// This type of reset injects a 180 rotation. It will show a prompt to the user once at the full rotation is applied and the user is roughly looking at the original direction.
/// The method is simply doubling the rotation amount. No smoothing is applied. No specific rotation is enforced this way.
/// </summary>
public class RandomAngleResetter : Resetter {
    
    ///// <summary>
    ///// The user must return to her original orientation for the reset to let go. Up to this amount of error is allowed.
    ///// </summary>    
    float overallInjectedRotation;

    float requiredRotateAngle = 0;

    float gain;

    public override bool IsResetRequired()
    {
        return IfCollisionHappens();
    }
        
    public override void InitializeReset()
    {        
        //rotate by redirectionManager
        overallInjectedRotation = 0;
        
        //rotate by simulatedWalker
        requiredRotateAngle = Random.Range(140.0f, 220.0f);

        gain = 360.0f / requiredRotateAngle;

        //rotate clockwise by default
        SetHUD(1);
    }

    public override void InjectResetting()
    {        
        if (Mathf.Abs(overallInjectedRotation) < requiredRotateAngle)
        {
            float remainingRotation = redirectionManager.deltaDir > 0 ? requiredRotateAngle - overallInjectedRotation : -requiredRotateAngle - overallInjectedRotation; // The idea is that we're gonna keep going in this direction till we reach objective
            if (Mathf.Abs(remainingRotation) < Mathf.Abs(redirectionManager.deltaDir) || requiredRotateAngle==0)
            {
                InjectRotation(remainingRotation);
                redirectionManager.OnResetEnd();
                overallInjectedRotation += remainingRotation;
            }
            else
            {
                InjectRotation(redirectionManager.deltaDir * (1 - gain));
                overallInjectedRotation += (redirectionManager.deltaDir * (1 - gain));
            }
        }
        redirectionManager.textBox.text = gain.ToString() + " " + requiredRotateAngle.ToString() + " " + overallInjectedRotation.ToString();
        //Debug.Log("requiredRotateAngle:" + requiredRotateAngle + "; overallInjectedRotation:" + overallInjectedRotation);
    }


    //end reset
    public override void EndReset()
    {

        DestroyHUD();
    }    
    public override void SimulatedWalkerUpdate()
    {
        // Act is if there's some dummy target a meter away from you requiring you to rotate        
        var rotateAngle = redirectionManager.GetDeltaTime() * redirectionManager.globalConfiguration.rotationSpeed;

        //finish rotating
        if (rotateAngle >= requiredRotateAngle)
        {
            rotateAngle = requiredRotateAngle;            
            requiredRotateAngle = 0;
        }
        else {
            requiredRotateAngle -= rotateAngle;
        }        
        redirectionManager.simulatedWalker.RotateInPlace(rotateAngle);    
    }

}
