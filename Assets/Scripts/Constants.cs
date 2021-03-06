﻿// Class for storing constants such as Tags, Scene indices, Player prefs keys, etc...
public static class Constants
{
    // Tags
    public const string PlayerTag = "Player";
    public const string BoundaryTag = "Boundary";
    public const string AsteroidTag = "Asteroid";

    // Scene indices
    public const int MainSceneBuildIndex = 0;
    public const int LevelSelectionSceneBuildIndex = 1;
    public const int PlaySceneBuildIndex = 2;
    public const int WinSceneBuildIndex = 3;
    public const int LoseSceneBuildIndex = 4;

    // Used to access level info
    public const string LevelSelectionPrefix = "Level";
    // Used to pass selected level index to game scene
    public const string CurrentlySelectedLevel = "SelectedLevel";

    // Object pools
    public const string BulletPoolTag = "Bullet";
    public const string AsteroidPoolTag = "Asteroid";

    // Animation Trigger
    public const string TransitionFadeOut = "StartFadeOut";
}
