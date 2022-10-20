using RimWorld;

namespace Verse.AI;

public class MentalState_Compulsion : MentalState
{
    public override RandomSocialMode SocialModeMax()
    {
        return RandomSocialMode.Off;
    }
}