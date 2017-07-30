using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolver.Classes
{
    public class WaterJugModel
    {
        #region Fields
        public int jugA, jugB, jugAMaxLimit, jugBMaxLimit, gallonsToFill;
        #endregion

        #region Constructors
        public WaterJugModel(int jugA, int jugB, int jugAMaxLimit, int jugBMaxLimit, int gallonsToFill)
        {
            this.jugA = jugA;
            this.jugB = jugB;
            this.jugAMaxLimit = jugAMaxLimit;
            this.jugBMaxLimit = jugBMaxLimit;
            this.gallonsToFill = gallonsToFill;
        }
        #endregion
    }
}
