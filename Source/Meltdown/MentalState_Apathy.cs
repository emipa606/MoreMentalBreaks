using RimWorld;
using Verse.AI;

namespace MoreMentalBreaks;

public class MentalState_Apathy : MentalState
{
    public override RandomSocialMode SocialModeMax()
    {
        return RandomSocialMode.Quiet;
    }
}