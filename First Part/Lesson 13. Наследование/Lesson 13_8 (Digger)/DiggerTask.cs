using Avalonia.Input;
using Digger.Architecture;
using System;
using System.Collections.Generic;

namespace Digger;

public class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y) => new();

    public bool DeadInConflict(ICreature conflictedObject)
        => (conflictedObject is Player);

    public int GetDrawingPriority() => 0;

    public string GetImageFileName() => "Terrain.png";
}

public class Player : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        var creatureCommand = new CreatureCommand();

        switch (Game.KeyPressed)
        {
            case Key.Down: 
                if (y < Game.MapHeight - 1
                    && Game.Map[x, y + 1] is not Sack)
                    creatureCommand.DeltaY = 1;
                break;

            case Key.Up:
                if (y > 0
                    && Game.Map[x, y - 1] is not Sack)
                    creatureCommand.DeltaY = -1;
                break;

            case Key.Right:
                if (x < Game.MapWidth - 1
                    && Game.Map[x + 1, y] is not Sack)
                    creatureCommand.DeltaX = 1;
                break;

            case Key.Left:
                if (x > 0
                    && Game.Map[x - 1, y] is not Sack)
                    creatureCommand.DeltaX = -1;
                break;
        }
        return creatureCommand;
    }

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack or Monster;

    public int GetDrawingPriority() => 100;

    public string GetImageFileName() => "Digger.png";
}

public class Sack : ICreature
{
    public int FallHeight;
    public CreatureCommand Act(int x, int y)
    {
        if (y < Game.MapHeight - 1)
        {
            var objectBelowOnMap = Game.Map[x, y + 1];
            if (objectBelowOnMap == null || (FallHeight > 0 && (objectBelowOnMap is Player)))
                FallHeight++;
            
            if (objectBelowOnMap == null || (FallHeight > 1 && (objectBelowOnMap is Monster)))
                FallHeight++;
            
            return new CreatureCommand() { DeltaX = 0, DeltaY = 1 };
        }

        if (FallHeight > 1)
        {
            FallHeight = 0;
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
        }

        FallHeight = 0;
        return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return false;
    }

    public int GetDrawingPriority() => 50;

    public string GetImageFileName() => "Sack.png";
}

public class Gold : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand();
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if (conflictedObject is Player)
        {
            Game.Scores += 10;
            return true;
        }
        if (conflictedObject is Monster)
            return true;
        
        return false;
    }

    public int GetDrawingPriority() => 60;

    public string GetImageFileName() => "Gold.png";
}

public class Monster : ICreature
{
    private static (int x, int y) GetPlayerPosition()
    {
        for (int i = 0; i < Game.MapWidth; i++)
            for (int j = 0; j < Game.MapHeight; j++)
                if (Game.Map[i, j] is Player)
                    return (i, j);
        
        throw new Exception("Попытка получить позицию игрока, когда его нет на карте.");
    }

    private static bool PlayerExists()
    {
        for (int i = 0; i < Game.MapWidth; i++)
            for (int j = 0; j < Game.MapHeight; j++)
                if (Game.Map[i, j] is Player)
                        return true;
        return false;
    }

    private static bool MonsterCanStep(int x, int y) =>
        !(Game.Map[x, y] is Terrain or Sack);

    public CreatureCommand Act(int x, int y)
    {
        if (!PlayerExists())
            return new CreatureCommand();

        (int playerX, int playerY) = GetPlayerPosition();

        var creatureCommand = new CreatureCommand();

        if (playerX < x && MonsterCanStep(x - 1, y))
            creatureCommand.DeltaX = -1;
        else if (playerX > x && MonsterCanStep(x + 1, y))
            creatureCommand.DeltaX = 1;
        else if (playerY < y && MonsterCanStep(x, y - 1))
            creatureCommand.DeltaY = -1;
        else if (playerY > y && MonsterCanStep(x, y + 1))
            creatureCommand.DeltaY = 1;

        return creatureCommand;
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if (conflictedObject is Sack sack)
            if (sack.FallHeight > 0)
                return true;

        return conflictedObject is Monster;
    }

    public int GetDrawingPriority() => 90;

    public string GetImageFileName() => "Monster.png";
}