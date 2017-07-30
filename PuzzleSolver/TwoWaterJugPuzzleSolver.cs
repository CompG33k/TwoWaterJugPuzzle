using PuzzleSolver.Classes;
using System;
using System.IO;
using System.Text;

namespace PuzzleSolver
{
    public class TwoWaterJugPuzzleSolver
    {
        #region Methods
        /// <summary>
        ///     Begins the process of pouring water from one jug to another until the goal is reached.
        /// </summary>
        /// <param name="model">The model.</param>
        public static string GetJugFillInstructions(ref WaterJugModel model) //dont do Classes namespace, it makes no sense
        {
            var sb = new StringBuilder();
            for (var i = 1; ; i++)
            {
                if (IsGoalReached(model.jugA, model.gallonsToFill) || IsGoalReached(model.jugB, model.gallonsToFill))
                {
                    sb.AppendLine("You are finished!");
                    return sb.ToString();
                }

                if (IsJugEmpty(model.jugA))
                {
                    model.jugA = model.jugAMaxLimit;
                    sb.AppendLine(string.Format("{0}. Fill {1}-gallon jug.", i, model.jugAMaxLimit));
                    sb.AppendLine(string.Format("( {0} , {1} )", model.jugA, model.jugB));
                }
                else if (IsAnyGallonsLeftInJug(model.jugA) && CanAddWater(model.jugB, model.jugBMaxLimit))
                {
                    PourJugAtoB(ref model.jugA, ref model.jugB, model.jugBMaxLimit);
                    sb.AppendLine(string.Format("{0}. Transfer water from {1}-gallon jug to {2}-gallon jug.", i, model.jugAMaxLimit, model.jugBMaxLimit));
                    sb.AppendLine(string.Format("( {0} , {1} )", model.jugA, model.jugB));
                }
                else if (IsAnyGallonsLeftInJug(model.jugA) && IsJugFull(model.jugB, model.jugBMaxLimit))
                {
                    model.jugB = 0;
                    sb.AppendLine(string.Format("{0}. Pour out {1}-gallon jug.", i, model.jugBMaxLimit));
                    sb.AppendLine(string.Format("( {0} , {1} )", model.jugA, model.jugB));
                }
            }
        }

        /// <summary>
        ///     Pours the jug ato b.
        /// </summary>
        /// <param name="jugA">The jug a.</param>
        /// <param name="jugB">The jug b.</param>
        /// <param name="jugBMax">The jug b maximum capacity in gallons.</param>
        private static void PourJugAtoB(ref int jugA, ref int jugB, int jugBMax)
        {
            while (!IsJugFull(jugB, jugBMax) && !IsJugEmpty(jugA))
            {
                AddAGallon(ref jugB, jugBMax);
                RemoveAGallon(ref jugA);
            }
        }

        /// <summary>
        ///     Determines whether [is goal reached] [the specified jug].
        /// </summary>
        /// <param name="jug">The jug.</param>
        /// <param name="gallonsToFill">The gallons to fullfill.</param>
        /// <returns></returns>
        private static bool IsGoalReached(int jug, int gallonsToFill)
        {
            return jug == gallonsToFill;
        }

        /// <summary>
        ///     Determines whether [is jug full] [the specified jug].
        /// </summary>
        /// <param name="jug">The jug.</param>
        /// <param name="jugMax">The jug maximum capacity in gallons.</param>
        /// <returns></returns>
        private static bool IsJugFull(int jug, int jugMax)
        {
            return jug == jugMax;
        }

        /// <summary>
        ///     Determines whether [is jug empty] [the specified jug].
        /// </summary>
        /// <param name="jug">The jug.</param>
        /// <returns></returns>
        private static bool IsJugEmpty(int jug)
        {
            return jug == 0;
        }

        /// <summary>
        ///     Removes a gallon.
        /// </summary>
        /// <param name="jug">The jug.</param>
        private static void RemoveAGallon(ref int jug)
        {
            jug = Math.Max(0, jug - 1);
        }

        /// <summary>
        ///     Adds a gallon.
        /// </summary>
        /// <param name="jug">The jug.</param>
        private static void AddAGallon(ref int jug, int jugMax)
        {
            jug = Math.Min(jugMax, jug + 1);
        }

        /// <summary>
        ///     Determines whether [is any gallons left in jug] [the specified jug].
        /// </summary>
        /// <param name="jug">The jug.</param>
        /// <returns></returns>
        private static bool IsAnyGallonsLeftInJug(int jug)
        {
            return jug > 0;
        }

        /// <summary>
        ///     Determines whether this instance [can i add water] the specified jug.
        /// </summary>
        /// <param name="jug">The jug.</param>
        /// <param name="jugMax">The jug maximum capacity in gallons.</param>
        /// <returns></returns>
        private static bool CanAddWater(int jug, int jugMax)
        {
            return jug < jugMax;
        }
        #endregion
    }
}
