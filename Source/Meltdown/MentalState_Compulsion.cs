using RimWorld;
using Verse.AI;

namespace MoreMentalBreaks;

public class MentalState_Compulsion : MentalState
{
    public override RandomSocialMode SocialModeMax()
    {
        return RandomSocialMode.Off;
    }
}