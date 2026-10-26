using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace MoreMentalBreaks;

public class JobGiver_Compulsion : ThinkNode_JobGiver
{
    protected override Job TryGiveJob(Pawn pawn)
    {
        if (Rand.Range(0f, 1f) < 0.5f)
        {
            var filthInHomeArea = pawn.Map.listerFilthInHomeArea.FilthInHomeArea;
            var closestFilth = getClosestFilth(pawn, filthInHomeArea);
            if (canClean(pawn, closestFilth))
            {
                return new Job(JobDefOf.Clean, closestFilth);
            }
        }

        if (!(Rand.Range(0f, 1f) < 0.5f))
        {
            return null;
        }

        var thing = GenClosest.ClosestThing_Global_Reachable(pawn.Position, pawn.Map,
            pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling(), PathEndMode.OnCell,
            TraverseParms.For(pawn), 9999f, validator);
        return thing != null ? HaulAIUtility.HaulToStorageJob(pawn, thing, false) : null;

        bool validator(Thing t)
        {
            return !t.IsForbidden(pawn) && HaulAIUtility.PawnCanAutomaticallyHaulFast(pawn, t, true);
        }
    }

    private static Thing getClosestFilth(Pawn pawn, List<Thing> filth)
    {
        Thing result = null;
        var num = int.MaxValue;
        foreach (var item in filth)
        {
            var num2 = IntVec3Utility.ManhattanDistanceFlat(pawn.PositionHeld, item.PositionHeld);
            if (num2 >= num)
            {
                continue;
            }

            num = num2;
            result = item;
        }

        return result;
    }

    private static bool canClean(Pawn pawn, Thing t)
    {
        if (t is Filth filth && pawn.Map.areaManager.Home[filth.Position])
        {
            return pawn.CanReserveAndReach(t, PathEndMode.ClosestTouch, Danger.Deadly);
        }

        return false;
    }
}