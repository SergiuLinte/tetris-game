using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class Patrat : Piesa
    {

        public Patrat()
        {
            pP_X1 = 5; pP_Y1 = 1;//prima celula din patrat                ex: y 
            pP_X2 = 5; pP_Y2 = 2;//a 2a celula din patrat               x     1 2
            pP_X3 = 6; pP_Y3 = 1;//a 3a celula din patrat                     3 4
            pP_X4 = 6; pP_Y4 = 2;//a 4a celula din patrat
        }

        public override void fP_ColoreazaPiesaCurenta(Game game)
        {
            game.pG_Matrice[pP_X1, pP_Y1] = 2;
            game.pG_Matrice[pP_X2, pP_Y2] = 2;
            game.pG_Matrice[pP_X3, pP_Y3] = 2;
            game.pG_Matrice[pP_X4, pP_Y4] = 2;

            for (int i = 1; i < game.pG_Matrice.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < game.pG_Matrice.GetLength(1) - 1; j++)
                {
                    if (game.pG_Matrice[i, j] == 2)
                        game.tableLayoutPanel1.GetControlFromPosition(i, j).BackColor = Color.FromArgb(5,175,242);
                }
            }
        }
    }
}

