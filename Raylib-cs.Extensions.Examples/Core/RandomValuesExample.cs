namespace Raylib_cs.Extensions.Game.Core;

public class RandomValuesExample : IExample
{
    public void Run(string[] args)
    {
        // note: getrandomvalue is only used to match this example, so it'll have sense

        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - generate random values");

        // SetRandomSeed(0xaabbccff);   // Set a custom random seed if desired, by default: "time(Null)"

        var randValue = GetRandomValue(-8, 5); // Get a random integer number between -8 and 5 (both included)

        var framesCounter = 0; // Variable used to count frames

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            framesCounter++;

            // Every two seconds (120 frames) a new random value is generated
            if (framesCounter / 120 % 2 == 1)
            {
                randValue = GetRandomValue(-8, 5);
                framesCounter = 0;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                Color.Maroon.DrawText("Every 2 seconds a new random value is generated:", 130, 100, 20);

                Color.LightGray.DrawText(randValue.ToString(), 360, 180, 80);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}