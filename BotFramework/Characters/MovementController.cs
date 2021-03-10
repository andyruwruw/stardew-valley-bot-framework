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
		public PathFindController(Character c, GameLocation location, Point endPoint, int finalFacingDirection)
			: this(c, location, isAtEndPoint, finalFacingDirection, eraseOldPathController: false, null, 10000, endPoint)
		{
		}

		public PathFindController(Character c, GameLocation location, Point endPoint, int finalFacingDirection, endBehavior endBehaviorFunction)
			: this(c, location, isAtEndPoint, finalFacingDirection, eraseOldPathController: false, null, 10000, endPoint)
		{
			this.endPoint = endPoint;
			this.endBehaviorFunction = endBehaviorFunction;
		}

		public PathFindController(Character c, GameLocation location, Point endPoint, int finalFacingDirection, endBehavior endBehaviorFunction, int limit)
			: this(c, location, isAtEndPoint, finalFacingDirection, eraseOldPathController: false, null, limit, endPoint)
		{
			this.endPoint = endPoint;
			this.endBehaviorFunction = endBehaviorFunction;
		}

		public PathFindController(Character c, GameLocation location, Point endPoint, int finalFacingDirection, bool eraseOldPathController, bool clearMarriageDialogues = true)
			: this(c, location, isAtEndPoint, finalFacingDirection, eraseOldPathController, null, 10000, endPoint, clearMarriageDialogues)
		{
		}

		public static bool isAtEndPoint(PathNode currentNode, Point endPoint, GameLocation location, Character c)
		{

		}

		public PathFindController(Stack<Point> pathToEndPoint, GameLocation location, Character c, Point endPoint)
		{

		}

		public PathFindController(Stack<Point> pathToEndPoint, Character c, GameLocation l)
		{

		}

		public PathFindController(Character c, GameLocation location, isAtEnd endFunction, int finalFacingDirection, bool eraseOldPathController, endBehavior endBehaviorFunction, int limit, Point endPoint, bool clearMarriageDialogues = true)
		{

		}

		public bool isPlayerPresent()
		{
			return this.location.farmers.Any();
		}

		public bool update(GameTime time)
		{

		}

		public static Stack<Point> findPath(Point startPoint, Point endPoint, isAtEnd endPointFunction, GameLocation location, Character character, int limit)
		{

		}

		public static Stack<Point> reconstructPath(PathNode finalNode)
		{

		}

		private byte[,] createMapGrid(GameLocation location, Point endPoint)
		{

		}

		private void moveCharacter(GameTime time)
		{

		}

		public void handleWarps(Rectangle position)
		{

		}

		public static bool IsPositionImpassableOnFarm(GameLocation loc, int x, int y)
		{

		}

		public static Stack<Point> FindPathOnFarm(Point startPoint, Point endPoint, GameLocation location, int limit)
		{

		}

		public static int GetFarmTileWeight(GameLocation location, int x, int y, Dictionary<Vector2, int> weight_map)
		{

		}

		public static int CheckClearance(GameLocation location, Rectangle rect)
		{

		}

		public static Stack<Point> findPathForNPCSchedules(Point startPoint, Point endPoint, GameLocation location, int limit)
		{

		}

		private static bool isPositionImpassableForNPCSchedule(GameLocation loc, int x, int y)
		{

		}

		private static int getPreferenceValueForTerrainType(GameLocation l, int x, int y)

	}
}
