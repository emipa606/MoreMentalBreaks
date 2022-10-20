using RimWorld;

namespace Verse.AI;

public class MentalState_Apathy : MentalState
{
    public override RandomSocialMode SocialModeMax()
    {
        return RandomSocialMode.Quiet;
    }
}