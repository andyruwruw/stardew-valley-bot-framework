using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Characters
{
    class MovementController : PathFindController
    {
		public MovementController(Character c, GameLocation location, Point endPoint, int finalFacingDirection) : base(c, location, endPoint, finalFacingDirection) { }

		public MovementController(Character c, GameLocation location, Point endPoint, int finalFacingDirection, endBehavior endBehaviorFunction) : base(c, location, endPoint, finalFacingDirection) { }

		public MovementController(Character c, GameLocation location, Point endPoint, int finalFacingDirection, endBehavior endBehaviorFunction, int limit) : base(c, location, endPoint, finalFacingDirection, endBehaviorFunction, limit) { }
		public MovementController(Character c, GameLocation location, Point endPoint, int finalFacingDirection, bool eraseOldPathController, bool clearMarriageDialogues = true) : base (c, location, endPoint, finalFacingDirection, eraseOldPathController, clearMarriageDialogues) { }


		public MovementController(Stack<Point> pathToEndPoint, GameLocation location, Character c, Point endPoint) : base(pathToEndPoint, location, c, endPoint) { }

		public MovementController(Stack<Point> pathToEndPoint, Character c, GameLocation l) : base(pathToEndPoint, c, l) { }

		public MovementController(Character c, GameLocation location, isAtEnd endFunction, int finalFacingDirection, bool eraseOldPathController, endBehavior endBehaviorFunction, int limit, Point endPoint, bool clearMarriageDialogues = true) : base(c, location, endFunction, finalFacingDirection, eraseOldPathController, endBehaviorFunction, limit, endPoint, clearMarriageDialogues) { }

		//public static bool isAtEndPoint(PathNode currentNode, Point endPoint, GameLocation location, Character c)
		//{

		//}

		//public bool isPlayerPresent()
		//{
		//	return this.location.farmers.Any();
		//}

		//public bool update(GameTime time)
		//{

		//}

		//public static Stack<Point> findPath(Point startPoint, Point endPoint, isAtEnd endPointFunction, GameLocation location, Character character, int limit)
		//{

		//}

		//public static Stack<Point> reconstructPath(PathNode finalNode)
		//{

		//}

		//private byte[,] createMapGrid(GameLocation location, Point endPoint)
		//{

		//}

		//private void moveCharacter(GameTime time)
		//{

		//}

		//public void handleWarps(Rectangle position)
		//{

		//}

		//public static bool IsPositionImpassableOnFarm(GameLocation loc, int x, int y)
		//{

		//}

		//public static Stack<Point> FindPathOnFarm(Point startPoint, Point endPoint, GameLocation location, int limit)
		//{

		//}

		//public static int GetFarmTileWeight(GameLocation location, int x, int y, Dictionary<Vector2, int> weight_map)
		//{

		//}

		//public static int CheckClearance(GameLocation location, Rectangle rect)
		//{

		//}

		//public static Stack<Point> findPathForNPCSchedules(Point startPoint, Point endPoint, GameLocation location, int limit)
		//{

		//}

		//private static bool isPositionImpassableForNPCSchedule(GameLocation loc, int x, int y)
		//{

		//}

		//private static int getPreferenceValueForTerrainType(GameLocation l, int x, int y)

	}
}
