using Verse;
using Verse.AI;

namespace MoreMentalBreaks;

public class MentalStateWorker_Compulsion : MentalStateWorker
{
    public override bool StateCanOccur(Pawn pawn)
    {
        return true;
    }
}