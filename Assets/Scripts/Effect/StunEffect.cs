using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StunEffect", menuName = "Stun Effect")]
public class StunEffect : EffectLogic
{
    public float stunTime;

    public override void onApplyEffect(float amount)
    {
        base.onApplyEffect(amount);
    }

    public override void onRemoveEffect(float amount)
    {
        base.onRemoveEffect(amount);
    }
}
