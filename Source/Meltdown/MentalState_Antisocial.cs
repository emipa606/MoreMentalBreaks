using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace MoreMentalBreaks;

public class MentalState_Antisocial : MentalState
{
    private bool initialized;

    private bool reached;

    private IntVec3 target_pos;

    public void Initialize(Pawn p)
    {
        if (initialized)
        {
            return;
        }

        var pawns = findPawns(p);
        var pos = DropCellFinder.RandomDropSpot(p.Map);
        const int num = 50;
        var num2 = 0;
        while (!validate(pos, pawns))
        {
            num2++;
            pos = DropCellFinder.RandomDropSpot(p.Map);
            if (num2 <= num)
            {
                continue;
            }

            var noRemoteSpotFound = true;
            foreach (var allCell in p.Map.AllCells)
            {
                if (p.Map.areaManager.Home[allCell])
                {
                    continue;
                }

                pos = allCell;
                noRemoteSpotFound = false;
                break;
            }

            if (noRemoteSpotFound)
            {
                break;
            }
        }

        target_pos = pos;
        reached = false;
        initialized = true;
    }

    private static List<Pawn> findPawns(Pawn localPawn)
    {
        var allPawnsSpawned = localPawn.Map.mapPawns.AllPawnsSpawned;
        var list = new List<Pawn>();
        foreach (var item in allPawnsSpawned)
        {
            if (!item.DestroyedOrNull() && !item.Downed && !item.Dead &&
                (item.IsPrisonerOfColony || item.IsColonist || item.IsColonistPlayerControlled))
            {
                list.Add(item);
            }
        }

        return list;
    }

    private static bool validate(IntVec3 pos, List<Pawn> pawns)
    {
        foreach (var foundPawn in pawns)
        {
            if (IntVec3Utility.ManhattanDistanceFlat(pos, foundPawn.PositionHeld) < 50)
            {
                return false;
            }
        }

        return !Find.CurrentMap.areaManager.Home[pos];
    }

    public void SetReached(bool r)
    {
        reached = r;
    }

    public bool ReachedPos()
    {
        return reached;
    }

    public IntVec3 GetTargetPos()
    {
        return target_pos;
    }

    public override RandomSocialMode SocialModeMax()
    {
        return RandomSocialMode.Off;
    }
}