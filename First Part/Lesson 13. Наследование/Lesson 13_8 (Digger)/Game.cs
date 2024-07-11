﻿

using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public static class Game
{
	private const string mapWithPlayerTerrain = @"
TTT T
TTP T
T T T
TT TT";

	private const string mapWithPlayerTerrainSackGold = @"
PTTGTT TS
TST  TSTT
TTTTTTSTT
T TSTS TT
T TTTG ST
TSTSTT TT";

    private const string mapWithPlayerTerrainSackGold2 = @"
SSSS
    
    
TGS ";

    private const string mapWithPlayerTerrainSackGoldMonster = @"
PTTGTT TST
TST  TSTTM
TTT TTSTTT
T TSTS TTT
T TTTGMSTS
T TMT M TS
TSTSTTMTTT
S TTST  TG
 TGST MTTT
 T  TMTTTT";

    private const string mapWithPlayerTerrainSackGoldMonster2 = @"
P M";

    private const string mapWithPlayerTerrainSackGoldMonster3 = @"
S
 
M";

    public static ICreature[,] Map;
    public static int Scores;
	public static bool IsOver;

	public static Key KeyPressed;
	public static int MapWidth => Map.GetLength(0);
	public static int MapHeight => Map.GetLength(1);

	public static void CreateMap()
	{
		Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrainSackGoldMonster3);
	}
}