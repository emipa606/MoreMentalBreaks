using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace MoreMentalBreaks;

public class MentalState_SelfHarm : MentalState
{
    public override void PostStart(string reason)
    {
        base.PostStart(reason);
        foreach (var notMissingPart in pawn.health.hediffSet.GetNotMissingParts())
        {
            if (notMissingPart.def != BodyPartDefOf.Hand)
            {
                continue;
            }

            var num = Mathf.RoundToInt(pawn.health.hediffSet.GetPartHealth(notMissingPart) *
                                       Rand.Range(0.2f, 0.35f));
            var dinfo = new DamageInfo(DamageDefOf.Cut, num, 0f, -1f, pawn, notMissingPart);
            pawn.TakeDamage(dinfo);
        }
    }

    public override RandomSocialMode SocialModeMax()
    {
        return RandomSocialMode.Off;
    }
}