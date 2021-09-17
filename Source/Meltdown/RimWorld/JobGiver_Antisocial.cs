using Verse;
using Verse.AI;

namespace RimWorld
{
    public class JobGiver_Antisocial : ThinkNode_JobGiver
    {
        protected bool IgnoreForbid(Pawn pawn)
        {
            return pawn.InMentalState;
        }

        protected override Job TryGiveJob(Pawn pawn)
        {
            ((MentalState_Antisocial)pawn.MentalState).Initialize(pawn);
            var targetPos = ((MentalState_Antisocial)pawn.MentalState).GetTargetPos();
            if (CloseToPoint(pawn, targetPos))
            {
                ((MentalState_Antisocial)pawn.MentalState).SetReached(true);
            }

            if (((MentalState_Antisocial)pawn.MentalState).ReachedPos())
            {
                return null;
            }

            return new Job(JobDefOf.GotoWander, targetPos);
        }

        private bool CloseToPoint(Pawn p, IntVec3 pos)
        {
            return IntVec3Utility.ManhattanDistanceFlat(p.PositionHeld, pos) < 15;
        }
    }
}