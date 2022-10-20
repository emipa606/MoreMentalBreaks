using System.Collections.Generic;
using RimWorld;

namespace Verse.AI;

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

        var pawns = FindPawns(p);
        var pos = DropCellFinder.RandomDropSpot(p.Map);
        var num = 50;
        var num2 = 0;
        while (!Validate(pos, pawns))
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

    private List<Pawn> FindPawns(Pawn localPawn)
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

    private bool Validate(IntVec3 pos, List<Pawn> pawns)
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