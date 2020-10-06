using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShip_Game
{
    public class cfg
    {
        public static char[] letter = { '/', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
    }

    public class func
    {
        public static int[] grideMy_GetIdBox(string namePole)
        {
            //if (namePole == "-") MessageBox.Show("??");
            int idPoleY = Array.FindLastIndex(cfg.letter, item => item == namePole[0]);
            int idPoleX = Convert.ToInt32(namePole.Substring(1));
            return new int[] { idPoleX, idPoleY };
        }

        public static int[] grideMy_GetStartPos(int[] idPole)
        {
            int posX = ((idPole[0] - 1) * 34) + 35;
            int posY = ((idPole[1] - 1) * 33) + 34;

            return new int[] { posX, posY };
        }
    }
}
