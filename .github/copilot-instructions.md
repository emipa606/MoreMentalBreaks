# GitHub Copilot Instructions for MoreMentalBreaks Mod

## Mod Overview and Purpose

The `MoreMentalBreaks` mod is an update to the existing `nükes` mod for the game RimWorld. This mod adds new mental breaks to enhance the psychological depth of pawns in the game. The mental breaks introduced include:

- **Extreme Mental Breaks:**
  - **Self-Harm:** The pawn will cut their wrists and hide in their room.
    - **Base Chance:** Medium
    - **Trait Influence:** High chance for Masochist trait.

- **Moderate Mental Breaks:**
  - **Antisocial:** The pawn walks into the wilderness and avoids their fellow colonists for a while.
    - **Base Chance:** High

- **Minor Mental Breaks:**
  - **Apathy:** The pawn becomes lethargic and wanders around instead of working. They cannot be manually assigned to tasks or drafted while they are apathetic.
    - **Base Chance:** High

## Key Features and Systems

### Mental Breaks
The mod introduces three new categories of mental breaks:
1. **Extreme Breaks:**
   - **Self-Harm:** Includes job givers and mental state definitions to simulate self-harm behavior.
2. **Moderate Breaks:**
   - **Antisocial:** Includes job givers and mental state definitions to simulate antisocial behavior.
3. **Minor Breaks:**
   - **Apathy:** Includes job givers and mental state definitions to simulate apathetic behavior.

### XML Integration
The mod uses XML files to define new mental states and tales. Key XML files include:
- `Meltdown.xml` for mental state definitions.
- `Tales_SinglePawn.xml` for tale definitions.
- `SubTrees_Misc.xml` for think tree definitions.

## Coding Patterns and Conventions

### C# Files
The C# files in the mod are organized into job givers and mental state definitions:
- **JobGiver_Antisocial.cs:** Contains the job giver for antisocial behavior.
- **JobGiver_Apathy.cs:** Contains the job giver for apathetic behavior.
- **JobGiver_Compulsion.cs:** Contains the job giver for compulsion behavior.
- **MentalState_Antisocial.cs:** Contains the mental state logic for antisocial behavior.
- **MentalState_Compulsion.cs:** Contains the mental state logic for compulsion behavior.

### XML Files
The XML files are structured to define new mental states and tales:
- **MentalStateDefs/Meltdown.xml:** Defines new mental state definitions.
- **TaleDefs/Tales_SinglePawn.xml:** Defines new tale definitions.
- **ThinkTreeDefs/SubTrees_Misc.xml:** Defines new think tree definitions.

## Harmony Patching

The mod uses Harmony patching to integrate new mental states and behaviors into the existing game mechanics. Harmony patches are used to:
- Modify existing pawn behavior.
- Add new job givers and mental states.

## Suggestions for Copilot

When using Copilot for this mod, consider the following:
1. **XML Definitions:** Use Copilot to generate XML templates for new mental states and tales.
2. **Job Givers and Mental States:** Use Copilot to scaffold new job giver and mental state classes.
3. **Harmony Patches:** Use Copilot to generate Harmony patches to integrate new mechanics into the game.

### Example Usage

#### Generating XML Definitions
To generate an XML definition for a new mental state, use Copilot with the following prompt:

xml
<!-- Generate an XML definition for a new mental state -->
<MentalStateDef>
  <defName>SelfHarm</defName>
  <label>Self-Harm</label>
  <description>The pawn will cut their wrists and hide in their room.</description>
  <baseChance>0.1</baseChance>
  <chanceFactorForTrait>Masochist</chanceFactorForTrait>
</MentalStateDef>


#### Generating Job Givers and Mental States
To generate a new job giver class, use Copilot with the following prompt:

csharp
// Generate a new job giver class for antisocial behavior
public class JobGiver_Antisocial : JobGiver_Wander
{
    public override Job TryGiveJob(Pawn pawn)
    {
        // Implementation for antisocial behavior
    }
}


#### Generating Harmony Patches
To generate a Harmony patch to integrate a new mental state, use Copilot with the following prompt:

csharp
// Generate a Harmony patch to integrate new mental state
[HarmonyPatch(typeof(Pawn_MindState), nameof(Pawn_MindState.RandomizeMentalState))]
public static class MentalStatePatch
{
    [HarmonyPostfix]
    public static void RandomizeMentalState_Postfix(Pawn_MindState __instance)
    {
        // Implementation to add new mental state
    }
}


## Conclusion

The `MoreMentalBreaks` mod enhances the psychological depth of pawns in RimWorld by introducing new mental breaks. By following the coding patterns and conventions outlined in this document, you can effectively use Copilot to generate and maintain the mod's codebase.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

