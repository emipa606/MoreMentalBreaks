using RimWorld;
using Verse;
using Verse.AI;

namespace MoreMentalBreaks;

public class JobGiver_Apathy : JobGiver_Wander
{
    public JobGiver_Apathy()
    {
        wanderRadius = 10f;
        ticksBetweenWandersRange = new IntRange(100, 200);
        locomotionUrgency = LocomotionUrgency.Walk;
    }

    protected override IntVec3 GetWanderRoot(Pawn pawn)
    {
        return pawn.Position;
    }

    protected override Job TryGiveJob(Pawn pawn)
    {
        pawn.mindState.nextMoveOrderIsWait = !pawn.mindState.nextMoveOrderIsWait;
        if (pawn.mindState.nextMoveOrderIsWait)
        {
            return new Job(JobDefOf.Wait_Wander)
            {
                expiryInterval = ticksBetweenWandersRange.RandomInRange
            };
        }

        var exactWanderDest = GetExactWanderDest(pawn);
        if (!exactWanderDest.IsValid || Rand.Range(0f, 1f) < 0.5f)
        {
            return null;
        }

        var job = new Job(JobDefOf.GotoWander, exactWanderDest)
        {
            locomotionUrgency = locomotionUrgency
        };
        pawn.Map.pawnDestinationReservationManager.Reserve(pawn, job, exactWanderDest);
        locomotionUrgency = Rand.Range(0f, 1f) < 0.5f ? LocomotionUrgency.Amble : LocomotionUrgency.Walk;

        return job;
    }
}