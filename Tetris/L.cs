using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class L : Piesa
    {
        int pozitiePiesa = 1;
        public int PozitiePiesa { get => pozitiePiesa; set => pozitiePiesa = value; }

        #region Metode

        public L()
        {
            pP_X1 = 6; pP_Y1 = 1;//prima celula din L                ex: 1
            pP_X2 = 6; pP_Y2 = 2;//a 2a celula din L                     2
            pP_X3 = 6; pP_Y3 = 3;//a 3a celula din L                     3 4
            pP_X4 = 7; pP_Y4 = 3;//a 4a celula din L
        }

        public override void fP_ColoreazaPiesaCurenta(Game game)
        {
            game.pG_Matrice[pP_X1, pP_Y1] = 5;
            game.pG_Matrice[pP_X2, pP_Y2] = 5;
            game.pG_Matrice[pP_X3, pP_Y3] = 5;
            game.pG_Matrice[pP_X4, pP_Y4] = 5;

            for (int i = 1; i < game.pG_Matrice.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < game.pG_Matrice.GetLength(1) - 1; j++)
                {
                    if (game.pG_Matrice[i, j] == 5)
                        game.tableLayoutPanel1.GetControlFromPosition(i, j).BackColor = Color.FromArgb(242, 135, 5);
                }
            }
        }

        public override void fP_RotirePiesaInPoz2(Game game)
        {
            /*
                   1                  
                   2           --->    3 2 1 
                   3 4                 4 
                                     
            */
            if (fP_VerificaDacaPoz2ELibera(game))
            {
                PozitiePiesa = 2;

                this.fP_StergePiesaCurenta(game);


                //roteste piesa
                pP_X1 = pP_X1 + 2; pP_Y1 = pP_Y1 + 1;
                pP_X2++; // y2 ramane la fel
                pP_Y3--; // x3 ramane la fel
                pP_X4--; // y4 ramane la fel


                this.fP_ColoreazaPiesaCurenta(game);
            }
        }

        public override void fP_RotirePiesaInPoz3(Game game)
        {
            /*
                 3 2 1  --->    4 3
                 4                2
                                  1
                                     
            */
            if (fP_VerificaDacaPoz3ELibera(game))
            {
                PozitiePiesa = 3;

                this.fP_StergePiesaCurenta(game);


                //roteste piesa
                pP_X1--; pP_Y1 = pP_Y1 + 2;
                pP_Y2++; // y2 ramane la fel
                pP_X3++; // y3 ramane la fel
                pP_Y4--; // x4 ramane la fel

                this.fP_ColoreazaPiesaCurenta(game);
            }
        }

        public override void fP_RotirePiesaInPoz4(Game game)
        {
            /*
                   4 3            4
                     2  --->  1 2 3
                     1

           */
            if (fP_VerificaDacaPoz4ELibera(game))
            {
                PozitiePiesa = 4;

                this.fP_StergePiesaCurenta(game);


                //roteste piesa
                pP_X1 = pP_X1 - 2; pP_Y1--;
                pP_X2--; // y2 ramane la fel
                pP_Y3++; // x3 ramane la fel
                pP_X4++; // y4 ramane la fel


                this.fP_ColoreazaPiesaCurenta(game);
            }
        }

        public override void fP_RotirePiesaInPoz1(Game game)
        {
            /*                   1
                    4     --->   2
                1 2 3            3 4


          */
            if (fP_VerificaDacaPoz1ELibera(game))
            {
                PozitiePiesa = 1;

                this.fP_StergePiesaCurenta(game);


                //roteste piesa
                pP_X1++; pP_Y1 = pP_Y1 - 2;
                pP_Y2--; // x2 ramane la fel
                pP_X3--; // y3 ramane la fel
                pP_Y4++; // x4 ramane la fel


                this.fP_ColoreazaPiesaCurenta(game);
            }


        }

        public override void fP_RotirePiesa(Game game)
        {
            if (PozitiePiesa == 1)
                fP_RotirePiesaInPoz2(game);
            else if (PozitiePiesa == 2)
                fP_RotirePiesaInPoz3(game);
            else if (PozitiePiesa == 3)
                fP_RotirePiesaInPoz4(game);
            else
                fP_RotirePiesaInPoz1(game);
        }


        //verificarile daca se poate roti piesa

        public override bool fP_VerificaDacaPoz2ELibera(Game game)
        {
            bool eLiber = false;

            if (game.pG_Matrice[pP_X1 + 2, pP_Y1 + 1] == 0 &&
                game.pG_Matrice[pP_X2 + 1, pP_Y2] == 0
                )
            {
                eLiber = true;
            }

            return eLiber;
        }

        public override bool fP_VerificaDacaPoz3ELibera(Game game)
        {
            bool eLiber = false;

            if (game.pG_Matrice[pP_X1 - 1, pP_Y1 + 2] == 0 &&
                game.pG_Matrice[pP_X2, pP_Y2 + 1] == 0
                )
            {
                eLiber = true;
            }

            return eLiber;


        }

        public override bool fP_VerificaDacaPoz4ELibera(Game game)
        {
            bool eLiber = false;

            if (game.pG_Matrice[pP_X1 - 2, pP_Y1 - 1] == 0 &&
                game.pG_Matrice[pP_X2 - 1, pP_Y2] == 0
                )
            {
                eLiber = true;
            }

            return eLiber;

        }

        public override bool fP_VerificaDacaPoz1ELibera(Game game)
        {
            bool eLiber = false;

            if (game.pG_Matrice[pP_X1 + 1, pP_Y1 - 2] == 0 &&
                game.pG_Matrice[pP_X2, pP_Y2 - 1] == 0
                )
            {
                eLiber = true;
            }

            return eLiber;

        }
        #endregion

    }
}
