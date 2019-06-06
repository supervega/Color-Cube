using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Rubiks_Interface
{
    public enum Direction { Up, Down, Left, Right, Front, Back }
    public enum PieceKind { Center, Edge, Corner }
    public struct SearchResult
    {
        public int faceIndex;
        public int index;
        public int x;
        public int y;
    };

    public class Manager
    {
        private Piece[,] faces;// 0 = front, 1 = Left, 2 = Back, 3 = Right, 4 = Up, 5 = Down (Initial State)
        private List<string> movesHistory;
        private int solvesleep=0;
        private Thread solveTHread;
        public ToolStripStatusLabel status;
        private bool TurnPauseOn = true;
        public bool IsCubeSolved = false;
        public bool IsHistoryActive = false;


        int LocalMovesCount = 0;
        List<SearchResult> previousSearchResults;

        public Manager()
        {
            Initialize();            
        }

        #region Properties

        public Piece[,] Faces
        {
            get
            {
                return faces;
            }
        }

        public List<string> MovesHistory
        {
            get
            {
                return movesHistory;
            }
            set
            {
                movesHistory = value;
            }
        }

        public int SolveSleep
        {
            get
            {
                return solvesleep;
            }
            set
            {
                solvesleep = value;
            }
        }

        #endregion

        public void Initialize()
        {
            Dispose();
            IsCubeSolved = false;
            faces = new Piece[6, 9];
            movesHistory = new List<string>();
            previousSearchResults = new List<SearchResult>();
            for (int i = 0; i < 6; i++)
            {                
                for (int j = 0; j < 9; j++)
                {
                    #region Corner State
                    if (j == 0 || j == 2 || j == 6 || j == 8)
                    {
                        Color[] cols = new Color[3];
                        Direction[] dirs = new Direction[3];
                        switch (i)
                        {
                            case 0:
                                switch (j)
                                {
                                    case 0: cols[0] = Color.Red;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 2: cols[0] = Color.Red;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 6: cols[0] = Color.Red;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Down;
                                        break;
                                    case 8: cols[0] = Color.Red;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Down;
                                        break;
                                }
                                break;
                            case 1: switch (j)
                                {
                                    case 0: cols[0] = Color.Yellow;
                                        cols[1] = Color.Orange;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 2: cols[0] = Color.Yellow;
                                        cols[1] = Color.Red;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 6: cols[0] = Color.Yellow;
                                        cols[1] = Color.Orange;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Down;
                                        break;
                                    case 8: cols[0] = Color.Yellow;
                                        cols[1] = Color.Red;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Down;
                                        break;
                                }
                                break;
                            case 2:
                                switch (j)
                                {
                                    case 0: cols[0] = Color.Orange;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 2: cols[0] = Color.Orange;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 6: cols[0] = Color.Orange;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Down;
                                        break;
                                    case 8: cols[0] = Color.Orange;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Down;
                                        break;
                                }
                                break;
                            case 3: switch (j)
                                {
                                    case 0: cols[0] = Color.White;
                                        cols[1] = Color.Red;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 2: cols[0] = Color.White;
                                        cols[1] = Color.Orange;
                                        cols[2] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 6: cols[0] = Color.White;
                                        cols[1] = Color.Red;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Down;
                                        break;
                                    case 8: cols[0] = Color.White;
                                        cols[1] = Color.Orange;
                                        cols[2] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Down;
                                        break;
                                }
                                break;
                            case 4: switch (j)
                                {
                                    case 0: cols[0] = Color.Green;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 2: cols[0] = Color.Green;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 6: cols[0] = Color.Green;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Down;
                                        break;
                                    case 8: cols[0] = Color.Green;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Down;
                                        break;
                                }
                                break;
                            case 5: switch (j)
                                {
                                    case 0: cols[0] = Color.Blue;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 2: cols[0] = Color.Blue;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Up;
                                        break;
                                    case 6: cols[0] = Color.Blue;
                                        cols[1] = Color.Yellow;
                                        cols[2] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        dirs[2] = Direction.Down;
                                        break;
                                    case 8: cols[0] = Color.Blue;
                                        cols[1] = Color.White;
                                        cols[2] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        dirs[2] = Direction.Down;
                                        break;
                                }
                                break;
                        }
                        Faces[i, j] = new Piece(PieceKind.Corner, cols, dirs);                        
                    }
                    #endregion

                    #region Edge State

                    if (j == 1 || j == 3 || j == 5 || j == 7)
                    {
                        Color[] cols = new Color[2];
                        Direction[] dirs = new Direction[2];
                        switch (i)
                        {
                            case 0:
                                switch (j)
                                {
                                    case 1: cols[0] = Color.Red;
                                        cols[1] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Up;
                                        break;
                                    case 3: cols[0] = Color.Red;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        break;
                                    case 5: cols[0] = Color.Red;
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 7: cols[0] = Color.Red;
                                        cols[1] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Down;
                                        break;
                                }
                                break;
                            case 1: switch (j)
                                {
                                    case 1: cols[0] = Color.Yellow;
                                        cols[1] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Up;
                                        break;
                                    case 3: cols[0] = Color.Yellow;
                                        cols[1] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        break;
                                    case 5: cols[0] = Color.Yellow;
                                        cols[1] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 7: cols[0] = Color.Yellow;
                                        cols[1] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Down;
                                        break;
                                }
                                break;
                            case 2:
                                switch (j)
                                {
                                    case 1: cols[0] = Color.Orange;
                                        cols[1] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Up;
                                        break;
                                    case 3: cols[0] = Color.Orange;
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        break;
                                    case 5: cols[0] = Color.Orange;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 7: cols[0] = Color.Orange;
                                        cols[1] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Down;
                                        break;
                                }
                                break;
                            case 3: switch (j)
                                {
                                    case 1: cols[0] = Color.White;
                                        cols[1] = Color.Green;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Up;
                                        break;
                                    case 3: cols[0] = Color.White;
                                        cols[1] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        break;
                                    case 5: cols[0] = Color.White;
                                        cols[1] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 7: cols[0] = Color.White;
                                        cols[1] = Color.Blue;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Down;
                                        break;
                                }
                                break;
                            case 4: switch (j)
                                {
                                    case 1: cols[0] = Color.Green;
                                        cols[1] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Up;
                                        break;
                                    case 3: cols[0] = Color.Green;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        break;
                                    case 5: cols[0] = Color.Green;
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 7: cols[0] = Color.Green;
                                        cols[1] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Down;
                                        break;
                                }
                                break;
                            case 5: switch (j)
                                {
                                    case 1: cols[0] = Color.Blue;
                                        cols[1] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Up;
                                        break;
                                    case 3: cols[0] = Color.Blue;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
                                        break;
                                    case 5: cols[0] = Color.Blue;
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 7: cols[0] = Color.Blue;
                                        cols[1] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Down;
                                        break;
                                }
                                break;
                        }
                        Faces[i, j] = new Piece(PieceKind.Edge, cols, dirs);
                    }

                    #endregion

                    #region Center State

                    if (j == 4)
                    {
                        switch (i)
                        {
                            case 0: Faces[i, j] = new Piece(PieceKind.Center, new Color[]{Color.Red}, new Direction[]{Direction.Front});
                                break;
                            case 1: Faces[i, j] = new Piece(PieceKind.Center, new Color[] { Color.Yellow }, new Direction[] { Direction.Front });
                                break;
                            case 2: Faces[i, j] = new Piece(PieceKind.Center, new Color[] { Color.Orange }, new Direction[] { Direction.Front });
                                break;
                            case 3: Faces[i, j] = new Piece(PieceKind.Center, new Color[] { Color.White }, new Direction[] { Direction.Front });
                                break;
                            case 4: Faces[i, j] = new Piece(PieceKind.Center, new Color[] { Color.Green }, new Direction[] { Direction.Front });
                                break;
                            case 5: Faces[i, j] = new Piece(PieceKind.Center, new Color[] { Color.Blue }, new Direction[] { Direction.Front });
                                break;
                        }
                    }

                    #endregion

                    Faces[i, j].X = j % 3;
                    Faces[i, j].Y = j / 3;
                }                
            }
        }

        
        public void SetColors()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    #region Corner State
                    if (j == 0 || j == 2 || j == 6 || j == 8)
                    {
                        switch (i)
                        {
                            case 0:
                                switch (j)
                                {
                                    case 0:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 6].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 2].Colors[Direction.Front];
                                        break;
                                    case 2:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 8].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 0].Colors[Direction.Front];
                                        break;
                                    case 6:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 0].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 8].Colors[Direction.Front];
                                        break;
                                    case 8:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 2].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 6].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 1:
                                switch (j)
                                {
                                    case 0:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 0].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[2, 2].Colors[Direction.Front];
                                        break;
                                    case 2:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 6].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[0, 0].Colors[Direction.Front];
                                        break;
                                    case 6:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 6].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[2, 8].Colors[Direction.Front];
                                        break;
                                    case 8:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 0].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[0, 6].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 2:
                                switch (j)
                                {
                                    case 0:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 2].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[3, 2].Colors[Direction.Front];
                                        break;
                                    case 2:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 0].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[1, 0].Colors[Direction.Front];
                                        break;
                                    case 6:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5,8].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[3, 8].Colors[Direction.Front];
                                        break;
                                    case 8:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 6].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[1, 6].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 3:
                                switch (j)
                                {
                                    case 0:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 8].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[0, 2].Colors[Direction.Front];
                                        break;
                                    case 2:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 2].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[2, 0].Colors[Direction.Front];
                                        break;
                                    case 6:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 2].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[0, 8].Colors[Direction.Front];
                                        break;
                                    case 8:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 8].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[2, 6].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 4:
                                switch (j)
                                {
                                    case 0:
                                        Faces[i, j].Colors[Direction.Up] = Faces[2, 2].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 0].Colors[Direction.Front];
                                        break;
                                    case 2:
                                        Faces[i, j].Colors[Direction.Up] = Faces[2, 0].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 2].Colors[Direction.Front];
                                        break;
                                    case 6:
                                        Faces[i, j].Colors[Direction.Down] = Faces[0, 0].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 2].Colors[Direction.Front];
                                        break;
                                    case 8:
                                        Faces[i, j].Colors[Direction.Down] = Faces[0, 2].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 0].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 5:
                                switch (j)
                                {
                                    case 0:
                                        Faces[i, j].Colors[Direction.Up] = Faces[0, 6].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 8].Colors[Direction.Front];
                                        break;
                                    case 2:
                                        Faces[i, j].Colors[Direction.Up] = Faces[0, 8].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 6].Colors[Direction.Front];
                                        break;
                                    case 6:
                                        Faces[i, j].Colors[Direction.Down] = Faces[2, 8].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 6].Colors[Direction.Front];
                                        break;
                                    case 8:
                                        Faces[i, j].Colors[Direction.Down] = Faces[2, 6].Colors[Direction.Front];
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 8].Colors[Direction.Front];
                                        break;
                                }
                                break;
                        }
                    }
                    #endregion

                    #region Edge State

                    if (j == 1 || j == 3 || j == 5 || j == 7)
                    {
                        Color[] cols = new Color[2];
                        Direction[] dirs = new Direction[2];
                        switch (i)
                        {
                            case 0:
                                switch (j)
                                {
                                    case 1:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 7].Colors[Direction.Front];
                                        break;
                                    case 3:
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 5].Colors[Direction.Front];
                                        break;
                                    case 5:
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 3].Colors[Direction.Front];
                                        break;
                                    case 7:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 1].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 1:
                                switch (j)
                                {
                                    case 1:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 3].Colors[Direction.Front];
                                        break;
                                    case 3:
                                        Faces[i, j].Colors[Direction.Left] = Faces[2, 5].Colors[Direction.Front];
                                        break;
                                    case 5:
                                        Faces[i, j].Colors[Direction.Right] = Faces[0, 3].Colors[Direction.Front];
                                        break;
                                    case 7:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 3].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 2:
                                switch (j)
                                {
                                    case 1:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 1].Colors[Direction.Front];
                                        break;
                                    case 3:
                                        Faces[i, j].Colors[Direction.Left] = Faces[3, 5].Colors[Direction.Front];
                                        break;
                                    case 5:
                                        Faces[i, j].Colors[Direction.Right] = Faces[1, 3].Colors[Direction.Front];
                                        break;
                                    case 7:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 7].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 3:
                                switch (j)
                                {
                                    case 1:
                                        Faces[i, j].Colors[Direction.Up] = Faces[4, 5].Colors[Direction.Front];
                                        break;
                                    case 3:
                                        Faces[i, j].Colors[Direction.Left] = Faces[0, 5].Colors[Direction.Front];
                                        break;
                                    case 5:
                                        Faces[i, j].Colors[Direction.Right] = Faces[2, 3].Colors[Direction.Front];
                                        break;
                                    case 7:
                                        Faces[i, j].Colors[Direction.Down] = Faces[5, 5].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 4:
                                switch (j)
                                {
                                    case 1:
                                        Faces[i, j].Colors[Direction.Up] = Faces[2, 1].Colors[Direction.Front];
                                        break;
                                    case 3:
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 1].Colors[Direction.Front];
                                        break;
                                    case 5:
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 1].Colors[Direction.Front];
                                        break;
                                    case 7:
                                        Faces[i, j].Colors[Direction.Down] = Faces[0, 1].Colors[Direction.Front];
                                        break;
                                }
                                break;
                            case 5:
                                switch (j)
                                {
                                    case 1:
                                        Faces[i, j].Colors[Direction.Up] = Faces[0, 7].Colors[Direction.Front];
                                        break;
                                    case 3:
                                        Faces[i, j].Colors[Direction.Left] = Faces[1, 7].Colors[Direction.Front];
                                        break;
                                    case 5:
                                        Faces[i, j].Colors[Direction.Right] = Faces[3, 7].Colors[Direction.Front];
                                        break;
                                    case 7:
                                        Faces[i, j].Colors[Direction.Down] = Faces[2, 7].Colors[Direction.Front];
                                        break;
                                }
                                break;
                        }
                    }

                    #endregion
                    
                }
            }
        }

        public void Scramble()
        {
            Initialize();
            Random r = new Random();
            int lastFace = -1;
            bool lastRotation=false;
            TurnPauseOn = false;
            Dispose();
            movesHistory.Add("Start Scrambling..");
            for (int i = 0; i < Convert.ToInt32(r.Next(50, 100)); i++)
            {
                int FaceIndex=Convert.ToInt32(r.Next(0, 5));
                bool Rotation=Convert.ToBoolean(r.Next(0, 2));
                if (FaceIndex != lastFace && Rotation != !lastRotation)
                {
                    Rotate(FaceIndex, Rotation);
                    lastFace = FaceIndex;
                    lastRotation = Rotation;
                }
            }
            movesHistory.Add("End Scrambling.");
            TurnPauseOn = true;
        }

        public void Solve()
        {
            solveTHread = new Thread(new ThreadStart(Process));
            solveTHread.IsBackground = true;
            solveTHread.Start();
        }

        public void Process()
        {
            IsCubeSolved = false;
            DateTime start = DateTime.Now;
            Piece[,] PhaseOne = CloneCurrentState();
            bool IsTimeBreaked = false;
            bool IsSolved = false;
            int NumberofTrying = 0;

            while (!IsSolved)
            {
                movesHistory = new List<string>();
                movesHistory.Add("Phase One");
                #region Solve First Layer

                do
                {
                    LocalMovesCount = 0;
                    SetColors();

                    movesHistory.RemoveRange(movesHistory.Count - LocalMovesCount, LocalMovesCount);
                    LocalMovesCount = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            faces[i, j] = PhaseOne[i, j];
                        }
                    }
                    long Entering = DateTime.Now.Ticks;

                    #region Create Green Cross

                    while (!CheckGreenCross())
                    {
                        if (DateTime.Now.Ticks - Entering > 30000000)
                        {
                            IsTimeBreaked = true;
                            //break;
                        }
                        List<SearchResult> res = Search(PieceKind.Edge, Color.Green, true);
                        List<int> Indices = new List<int>();
                        for (int i = 0; i < res.Count; i++)
                        {
                            int index = (new Random()).Next(0, res.Count);
                            while (Indices.Contains(index))
                                index = (new Random()).Next(0, res.Count);
                            SearchResult item = res[index];
                            Indices.Add(index);
                            if (item.faceIndex != 4 || !(item.faceIndex == 4 &&
                                ((item.index == 1 && faces[4, 1].Colors[Direction.Up] == GetFaceColor(2)) ||
                                (item.index == 3 && faces[4, 3].Colors[Direction.Left] == GetFaceColor(1)) ||
                                (item.index == 5 && faces[4, 5].Colors[Direction.Right] == GetFaceColor(3)) ||
                                (item.index == 7 && faces[4, 7].Colors[Direction.Down] == GetFaceColor(0)))))
                            {
                                switch (item.faceIndex)
                                {
                                    case 0:
                                        switch (item.index)
                                        {
                                            case 3: Rotate(0, false);
                                                break;
                                            case 5: Rotate(0, true);
                                                break;
                                            case 7: Rotate(0, false);
                                                Rotate(0, false);
                                                break;
                                        }
                                        Color UpColor = faces[0, 1].Colors[Direction.Up];
                                        if (UpColor == Color.Red)
                                            FiULiUi();
                                        else
                                        {
                                            if (UpColor == Color.Yellow)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(1, false);
                                                Rotate(1, false);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (UpColor == Color.Orange)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(5, true);
                                                Rotate(2, false);
                                                Rotate(2, false);
                                                RotateCube(Direction.Up, true);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (UpColor == Color.White)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, false);
                                                Rotate(3, false);
                                                Rotate(3, false);
                                                RotateCube(Direction.Up, false);
                                                FiULiUi();
                                                RotateCube(Direction.Up, true);
                                            }
                                        }
                                        break;
                                    case 1: RotateCube(Direction.Up, true);
                                        switch (item.index)
                                        {
                                            case 3: Rotate(0, false);
                                                break;
                                            case 5: Rotate(0, true);
                                                break;
                                            case 7: Rotate(0, false);
                                                Rotate(0, false);
                                                break;
                                        }
                                        Color Up1Color = faces[0, 1].Colors[Direction.Up];
                                        if (Up1Color == Color.Yellow)
                                            FiULiUi();
                                        else
                                        {
                                            if (Up1Color == Color.Orange)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(1, false);
                                                Rotate(1, false);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (Up1Color == Color.White)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(5, true);
                                                Rotate(2, false);
                                                Rotate(2, false);
                                                RotateCube(Direction.Up, true);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (Up1Color == Color.Red)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, false);
                                                Rotate(3, false);
                                                Rotate(3, false);
                                                RotateCube(Direction.Up, false);
                                                FiULiUi();
                                                RotateCube(Direction.Up, true);
                                            }
                                        }
                                        RotateCube(Direction.Up, false);
                                        break;
                                    case 2: RotateCube(Direction.Up, true);
                                        RotateCube(Direction.Up, true);
                                        switch (item.index)
                                        {
                                            case 3: Rotate(0, false);
                                                break;
                                            case 5: Rotate(0, true);
                                                break;
                                            case 7: Rotate(0, false);
                                                Rotate(0, false);
                                                break;
                                        }
                                        Color Up2Color = faces[0, 1].Colors[Direction.Up];
                                        if (Up2Color == Color.Orange)
                                            FiULiUi();
                                        else
                                        {
                                            if (Up2Color == Color.White)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(1, false);
                                                Rotate(1, false);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (Up2Color == Color.Red)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(5, true);
                                                Rotate(2, false);
                                                Rotate(2, false);
                                                RotateCube(Direction.Up, true);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (Up2Color == Color.Yellow)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, false);
                                                Rotate(3, false);
                                                Rotate(3, false);
                                                RotateCube(Direction.Up, false);
                                                FiULiUi();
                                                RotateCube(Direction.Up, true);
                                            }
                                        }
                                        RotateCube(Direction.Up, false);
                                        RotateCube(Direction.Up, false);
                                        break;
                                    case 3: RotateCube(Direction.Up, false);
                                        switch (item.index)
                                        {
                                            case 3: Rotate(0, false);
                                                break;
                                            case 5: Rotate(0, true);
                                                break;
                                            case 7: Rotate(0, false);
                                                Rotate(0, false);
                                                break;
                                        }
                                        Color Up3Color = faces[0, 1].Colors[Direction.Up];
                                        if (Up3Color == Color.White)
                                            FiULiUi();
                                        else
                                        {
                                            if (Up3Color == Color.Red)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(1, false);
                                                Rotate(1, false);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (Up3Color == Color.Yellow)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, true);
                                                Rotate(5, true);
                                                Rotate(2, false);
                                                Rotate(2, false);
                                                RotateCube(Direction.Up, true);
                                                RotateCube(Direction.Up, true);
                                                FiULiUi();
                                                RotateCube(Direction.Up, false);
                                                RotateCube(Direction.Up, false);
                                            }
                                            if (Up3Color == Color.Orange)
                                            {
                                                Rotate(0, false);
                                                Rotate(0, false);
                                                Rotate(5, false);
                                                Rotate(3, false);
                                                Rotate(3, false);
                                                RotateCube(Direction.Up, false);
                                                FiULiUi();
                                                RotateCube(Direction.Up, true);
                                            }
                                        }
                                        RotateCube(Direction.Up, true);
                                        break;
                                    case 4:
                                        Color Up4Color = Color.Black;
                                        switch (item.index)
                                        {
                                            case 1: Up4Color = faces[4, 1].Colors[Direction.Up];
                                                if (Up4Color == Color.Red)
                                                {
                                                    Rotate(4, false);
                                                    Rotate(4, false);
                                                }
                                                if (Up4Color == Color.Yellow)
                                                    Rotate(4, true);
                                                if (Up4Color == Color.White)
                                                    Rotate(4, false);
                                                break;
                                            case 3: Up4Color = faces[4, 3].Colors[Direction.Left];
                                                if (Up4Color == Color.White)
                                                {
                                                    Rotate(4, false);
                                                    Rotate(4, false);
                                                }
                                                if (Up4Color == Color.Red)
                                                    Rotate(4, true);
                                                if (Up4Color == Color.Orange)
                                                    Rotate(4, false);
                                                break;
                                            case 5: Up4Color = faces[4, 5].Colors[Direction.Right];
                                                if (Up4Color == Color.Yellow)
                                                {
                                                    Rotate(4, false);
                                                    Rotate(4, false);
                                                }
                                                if (Up4Color == Color.Orange)
                                                    Rotate(4, true);
                                                if (Up4Color == Color.Red)
                                                    Rotate(4, false);
                                                break;
                                            case 7: Up4Color = faces[4, 7].Colors[Direction.Down];
                                                if (Up4Color == Color.Orange)
                                                {
                                                    Rotate(4, false);
                                                    Rotate(4, false);
                                                }
                                                if (Up4Color == Color.White)
                                                    Rotate(4, true);
                                                if (Up4Color == Color.Yellow)
                                                    Rotate(4, false);
                                                break;
                                        }
                                        break;
                                    case 5: Color Up5Color = Color.Black;
                                        switch (item.index)
                                        {
                                            case 1: Up5Color = faces[5, 1].Colors[Direction.Up];
                                                if (Up5Color == Color.Yellow)
                                                {
                                                    Rotate(5, true);
                                                    Rotate(1, false);
                                                    Rotate(1, false);
                                                }
                                                if (Up5Color == Color.Orange)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(5, false);
                                                    Rotate(2, false);
                                                    Rotate(2, false);
                                                }
                                                if (Up5Color == Color.White)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(3, false);
                                                    Rotate(3, false);
                                                }
                                                if (Up5Color == Color.Red)
                                                {
                                                    Rotate(0, false);
                                                    Rotate(0, false);
                                                }
                                                break;
                                            case 3: Up5Color = faces[5, 3].Colors[Direction.Left];
                                                if (Up5Color == Color.Yellow)
                                                {
                                                    Rotate(1, false);
                                                    Rotate(1, false);
                                                }
                                                if (Up5Color == Color.Orange)
                                                {
                                                    Rotate(5, true);
                                                    Rotate(2, false);
                                                    Rotate(2, false);
                                                }
                                                if (Up5Color == Color.White)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(5, false);
                                                    Rotate(3, false);
                                                    Rotate(3, false);
                                                }
                                                if (Up5Color == Color.Red)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(0, false);
                                                    Rotate(0, false);
                                                }
                                                break;
                                            case 5: Up5Color = faces[5, 5].Colors[Direction.Right];
                                                if (Up5Color == Color.Yellow)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(5, false);
                                                    Rotate(1, false);
                                                    Rotate(1, false);
                                                }
                                                if (Up5Color == Color.Orange)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(2, false);
                                                    Rotate(2, false);
                                                }
                                                if (Up5Color == Color.White)
                                                {
                                                    Rotate(3, false);
                                                    Rotate(3, false);
                                                }
                                                if (Up5Color == Color.Red)
                                                {
                                                    Rotate(5, true);
                                                    Rotate(0, false);
                                                    Rotate(0, false);
                                                }
                                                break;
                                            case 7: Up5Color = faces[5, 7].Colors[Direction.Down];
                                                if (Up5Color == Color.Yellow)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(1, false);
                                                    Rotate(1, false);
                                                }
                                                if (Up5Color == Color.Orange)
                                                {
                                                    Rotate(2, false);
                                                    Rotate(2, false);
                                                }
                                                if (Up5Color == Color.White)
                                                {
                                                    Rotate(5, true);
                                                    Rotate(3, false);
                                                    Rotate(3, false);
                                                }
                                                if (Up5Color == Color.Red)
                                                {
                                                    Rotate(5, false);
                                                    Rotate(5, false);
                                                    Rotate(0, false);
                                                    Rotate(0, false);
                                                }
                                                break;
                                        }
                                        break;
                                }
                                break;
                            }
                        }
                    }

                    #endregion
                }
                while (movesHistory.Count > 340);

                Piece[,] PhaseTwo = CloneCurrentState();
                int CurrentSteps = movesHistory.Count;
                do
                {
                    movesHistory.RemoveRange(CurrentSteps, movesHistory.Count - CurrentSteps);
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            faces[i, j] = PhaseTwo[i, j];
                        }
                    }

                    LocalMovesCount = 0;
                    #region Adjust Green Corners

                    NumberofTrying = 0;
                    while (!CheckUpGreenFace())
                    {
                        movesHistory.RemoveRange(movesHistory.Count - LocalMovesCount, LocalMovesCount);
                        LocalMovesCount = 0;
                        if (NumberofTrying == 30)
                            break;
                        NumberofTrying++;
                        bool IsBreak = true;
                        List<SearchResult> result = Search(PieceKind.Corner, Color.Green, true);
                        List<int> Indices = new List<int>();
                        for (int i = 0; i < result.Count; i++)
                        {
                            IsBreak = true;
                            int index = (new Random()).Next(0, result.Count);
                            while (Indices.Contains(index))
                                index = (new Random()).Next(0, result.Count);
                            SearchResult item = result[index];
                            Indices.Add(index);

                            Color FirstColor = Color.Black;
                            Color SecondColor = Color.Black;
                            if (item.faceIndex == 0 || item.faceIndex == 1 || item.faceIndex == 2 ||
                                item.faceIndex == 3)
                            {
                                if (item.y == 0)
                                {
                                    switch (item.faceIndex)
                                    {
                                        case 0:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[0, 0].Colors[Direction.Up];
                                                SecondColor = faces[0, 0].Colors[Direction.Left];
                                                if ((FirstColor == Color.Red && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Red))
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Yellow &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Red))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                }
                                                else
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                }
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[0, 2].Colors[Direction.Up];
                                                SecondColor = faces[0, 2].Colors[Direction.Right];
                                                if ((FirstColor == Color.Red && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Red))
                                                {
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Red &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.White))
                                                        RiDiRD();
                                                }
                                                else
                                                {
                                                    RiDiRD();
                                                }
                                            }
                                            break;
                                        case 1:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[1, 0].Colors[Direction.Up];
                                                SecondColor = faces[1, 0].Colors[Direction.Left];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Orange &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Yellow))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                }
                                                else
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                }
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[1, 2].Colors[Direction.Up];
                                                SecondColor = faces[1, 2].Colors[Direction.Right];
                                                if ((FirstColor == Color.Red && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Red))
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Yellow &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Red))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                }
                                                else
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                }
                                            }
                                            break;
                                        case 2:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[2, 0].Colors[Direction.Up];
                                                SecondColor = faces[2, 0].Colors[Direction.Left];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.White &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Orange))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                }
                                                else
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                }
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[2, 2].Colors[Direction.Up];
                                                SecondColor = faces[2, 2].Colors[Direction.Right];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Orange &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Yellow))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                }
                                                else
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                }
                                            }
                                            break;
                                        case 3:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[3, 0].Colors[Direction.Up];
                                                SecondColor = faces[3, 0].Colors[Direction.Left];
                                                if ((FirstColor == Color.Red && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Red))
                                                {
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Red &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.White))
                                                        RiDiRD();
                                                }
                                                else
                                                    RiDiRD();
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[3, 2].Colors[Direction.Up];
                                                SecondColor = faces[3, 2].Colors[Direction.Right];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.White &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Orange))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                }
                                                else
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (item.y == 2)
                                {
                                    switch (item.faceIndex)
                                    {
                                        case 0:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[0, 6].Colors[Direction.Down];
                                                SecondColor = faces[0, 6].Colors[Direction.Left];
                                                if ((FirstColor == Color.Red && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Red))
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Yellow &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Red))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                }
                                                else
                                                {
                                                    /*
                                                    RotateCube(Direction.Up, true);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                     */
                                                    Rotate(5, false);
                                                }
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[0, 8].Colors[Direction.Down];
                                                SecondColor = faces[0, 8].Colors[Direction.Right];
                                                if ((FirstColor == Color.Red && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Red))
                                                {
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Red &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.White))
                                                        RiDiRD();
                                                }
                                                else
                                                    //RiDiRD();
                                                    Rotate(5, false);
                                            }
                                            break;
                                        case 1:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[1, 6].Colors[Direction.Down];
                                                SecondColor = faces[1, 6].Colors[Direction.Left];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Orange &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Yellow))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                }
                                                else
                                                {
                                                    /*
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                     */
                                                    Rotate(5, false);
                                                }
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[1, 8].Colors[Direction.Down];
                                                SecondColor = faces[1, 8].Colors[Direction.Right];
                                                if ((FirstColor == Color.Red && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Red))
                                                {
                                                    RotateCube(Direction.Up, true);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Yellow &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Red))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                }
                                                else
                                                {
                                                    /*
                                                    RotateCube(Direction.Up, true);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, false);
                                                     */
                                                    Rotate(5, false);
                                                }
                                            }
                                            break;
                                        case 2:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[2, 6].Colors[Direction.Down];
                                                SecondColor = faces[2, 6].Colors[Direction.Left];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.White &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Orange))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                }
                                                else
                                                {
                                                    /*
                                                    RotateCube(Direction.Up, false);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                     */
                                                    Rotate(5, false);
                                                }
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[2, 8].Colors[Direction.Down];
                                                SecondColor = faces[2, 8].Colors[Direction.Right];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.Yellow) ||
                                                    (FirstColor == Color.Yellow && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Orange &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Yellow))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                }
                                                else
                                                {
                                                    /*
                                                    RotateCube(Direction.Up, false);
                                                    RotateCube(Direction.Up, false);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                    RotateCube(Direction.Up, true);
                                                     */
                                                    Rotate(5, false);
                                                }
                                            }
                                            break;
                                        case 3:
                                            if (item.x == 0)
                                            {
                                                FirstColor = faces[3, 6].Colors[Direction.Down];
                                                SecondColor = faces[3, 6].Colors[Direction.Left];
                                                if ((FirstColor == Color.Red && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Red))
                                                {
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Red &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.White))
                                                        RiDiRD();
                                                }
                                                else
                                                    //RiDiRD();
                                                    Rotate(5, false);
                                            }
                                            if (item.x == 2)
                                            {
                                                FirstColor = faces[3, 8].Colors[Direction.Down];
                                                SecondColor = faces[3, 8].Colors[Direction.Right];
                                                if ((FirstColor == Color.Orange && SecondColor == Color.White) ||
                                                    (FirstColor == Color.White && SecondColor == Color.Orange))
                                                {
                                                    RotateCube(Direction.Up, false);
                                                    while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.White &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Orange))
                                                        RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                }
                                                else
                                                {
                                                    /*
                                                    RotateCube(Direction.Up, false);
                                                    RiDiRD();
                                                    RotateCube(Direction.Up, true);
                                                     */
                                                    Rotate(5, false);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            if (item.faceIndex == 4)
                            {
                                switch (item.index)
                                {
                                    case 0: if (!(faces[4, 0].Colors[Direction.Up] == Color.Orange &&
                                         faces[4, 0].Colors[Direction.Left] == Color.Yellow))
                                        {
                                            RotateCube(Direction.Up, false);
                                            RotateCube(Direction.Up, false);
                                            RiDiRD();
                                            RotateCube(Direction.Up, true);
                                            RotateCube(Direction.Up, true);
                                        }
                                        else
                                            IsBreak = false;
                                        break;
                                    case 2: if (!(faces[4, 2].Colors[Direction.Up] == Color.Orange &&
                                          faces[4, 2].Colors[Direction.Right] == Color.White))
                                        {
                                            RotateCube(Direction.Up, false);
                                            RiDiRD();
                                            RotateCube(Direction.Up, true);
                                        }
                                        else
                                            IsBreak = false;
                                        break;
                                    case 6:
                                        if (!(faces[4, 6].Colors[Direction.Down] == Color.Red &&
                                         faces[4, 6].Colors[Direction.Left] == Color.Yellow))
                                        {
                                            RotateCube(Direction.Up, true);
                                            RiDiRD();
                                            RotateCube(Direction.Up, false);
                                        }
                                        else
                                            IsBreak = false;
                                        break;
                                    case 8:
                                        if (!(faces[4, 8].Colors[Direction.Down] == Color.Red &&
                                         faces[4, 8].Colors[Direction.Right] == Color.White))
                                        {
                                            RiDiRD();
                                        }
                                        else
                                            IsBreak = false;
                                        break;
                                }
                            }
                            if (item.faceIndex == 5)
                            {
                                Color FColor = Color.Black;
                                Color SColor = Color.Black;

                                switch (item.index)
                                {
                                    case 0: FColor = faces[5, 0].Colors[Direction.Up];
                                        SColor = faces[5, 0].Colors[Direction.Left];
                                        if ((FColor == Color.Red && SColor == Color.Yellow) ||
                                            (FColor == Color.Yellow && SColor == Color.Red))
                                        {
                                            RotateCube(Direction.Up, true);
                                            while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Yellow &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Red))
                                                RiDiRD();
                                            RotateCube(Direction.Up, false);
                                        }
                                        else
                                            Rotate(5, false);
                                        break;
                                    case 2: FColor = faces[5, 2].Colors[Direction.Up];
                                        SColor = faces[5, 2].Colors[Direction.Right];
                                        if ((FColor == Color.Red && SColor == Color.White) ||
                                            (FColor == Color.White && SColor == Color.Red))
                                        {
                                            while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Red &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.White))
                                                RiDiRD();
                                        }
                                        else
                                            Rotate(5, false);
                                        break;
                                    case 6: FColor = faces[5, 6].Colors[Direction.Down];
                                        SColor = faces[5, 6].Colors[Direction.Left];
                                        if ((FColor == Color.Yellow && SColor == Color.Orange) ||
                                            (FColor == Color.Orange && SColor == Color.Yellow))
                                        {
                                            RotateCube(Direction.Up, true);
                                            RotateCube(Direction.Up, true);
                                            while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.Orange &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Yellow))
                                                RiDiRD();
                                            RotateCube(Direction.Up, false);
                                            RotateCube(Direction.Up, false);
                                        }
                                        else
                                            Rotate(5, false);
                                        break;
                                    case 8: FColor = faces[5, 8].Colors[Direction.Down];
                                        SColor = faces[5, 8].Colors[Direction.Right];
                                        if ((FColor == Color.White && SColor == Color.Orange) ||
                                            (FColor == Color.Orange && SColor == Color.White))
                                        {
                                            RotateCube(Direction.Up, false);
                                            while (!(faces[4, 8].Colors[Direction.Front] == Color.Green &&
                                                        faces[0, 2].Colors[Direction.Front] == Color.White &&
                                                        faces[3, 0].Colors[Direction.Front] == Color.Orange))
                                                RiDiRD();
                                            RotateCube(Direction.Up, true);
                                        }
                                        else
                                            Rotate(5, false);
                                        break;
                                }

                            }
                            if (IsBreak)
                                break;
                        }
                    }
                    if (NumberofTrying == 20)
                        continue;
                    #endregion
                }
                while (movesHistory.Count - CurrentSteps > 250);

                #endregion
                SetColors();
                movesHistory.Add("Phase Two");
                #region Solve Middle Layer

                bool isComplete = true;
                RotateCube(Direction.Front, false);
                RotateCube(Direction.Front, false);
                LocalMovesCount = 0;
                for (int i = 0; i < 4; i++)
                {
                    Color currentFaceColor = GetFaceColor(i);
                    if (faces[i, 3].Colors[Direction.Front] != currentFaceColor || faces[i, 5].Colors[Direction.Front] != currentFaceColor)
                    {
                        isComplete = false;
                        break;
                    }
                }
                NumberofTrying = 0;
                while (!isComplete)
                {
                    movesHistory.RemoveRange(movesHistory.Count - LocalMovesCount, LocalMovesCount);
                    LocalMovesCount = 0;
                    if (NumberofTrying == 1000)
                        break;
                    NumberofTrying++;
                    //Get Non-Top Pieces
                    List<SearchResult> searchResult = SearchNotIncluded(PieceKind.Edge, Color.Blue);
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        if (searchResult[i].y != 0 || searchResult[i].faceIndex > 3)
                        {
                            searchResult.RemoveAt(i);
                            i--;
                        }
                    }
                    if (searchResult.Count == 0)
                    {
                        int val = (new Random()).Next(1, 3);
                        if (val == 1)
                            UiLiULUFUiFi();
                        else
                            URUiRiUiFiUF();
                        searchResult = SearchNotIncluded(PieceKind.Edge, Color.Blue);
                        for (int i = 0; i < searchResult.Count; i++)
                        {
                            if (searchResult[i].y != 0 || searchResult[i].faceIndex > 3)
                            {
                                searchResult.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    foreach (SearchResult item in searchResult)
                    {
                        Color frontColor = faces[item.faceIndex, item.index].Colors[Direction.Front];
                        Color TopColor = faces[item.faceIndex, item.index].Colors[Direction.Up];
                        for (int i = 0; i < item.faceIndex; i++)
                        {
                            RotateCube(Direction.Up, true);
                        }
                        int count = 0;
                        while (frontColor != GetFaceColor(0))
                        {
                            Rotate(4, false);
                            RotateCube(Direction.Up, true);
                            count++;
                            if (count == 4)
                                break;
                        }
                        if (TopColor == GetFaceColor(1))
                            UiLiULUFUiFi();
                        if (TopColor == GetFaceColor(3))
                            URUiRiUiFiUF();
                    }

                    #region Check Second Layer Completion

                    isComplete = true;
                    for (int i = 0; i < 4; i++)
                    {
                        Color currentFaceColor = GetFaceColor(i);
                        if (faces[i, 3].Colors[Direction.Front] != currentFaceColor || faces[i, 5].Colors[Direction.Front] != currentFaceColor)
                        {
                            isComplete = false;
                            break;
                        }
                    }
                }
                if (NumberofTrying == 20)
                    continue;
                #endregion

                #endregion
                SetColors();
                movesHistory.Add("Phase Three");
                #region Solve Third and Last Layer

                Piece[,] PhaseThree = CloneCurrentState();
                CurrentSteps = movesHistory.Count;

                //Look for Top L or Straight Line and Check Top Cross
                bool DoItAgain = true;
                NumberofTrying = 0;
                Color Top_Color = GetFaceColor(4);
                LocalMovesCount = 0;
                //break;
                do
                {
                    movesHistory.RemoveRange(movesHistory.Count - LocalMovesCount, LocalMovesCount);
                    LocalMovesCount = 0;
                    if (NumberofTrying == 20)
                        break;
                    NumberofTrying++;
                    for (int i = 0; i < 4; i++)
                    {
                        if ((faces[4, 1].Colors[Direction.Front] == Top_Color &&
                        faces[4, 3].Colors[Direction.Front] == Top_Color &&
                        faces[4, 4].Colors[Direction.Front] == Top_Color) ||
                        (faces[4, 3].Colors[Direction.Front] == Top_Color &&
                        faces[4, 4].Colors[Direction.Front] == Top_Color &&
                        faces[4, 5].Colors[Direction.Front] == Top_Color))
                        {
                            FRURiUiFi();
                            if (CheckTopCross())
                            {
                                DoItAgain = false;
                                break;
                            }
                            FRURiUiFi();
                            if (CheckTopCross())
                            {
                                DoItAgain = false;
                                break;
                            }
                        }
                        else
                            RotateCube(Direction.Up, false);
                    }
                    if (DoItAgain)
                    {
                        //movesHistory.RemoveRange(CurrentSteps, movesHistory.Count - CurrentSteps);
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                faces[i, j] = PhaseThree[i, j];
                            }
                        }
                        int ran = (new Random()).Next(1, 5);
                        for (int i = 0; i < ran; i++)
                        {
                            RotateCube(Direction.Up, false);
                        }
                        FRURiUiFi();
                    }
                } while (DoItAgain);
                if (NumberofTrying == 20)
                    continue;
                //IsSolved = true;
                
                //Look for edge color
                bool edge_ok = false;
                NumberofTrying = 0;
                LocalMovesCount = 0;
                while (!edge_ok)
                {
                    movesHistory.RemoveRange(movesHistory.Count - LocalMovesCount, LocalMovesCount);
                    LocalMovesCount = 0;
                    if (NumberofTrying == 20)
                        break;
                    NumberofTrying++;
                    for (int i = 0; i < 4; i++)
                    {
                        bool UpOK = false;
                        bool RightOK = false;
                        bool LeftOK = false;
                        bool DownOK = false;

                        Color col_up = faces[4, 1].Colors[Direction.Up];
                        Color Up_Face = GetFaceColor(2);
                        if (col_up == Up_Face)
                            UpOK = true;

                        Color col_Right = faces[4, 5].Colors[Direction.Right];
                        Color Right_Face = GetFaceColor(3);
                        if (col_Right == Right_Face)
                            RightOK = true;

                        Color col_Left = faces[4, 3].Colors[Direction.Left];
                        Color Left_Face = GetFaceColor(1);
                        if (col_Left == Left_Face)
                            LeftOK = true;

                        Color col_Down = faces[4, 7].Colors[Direction.Down];
                        Color Down_Face = GetFaceColor(0);
                        if (col_Down == Down_Face)
                            DownOK = true;
                        if (!((UpOK && RightOK) || (UpOK && DownOK)))
                        {
                            if (RightOK && DownOK)
                                RotateCube(Direction.Up, true);
                            else
                            {
                                if (DownOK && LeftOK)
                                {
                                    RotateCube(Direction.Up, true);
                                    RotateCube(Direction.Up, true);
                                }
                                else
                                {
                                    if (LeftOK && UpOK)
                                        RotateCube(Direction.Up, false);
                                    else
                                    {
                                        if (LeftOK && RightOK)
                                            RotateCube(Direction.Up, true);
                                    }
                                }
                            }
                        }
                        RURiURUURi();
                        if (!CheckValidTopCross())
                            Rotate(4, false);//Additional Up
                        else
                        {
                            edge_ok = true;
                            break;
                        }
                        if (CheckValidTopCross())
                        {
                            edge_ok = true;
                            break;
                        }
                    }
                    if (!edge_ok)
                    {
                        RURiURUURi();
                    }
                }
                if (NumberofTrying == 20)
                    continue;
                //
                
                NumberofTrying = 0;
                LocalMovesCount = 0;
                //search for good corner
                while (!CheckTopCorners())
                {
                    movesHistory.RemoveRange(movesHistory.Count - LocalMovesCount, LocalMovesCount);
                    LocalMovesCount = 0;
                    if (NumberofTrying == 20)
                        break;
                    NumberofTrying++;
                    SetColors();
                    if (((faces[4, 0].Colors[Direction.Up] == GetFaceColor(2) || faces[4, 0].Colors[Direction.Up] == GetFaceColor(1) || faces[4, 0].Colors[Direction.Up] == GetFaceColor(4)) &&
                    (faces[4, 0].Colors[Direction.Left] == GetFaceColor(2) || faces[4, 0].Colors[Direction.Left] == GetFaceColor(1) || faces[4, 0].Colors[Direction.Left] == GetFaceColor(4)) &&
                    (faces[4, 0].Colors[Direction.Front] == GetFaceColor(2) || faces[4, 0].Colors[Direction.Front] == GetFaceColor(1) || faces[4, 0].Colors[Direction.Front] == GetFaceColor(4))))
                    {
                        RotateCube(Direction.Up, false);
                        RotateCube(Direction.Up, false);
                        URUiLiURiUiL();
                        continue;
                    }
                    if (((faces[4, 2].Colors[Direction.Up] == GetFaceColor(2) || faces[4, 2].Colors[Direction.Up] == GetFaceColor(3) || faces[4, 2].Colors[Direction.Up] == GetFaceColor(4)) &&
                    (faces[4, 2].Colors[Direction.Right] == GetFaceColor(2) || faces[4, 2].Colors[Direction.Right] == GetFaceColor(3) || faces[4, 2].Colors[Direction.Right] == GetFaceColor(4)) &&
                    (faces[4, 2].Colors[Direction.Front] == GetFaceColor(2) || faces[4, 2].Colors[Direction.Front] == GetFaceColor(3) || faces[4, 2].Colors[Direction.Front] == GetFaceColor(4))))
                    {
                        RotateCube(Direction.Up, false);
                        URUiLiURiUiL();
                        continue;
                    }
                    if (((faces[4, 6].Colors[Direction.Down] == GetFaceColor(0) || faces[4, 6].Colors[Direction.Down] == GetFaceColor(1) || faces[4, 6].Colors[Direction.Down] == GetFaceColor(4)) &&
                    (faces[4, 6].Colors[Direction.Left] == GetFaceColor(0) || faces[4, 6].Colors[Direction.Left] == GetFaceColor(1) || faces[4, 6].Colors[Direction.Left] == GetFaceColor(4)) &&
                    (faces[4, 6].Colors[Direction.Front] == GetFaceColor(0) || faces[4, 6].Colors[Direction.Front] == GetFaceColor(1) || faces[4, 6].Colors[Direction.Front] == GetFaceColor(4))))
                    {
                        RotateCube(Direction.Up, true);
                        URUiLiURiUiL();
                        continue;
                    }
                    if (((faces[4, 8].Colors[Direction.Down] == GetFaceColor(0) || faces[4, 8].Colors[Direction.Down] == GetFaceColor(1) || faces[4, 8].Colors[Direction.Down] == GetFaceColor(4)) &&
                    (faces[4, 8].Colors[Direction.Right] == GetFaceColor(0) || faces[4, 8].Colors[Direction.Right] == GetFaceColor(1) || faces[4, 8].Colors[Direction.Right] == GetFaceColor(4)) &&
                    (faces[4, 8].Colors[Direction.Front] == GetFaceColor(0) || faces[4, 8].Colors[Direction.Front] == GetFaceColor(1) || faces[4, 8].Colors[Direction.Front] == GetFaceColor(4))))
                    {
                        URUiLiURiUiL();
                        continue;
                    }
                    RotateCube(Direction.Up, false);
                    if(NumberofTrying%4==0)
                        URUiLiURiUiL();

                }
                if (NumberofTrying == 20)
                    continue;
                
                while (!CheckTop())
                {
                    while (faces[4, 8].Colors[Direction.Front] != GetFaceColor(4))
                        RiDiRD();
                    Rotate(4, true);
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!CheckAllCube())
                        Rotate(4, true);
                }

                if (!CheckAllCube())
                {
                    movesHistory.RemoveRange(0, movesHistory.Count);
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            faces[i, j] = PhaseOne[i, j];
                        }
                    }
                    //System.Windows.Forms.MessageBox.Show("Trying Again..");
                }
                else
                    IsSolved = true;

                
                #endregion
                SetColors();
            }
            TimeSpan ellapse = DateTime.Now - start;
            status.Text = "Solved using "+movesHistory.Count+" steps, in " + ellapse.Seconds + " seconds and " + ellapse.Milliseconds + " milliseconds.";
            IsCubeSolved = true;
            //Optimize Result Log
            for (int i = 0; i < movesHistory.Count - 4; i++)
            {
                if (movesHistory[i].Equals(movesHistory[i + 1]) &&
                    movesHistory[i].Equals(movesHistory[i + 2]) &&
                    movesHistory[i].Equals(movesHistory[i + 3]))
                    movesHistory.RemoveRange(i + 1, 3);
            }

        }

        #region Miscs

        private List<SearchResult> Search(PieceKind kind,Color col,bool ColorIncluded)
        {
            List<SearchResult> sr = new List<SearchResult>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (ColorIncluded)
                    {
                        if (faces[i, j].Kind == kind &&
                            faces[i, j].Colors.Contains(new KeyValuePair<Direction, Color>(Direction.Front, col)))
                        {
                            SearchResult newSr = new SearchResult();
                            newSr.faceIndex = i;
                            newSr.index = j;
                            newSr.x = faces[i, j].X;
                            newSr.y = faces[i, j].Y;
                            sr.Add(newSr);
                        }
                    }
                    else
                    {
                        if (faces[i, j].Kind == kind &&
                            !faces[i, j].Colors.Contains(new KeyValuePair<Direction, Color>(Direction.Front, col)))
                        {
                            SearchResult newSr = new SearchResult();
                            newSr.faceIndex = i;
                            newSr.index = j;
                            newSr.x = faces[i, j].X;
                            newSr.y = faces[i, j].Y;
                            sr.Add(newSr);
                        }
                    }
                }
            }
            return sr;
        }

        private List<SearchResult> SearchNotIncluded(PieceKind kind, Color col)
        {
            List<SearchResult> sr = new List<SearchResult>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (faces[i, j].Kind == kind &&
                            !faces[i, j].Colors.Values.Contains(col))
                    {
                        SearchResult newSr = new SearchResult();
                        newSr.faceIndex = i;
                        newSr.index = j;
                        newSr.x = faces[i, j].X;
                        newSr.y = faces[i, j].Y;
                        sr.Add(newSr);
                    }
                }
            }
            return sr;
        }

        private Color GetFaceColor(int faceIndex)
        {
            return faces[faceIndex, 4].Colors[Direction.Front];
        }

        private Piece[,] CloneCurrentState()
        {
            Piece[,] Temp = new Piece[6, 9];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Temp[i, j] = faces[i, j].Clone();
                }
            }
            return Temp;
        }

        private bool CheckGreenCross()
        {
            if (faces[4, 1].Colors[Direction.Front] == Color.Green &&
                faces[4, 3].Colors[Direction.Front] == Color.Green &&
                faces[4, 5].Colors[Direction.Front] == Color.Green &&
                faces[4, 4].Colors[Direction.Front] == Color.Green &&
                faces[4, 7].Colors[Direction.Front] == Color.Green)
                return true;
            return false;
        }

        private bool CheckTopCross()
        {
            Color TopColor = GetFaceColor(4);
            if (faces[4, 1].Colors[Direction.Front] == TopColor &&
                faces[4, 3].Colors[Direction.Front] == TopColor &&
                faces[4, 5].Colors[Direction.Front] == TopColor &&
                faces[4, 4].Colors[Direction.Front] == TopColor &&
                faces[4, 7].Colors[Direction.Front] == TopColor)
                return true;
            return false;
        }

        private bool CheckValidTopCross()
        {
            if (faces[4, 1].Colors[Direction.Up] == GetFaceColor(2) &&
                faces[4, 3].Colors[Direction.Left] == GetFaceColor(1) &&
                faces[4, 5].Colors[Direction.Right] == GetFaceColor(3) &&
                faces[4, 7].Colors[Direction.Down] == GetFaceColor(0))
                return true;
            return false;
        }

        private bool CheckTopCorners()
        {
            if (((faces[4, 0].Colors[Direction.Up] == GetFaceColor(2) || faces[4, 0].Colors[Direction.Up] == GetFaceColor(1) || faces[4, 0].Colors[Direction.Up] ==GetFaceColor(4)) &&
                (faces[4, 0].Colors[Direction.Left] == GetFaceColor(2) || faces[4, 0].Colors[Direction.Left] == GetFaceColor(1) || faces[4, 0].Colors[Direction.Left] == GetFaceColor(4)) &&
                (faces[4, 0].Colors[Direction.Front] == GetFaceColor(2) || faces[4, 0].Colors[Direction.Front] == GetFaceColor(1) || faces[4, 0].Colors[Direction.Front] == GetFaceColor(4))) &&
                ((faces[4, 2].Colors[Direction.Up] == GetFaceColor(2) || faces[4, 2].Colors[Direction.Up] == GetFaceColor(3) || faces[4, 2].Colors[Direction.Up] == GetFaceColor(4)) &&
                (faces[4, 2].Colors[Direction.Right] == GetFaceColor(2) || faces[4, 2].Colors[Direction.Right] == GetFaceColor(3) || faces[4, 2].Colors[Direction.Right] == GetFaceColor(4)) &&
                (faces[4, 2].Colors[Direction.Front] == GetFaceColor(2) || faces[4, 2].Colors[Direction.Front] == GetFaceColor(3) || faces[4, 2].Colors[Direction.Front] == GetFaceColor(4))) &&
                ((faces[4, 6].Colors[Direction.Down] == GetFaceColor(0) || faces[4, 6].Colors[Direction.Down] == GetFaceColor(1) || faces[4, 6].Colors[Direction.Down] == GetFaceColor(4)) &&
                (faces[4, 6].Colors[Direction.Left] == GetFaceColor(0) || faces[4, 6].Colors[Direction.Left] == GetFaceColor(1) || faces[4, 6].Colors[Direction.Left] == GetFaceColor(4)) &&
                (faces[4, 6].Colors[Direction.Front] == GetFaceColor(0) || faces[4, 6].Colors[Direction.Front] == GetFaceColor(1) || faces[4, 6].Colors[Direction.Front] == GetFaceColor(4))) &&
                ((faces[4, 8].Colors[Direction.Down] == GetFaceColor(0) || faces[4, 8].Colors[Direction.Down] == GetFaceColor(3) || faces[4, 8].Colors[Direction.Down] == GetFaceColor(4)) &&
                (faces[4, 8].Colors[Direction.Right] == GetFaceColor(0) || faces[4, 8].Colors[Direction.Right] == GetFaceColor(3) || faces[4, 8].Colors[Direction.Right] == GetFaceColor(4)) &&
                (faces[4, 8].Colors[Direction.Front] == GetFaceColor(0) || faces[4, 8].Colors[Direction.Front] == GetFaceColor(3) || faces[4, 8].Colors[Direction.Front] == GetFaceColor(4))))
                return true;
            return false;
        }

        private bool CheckTop()
        {
            Color TopColor=GetFaceColor(4);
            for (int i = 0; i < 9; i++)
            {
                if (faces[4, i].Colors[Direction.Front] != TopColor)
                    return false;
            }
            return true;
        }

        private bool CheckAllCube()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (faces[i, j].Colors[Direction.Front] != GetFaceColor(i))
                        return false;
                }
            }
            return true;
        }

        private bool CheckUpGreenFace()
        {
            for (int i = 0; i < 9; i++)
            {
                if (faces[4, i].Colors[Direction.Front] != Color.Green)
                    return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (faces[0, 1].Colors[Direction.Front] == Color.Red &&
                    faces[1, 1].Colors[Direction.Front] == Color.Yellow &&
                    faces[2, 1].Colors[Direction.Front] == Color.Orange &&
                    faces[3, 1].Colors[Direction.Front] == Color.White)
                    break;
                else
                    Rotate(4, false);
            }
            return true;
        }

        #endregion

        #region Sequences

        private void FiULiUi()
        {
            Rotate(0, true);
            Rotate(4, false);
            Rotate(1, true);
            Rotate(4, true);
        }

        private void RiDiRD()
        {
            Rotate(3, true);
            Rotate(5, true);
            Rotate(3, false);
            Rotate(5, false);
        }

        //Move To Right
        private void URUiRiUiFiUF()
        {
            Rotate(4, false);
            Rotate(3, false);
            Rotate(4, true);
            Rotate(3, true);
            Rotate(4, true);
            Rotate(0, true);
            Rotate(4, false);
            Rotate(0, false);
        }

        //Move To Left
        private void UiLiULUFUiFi()
        {
            Rotate(4, true);
            Rotate(1, true);
            Rotate(4, false);
            Rotate(1, false);
            Rotate(4, false);
            Rotate(0, false);
            Rotate(4, true);
            Rotate(0, true);
        }

        private void FRURiUiFi()//Top Cross
        {
            Rotate(0, false);
            Rotate(3, false);
            Rotate(4, false);
            Rotate(3, true);
            Rotate(4, true);
            Rotate(0, true);
        }

        private void RURiURUURi()//Alignment
        {
            Rotate(3, false);
            Rotate(4, false);
            Rotate(3, true);
            Rotate(4, false);
            Rotate(3, false);
            Rotate(4, false);
            Rotate(4, false);
            Rotate(3, true);
        }

        private void URUiLiURiUiL()//Corner Alignment
        {
            Rotate(4, false);
            Rotate(3, false);
            Rotate(4, true);
            Rotate(1, true);
            Rotate(4, false);
            Rotate(3, true);
            Rotate(4, true);
            Rotate(1, false);
        }

        #endregion

        #region Core Functions

        public void Rotate(int faceIndex,bool IsClockWiseRotation)
        {
            Piece[] temp = new Piece[9];
            for (int i = 0; i < 9; i++)
            {
                temp[i] = new Piece(faces[faceIndex, i].Kind, null,null);
                temp[i].Colors = new Dictionary<Direction, Color>();
                foreach (KeyValuePair<Direction,Color> item in faces[faceIndex,i].Colors)
                {
                    temp[i].Colors.Add(item.Key, item.Value);
                }
            }
            if (!IsClockWiseRotation)
            {
                faces[faceIndex, 0].Colors[Direction.Left] = temp[6].Colors[Direction.Down];
                faces[faceIndex, 0].Colors[Direction.Up] = temp[6].Colors[Direction.Left];
                faces[faceIndex, 0].Colors[Direction.Front] = temp[6].Colors[Direction.Front];
                faces[faceIndex, 2].Colors[Direction.Up] = temp[0].Colors[Direction.Left];
                faces[faceIndex, 2].Colors[Direction.Right] = temp[0].Colors[Direction.Up];
                faces[faceIndex, 2].Colors[Direction.Front] = temp[0].Colors[Direction.Front];
                faces[faceIndex, 6].Colors[Direction.Left] = temp[8].Colors[Direction.Down];
                faces[faceIndex, 6].Colors[Direction.Down] = temp[8].Colors[Direction.Right];
                faces[faceIndex, 6].Colors[Direction.Front] = temp[8].Colors[Direction.Front];
                faces[faceIndex, 8].Colors[Direction.Right] = temp[2].Colors[Direction.Up];
                faces[faceIndex, 8].Colors[Direction.Down] = temp[2].Colors[Direction.Right];
                faces[faceIndex, 8].Colors[Direction.Front] = temp[2].Colors[Direction.Front];

                faces[faceIndex, 1].Colors[Direction.Up] = temp[3].Colors[Direction.Left];
                faces[faceIndex, 1].Colors[Direction.Front] = temp[3].Colors[Direction.Front];
                faces[faceIndex, 3].Colors[Direction.Left] = temp[7].Colors[Direction.Down];
                faces[faceIndex, 3].Colors[Direction.Front] = temp[7].Colors[Direction.Front];
                faces[faceIndex, 5].Colors[Direction.Right] = temp[1].Colors[Direction.Up];
                faces[faceIndex, 5].Colors[Direction.Front] = temp[1].Colors[Direction.Front];
                faces[faceIndex, 7].Colors[Direction.Down] = temp[5].Colors[Direction.Right];
                faces[faceIndex, 7].Colors[Direction.Front] = temp[5].Colors[Direction.Front];  
            }
            else
            {
                faces[faceIndex, 0].Colors[Direction.Left] = temp[2].Colors[Direction.Up];
                faces[faceIndex, 0].Colors[Direction.Up] = temp[2].Colors[Direction.Right];
                faces[faceIndex, 0].Colors[Direction.Front] = temp[2].Colors[Direction.Front];
                faces[faceIndex, 2].Colors[Direction.Up] = temp[8].Colors[Direction.Right];
                faces[faceIndex, 2].Colors[Direction.Right] = temp[8].Colors[Direction.Down];
                faces[faceIndex, 2].Colors[Direction.Front] = temp[8].Colors[Direction.Front];
                faces[faceIndex, 6].Colors[Direction.Left] = temp[0].Colors[Direction.Up];
                faces[faceIndex, 6].Colors[Direction.Down] = temp[0].Colors[Direction.Left];
                faces[faceIndex, 6].Colors[Direction.Front] = temp[0].Colors[Direction.Front];
                faces[faceIndex, 8].Colors[Direction.Right] = temp[6].Colors[Direction.Down];
                faces[faceIndex, 8].Colors[Direction.Down] = temp[6].Colors[Direction.Left];
                faces[faceIndex, 8].Colors[Direction.Front] = temp[6].Colors[Direction.Front];

                faces[faceIndex, 1].Colors[Direction.Up] = temp[5].Colors[Direction.Right];
                faces[faceIndex, 1].Colors[Direction.Front] = temp[5].Colors[Direction.Front];
                faces[faceIndex, 3].Colors[Direction.Left] = temp[1].Colors[Direction.Up];
                faces[faceIndex, 3].Colors[Direction.Front] = temp[1].Colors[Direction.Front];
                faces[faceIndex, 5].Colors[Direction.Right] = temp[7].Colors[Direction.Down];
                faces[faceIndex, 5].Colors[Direction.Front] = temp[7].Colors[Direction.Front];
                faces[faceIndex, 7].Colors[Direction.Down] = temp[3].Colors[Direction.Left];
                faces[faceIndex, 7].Colors[Direction.Front] = temp[3].Colors[Direction.Front];
            }

            switch (faceIndex)
            {
                case 0: faces[1, 2].Colors[Direction.Front] = faces[0, 0].Colors[Direction.Left];
                    faces[1, 2].Colors[Direction.Up] = faces[0, 0].Colors[Direction.Up];
                    faces[1, 2].Colors[Direction.Right] = faces[0, 0].Colors[Direction.Front];
                    faces[1, 5].Colors[Direction.Front] = faces[0, 3].Colors[Direction.Left];
                    faces[1, 5].Colors[Direction.Right] = faces[0, 3].Colors[Direction.Front];
                    faces[1, 8].Colors[Direction.Front] = faces[0, 6].Colors[Direction.Left];
                    faces[1, 8].Colors[Direction.Down] = faces[0, 6].Colors[Direction.Down];
                    faces[1, 8].Colors[Direction.Right] = faces[0, 6].Colors[Direction.Front];

                    faces[3, 0].Colors[Direction.Front] = faces[0, 2].Colors[Direction.Right];
                    faces[3, 0].Colors[Direction.Up] = faces[0, 2].Colors[Direction.Up];
                    faces[3, 0].Colors[Direction.Left] = faces[0, 2].Colors[Direction.Front];
                    faces[3, 3].Colors[Direction.Front] = faces[0, 5].Colors[Direction.Right];
                    faces[3, 3].Colors[Direction.Left] = faces[0, 5].Colors[Direction.Front];
                    faces[3, 6].Colors[Direction.Front] = faces[0, 8].Colors[Direction.Right];
                    faces[3, 6].Colors[Direction.Down] = faces[0, 8].Colors[Direction.Down];
                    faces[3, 6].Colors[Direction.Left] = faces[0, 8].Colors[Direction.Front];

                    faces[4, 6].Colors[Direction.Front] = faces[0, 0].Colors[Direction.Up];
                    faces[4, 6].Colors[Direction.Left] = faces[0, 0].Colors[Direction.Left];
                    faces[4, 6].Colors[Direction.Down] = faces[0, 0].Colors[Direction.Front];
                    faces[4, 7].Colors[Direction.Front] = faces[0, 1].Colors[Direction.Up];
                    faces[4, 7].Colors[Direction.Down] = faces[0, 1].Colors[Direction.Front];
                    faces[4, 8].Colors[Direction.Front] = faces[0, 2].Colors[Direction.Up];
                    faces[4, 8].Colors[Direction.Right] = faces[0, 2].Colors[Direction.Right];
                    faces[4, 8].Colors[Direction.Down] = faces[0, 2].Colors[Direction.Front];

                    faces[5, 0].Colors[Direction.Front] = faces[0, 6].Colors[Direction.Down];
                    faces[5, 0].Colors[Direction.Left] = faces[0, 6].Colors[Direction.Left];
                    faces[5, 0].Colors[Direction.Up] = faces[0, 6].Colors[Direction.Front];
                    faces[5, 1].Colors[Direction.Front] = faces[0, 7].Colors[Direction.Down];
                    faces[5, 1].Colors[Direction.Up] = faces[0, 7].Colors[Direction.Front];
                    faces[5, 2].Colors[Direction.Front] = faces[0, 8].Colors[Direction.Down];
                    faces[5, 2].Colors[Direction.Right] = faces[0, 8].Colors[Direction.Right];
                    faces[5, 2].Colors[Direction.Up] = faces[0, 8].Colors[Direction.Front];

                    if (IsClockWiseRotation)
                        movesHistory.Add("Front Inverted");
                    else
                        movesHistory.Add("Front");
                    break;
                case 1: faces[2, 2].Colors[Direction.Front] = faces[1, 0].Colors[Direction.Left];
                    faces[2, 2].Colors[Direction.Up] = faces[1, 0].Colors[Direction.Up];
                    faces[2, 2].Colors[Direction.Right] = faces[1, 0].Colors[Direction.Front];
                    faces[2, 5].Colors[Direction.Front] = faces[1, 3].Colors[Direction.Left];
                    faces[2, 5].Colors[Direction.Right] = faces[1, 3].Colors[Direction.Front];
                    faces[2, 8].Colors[Direction.Front] = faces[1, 6].Colors[Direction.Left];
                    faces[2, 8].Colors[Direction.Down] = faces[1, 6].Colors[Direction.Down];
                    faces[2, 8].Colors[Direction.Right] = faces[1, 6].Colors[Direction.Front];

                    faces[0, 0].Colors[Direction.Front] = faces[1, 2].Colors[Direction.Right];
                    faces[0, 0].Colors[Direction.Up] = faces[1, 2].Colors[Direction.Up];
                    faces[0, 0].Colors[Direction.Left] = faces[1, 2].Colors[Direction.Front];
                    faces[0, 3].Colors[Direction.Front] = faces[1, 5].Colors[Direction.Right];
                    faces[0, 3].Colors[Direction.Left] = faces[1, 5].Colors[Direction.Front];
                    faces[0, 6].Colors[Direction.Front] = faces[1, 8].Colors[Direction.Right];
                    faces[0, 6].Colors[Direction.Down] = faces[1, 8].Colors[Direction.Down];
                    faces[0, 6].Colors[Direction.Left] = faces[1, 8].Colors[Direction.Front];

                    faces[4, 0].Colors[Direction.Front] = faces[1, 0].Colors[Direction.Up];
                    faces[4, 0].Colors[Direction.Up] = faces[1, 0].Colors[Direction.Left];
                    faces[4, 0].Colors[Direction.Left] = faces[1, 0].Colors[Direction.Front];
                    faces[4, 3].Colors[Direction.Front] = faces[1, 1].Colors[Direction.Up];
                    faces[4, 3].Colors[Direction.Left] = faces[1, 1].Colors[Direction.Front];
                    faces[4, 6].Colors[Direction.Front] = faces[1, 2].Colors[Direction.Up];
                    faces[4, 6].Colors[Direction.Down] = faces[1, 2].Colors[Direction.Right];
                    faces[4, 6].Colors[Direction.Left] = faces[1, 2].Colors[Direction.Front];

                    faces[5, 0].Colors[Direction.Front] = faces[1, 8].Colors[Direction.Down];
                    faces[5, 0].Colors[Direction.Up] = faces[1, 8].Colors[Direction.Right];
                    faces[5, 0].Colors[Direction.Left] = faces[1, 8].Colors[Direction.Front];
                    faces[5, 3].Colors[Direction.Front] = faces[1, 7].Colors[Direction.Down];
                    faces[5, 3].Colors[Direction.Left] = faces[1, 7].Colors[Direction.Front];
                    faces[5, 6].Colors[Direction.Front] = faces[1, 6].Colors[Direction.Down];
                    faces[5, 6].Colors[Direction.Down] = faces[1, 6].Colors[Direction.Left];
                    faces[5, 6].Colors[Direction.Left] = faces[1, 6].Colors[Direction.Front];

                    if (IsClockWiseRotation)
                        movesHistory.Add("Left Inverted");
                    else
                        movesHistory.Add("Left");
                    break;
                case 2: faces[3, 2].Colors[Direction.Front] = faces[2, 0].Colors[Direction.Left];
                    faces[3, 2].Colors[Direction.Up] = faces[2, 0].Colors[Direction.Up];
                    faces[3, 2].Colors[Direction.Right] = faces[2, 0].Colors[Direction.Front];
                    faces[3, 5].Colors[Direction.Front] = faces[2, 3].Colors[Direction.Left];
                    faces[3, 5].Colors[Direction.Right] = faces[2, 3].Colors[Direction.Front];
                    faces[3, 8].Colors[Direction.Front] = faces[2, 6].Colors[Direction.Left];
                    faces[3, 8].Colors[Direction.Down] = faces[2, 6].Colors[Direction.Down];
                    faces[3, 8].Colors[Direction.Right] = faces[2, 6].Colors[Direction.Front];

                    faces[1, 0].Colors[Direction.Front] = faces[2, 2].Colors[Direction.Right];
                    faces[1, 0].Colors[Direction.Up] = faces[2, 2].Colors[Direction.Up];
                    faces[1, 0].Colors[Direction.Left] = faces[2, 2].Colors[Direction.Front];
                    faces[1, 3].Colors[Direction.Front] = faces[2, 5].Colors[Direction.Right];
                    faces[1, 3].Colors[Direction.Left] = faces[2, 5].Colors[Direction.Front];
                    faces[1, 6].Colors[Direction.Front] = faces[2, 8].Colors[Direction.Right];
                    faces[1, 6].Colors[Direction.Down] = faces[2, 8].Colors[Direction.Down];
                    faces[1, 6].Colors[Direction.Left] = faces[2, 8].Colors[Direction.Front];

                    faces[4, 2].Colors[Direction.Front] = faces[2, 0].Colors[Direction.Up];
                    faces[4, 2].Colors[Direction.Right] = faces[2, 0].Colors[Direction.Left];
                    faces[4, 2].Colors[Direction.Up] = faces[2, 0].Colors[Direction.Front];
                    faces[4, 1].Colors[Direction.Front] = faces[2, 1].Colors[Direction.Up];
                    faces[4, 1].Colors[Direction.Up] = faces[2, 1].Colors[Direction.Front];
                    faces[4, 0].Colors[Direction.Front] = faces[2, 2].Colors[Direction.Up];
                    faces[4, 0].Colors[Direction.Left] = faces[2, 2].Colors[Direction.Right];
                    faces[4, 0].Colors[Direction.Up] = faces[2, 2].Colors[Direction.Front];

                    faces[5, 8].Colors[Direction.Front] = faces[2, 6].Colors[Direction.Down];
                    faces[5, 8].Colors[Direction.Right] = faces[2, 6].Colors[Direction.Left];
                    faces[5, 8].Colors[Direction.Down] = faces[2, 6].Colors[Direction.Front];
                    faces[5, 7].Colors[Direction.Front] = faces[2, 7].Colors[Direction.Down];
                    faces[5, 7].Colors[Direction.Down] = faces[2, 7].Colors[Direction.Front];
                    faces[5, 6].Colors[Direction.Front] = faces[2, 8].Colors[Direction.Down];
                    faces[5, 6].Colors[Direction.Left] = faces[2, 8].Colors[Direction.Right];
                    faces[5, 6].Colors[Direction.Down] = faces[2, 8].Colors[Direction.Front];

                    if (IsClockWiseRotation)
                        movesHistory.Add("Back Inverted");
                    else
                        movesHistory.Add("Back");
                    break;
                case 3: faces[0, 2].Colors[Direction.Front] = faces[3, 0].Colors[Direction.Left];
                    faces[0, 2].Colors[Direction.Up] = faces[3, 0].Colors[Direction.Up];
                    faces[0, 2].Colors[Direction.Right] = faces[3, 0].Colors[Direction.Front];
                    faces[0, 5].Colors[Direction.Front] = faces[3, 3].Colors[Direction.Left];
                    faces[0, 5].Colors[Direction.Right] = faces[3, 3].Colors[Direction.Front];
                    faces[0, 8].Colors[Direction.Front] = faces[3, 6].Colors[Direction.Left];
                    faces[0, 8].Colors[Direction.Down] = faces[3, 6].Colors[Direction.Down];
                    faces[0, 8].Colors[Direction.Right] = faces[3, 6].Colors[Direction.Front];

                    faces[2, 0].Colors[Direction.Front] = faces[3, 2].Colors[Direction.Right];
                    faces[2, 0].Colors[Direction.Up] = faces[3, 2].Colors[Direction.Up];
                    faces[2, 0].Colors[Direction.Left] = faces[3, 2].Colors[Direction.Front];
                    faces[2, 3].Colors[Direction.Front] = faces[3, 5].Colors[Direction.Right];
                    faces[2, 3].Colors[Direction.Left] = faces[3, 5].Colors[Direction.Front];
                    faces[2, 6].Colors[Direction.Front] = faces[3, 8].Colors[Direction.Right];
                    faces[2, 6].Colors[Direction.Down] = faces[3, 8].Colors[Direction.Down];
                    faces[2, 6].Colors[Direction.Left] = faces[3, 8].Colors[Direction.Front];

                    faces[4, 2].Colors[Direction.Front] = faces[3, 2].Colors[Direction.Up];
                    faces[4, 2].Colors[Direction.Up] = faces[3, 2].Colors[Direction.Right];
                    faces[4, 2].Colors[Direction.Right] = faces[3, 2].Colors[Direction.Front];
                    faces[4, 5].Colors[Direction.Front] = faces[3, 1].Colors[Direction.Up];
                    faces[4, 5].Colors[Direction.Right] = faces[3, 1].Colors[Direction.Front];
                    faces[4, 8].Colors[Direction.Front] = faces[3, 0].Colors[Direction.Up];
                    faces[4, 8].Colors[Direction.Down] = faces[3, 0].Colors[Direction.Left];
                    faces[4, 8].Colors[Direction.Right] = faces[3, 0].Colors[Direction.Front];

                    faces[5, 2].Colors[Direction.Front] = faces[3, 6].Colors[Direction.Down];
                    faces[5, 2].Colors[Direction.Up] = faces[3, 6].Colors[Direction.Left];
                    faces[5, 2].Colors[Direction.Right] = faces[3, 6].Colors[Direction.Front];
                    faces[5, 5].Colors[Direction.Front] = faces[3, 7].Colors[Direction.Down];
                    faces[5, 5].Colors[Direction.Right] = faces[3, 7].Colors[Direction.Front];
                    faces[5, 8].Colors[Direction.Front] = faces[3, 8].Colors[Direction.Down];
                    faces[5, 8].Colors[Direction.Down] = faces[3, 8].Colors[Direction.Right];
                    faces[5, 8].Colors[Direction.Right] = faces[3, 8].Colors[Direction.Front];

                    if (IsClockWiseRotation)
                        movesHistory.Add("Right Inverted");
                    else
                        movesHistory.Add("Right");
                    break;
                case 4: faces[0, 0].Colors[Direction.Front] = faces[4, 6].Colors[Direction.Down];
                    faces[0, 0].Colors[Direction.Left] = faces[4, 6].Colors[Direction.Left];
                    faces[0, 0].Colors[Direction.Up] = faces[4, 6].Colors[Direction.Front];
                    faces[0, 1].Colors[Direction.Front] = faces[4, 7].Colors[Direction.Down];
                    faces[0, 1].Colors[Direction.Up] = faces[4, 7].Colors[Direction.Front];
                    faces[0, 2].Colors[Direction.Front] = faces[4, 8].Colors[Direction.Down];
                    faces[0, 2].Colors[Direction.Right] = faces[4, 8].Colors[Direction.Right];
                    faces[0, 2].Colors[Direction.Up] = faces[4, 8].Colors[Direction.Front];

                    faces[1, 0].Colors[Direction.Front] = faces[4, 0].Colors[Direction.Left];
                    faces[1, 0].Colors[Direction.Left] = faces[4, 0].Colors[Direction.Up];
                    faces[1, 0].Colors[Direction.Up] = faces[4, 0].Colors[Direction.Front];
                    faces[1, 1].Colors[Direction.Front] = faces[4, 3].Colors[Direction.Left];
                    faces[1, 1].Colors[Direction.Up] = faces[4, 3].Colors[Direction.Front];
                    faces[1, 2].Colors[Direction.Front] = faces[4, 6].Colors[Direction.Left];
                    faces[1, 2].Colors[Direction.Right] = faces[4, 6].Colors[Direction.Down];
                    faces[1, 2].Colors[Direction.Up] = faces[4, 6].Colors[Direction.Front];

                    faces[2, 0].Colors[Direction.Front] = faces[4, 2].Colors[Direction.Up];
                    faces[2, 0].Colors[Direction.Left] = faces[4, 2].Colors[Direction.Right];
                    faces[2, 0].Colors[Direction.Up] = faces[4, 2].Colors[Direction.Front];
                    faces[2, 1].Colors[Direction.Front] = faces[4, 1].Colors[Direction.Up];
                    faces[2, 1].Colors[Direction.Up] = faces[4, 1].Colors[Direction.Front];
                    faces[2, 2].Colors[Direction.Front] = faces[4, 0].Colors[Direction.Up];
                    faces[2, 2].Colors[Direction.Right] = faces[4, 0].Colors[Direction.Left];
                    faces[2, 2].Colors[Direction.Up] = faces[4, 0].Colors[Direction.Front];

                    faces[3, 0].Colors[Direction.Front] = faces[4, 8].Colors[Direction.Right];
                    faces[3, 0].Colors[Direction.Left] = faces[4, 8].Colors[Direction.Down];
                    faces[3, 0].Colors[Direction.Up] = faces[4, 8].Colors[Direction.Front];
                    faces[3, 1].Colors[Direction.Front] = faces[4, 5].Colors[Direction.Right];
                    faces[3, 1].Colors[Direction.Up] = faces[4, 5].Colors[Direction.Front];
                    faces[3, 2].Colors[Direction.Front] = faces[4, 2].Colors[Direction.Right];
                    faces[3, 2].Colors[Direction.Right] = faces[4, 2].Colors[Direction.Up];
                    faces[3, 2].Colors[Direction.Up] = faces[4, 2].Colors[Direction.Front];

                    if (IsClockWiseRotation)
                        movesHistory.Add("Up Inverted");
                    else
                        movesHistory.Add("Up");
                    break;
                case 5: faces[0, 6].Colors[Direction.Front] = faces[5, 0].Colors[Direction.Up];
                    faces[0, 6].Colors[Direction.Left] = faces[5, 0].Colors[Direction.Left];
                    faces[0, 6].Colors[Direction.Down] = faces[5, 0].Colors[Direction.Front];
                    faces[0, 7].Colors[Direction.Front] = faces[5, 1].Colors[Direction.Up];
                    faces[0, 7].Colors[Direction.Down] = faces[5, 1].Colors[Direction.Front];
                    faces[0, 8].Colors[Direction.Front] = faces[5, 2].Colors[Direction.Up];
                    faces[0, 8].Colors[Direction.Right] = faces[5, 2].Colors[Direction.Right];
                    faces[0, 8].Colors[Direction.Down] = faces[5, 2].Colors[Direction.Front];

                    faces[1, 6].Colors[Direction.Front] = faces[5, 6].Colors[Direction.Left];
                    faces[1, 6].Colors[Direction.Left] = faces[5, 6].Colors[Direction.Down];
                    faces[1, 6].Colors[Direction.Down] = faces[5, 6].Colors[Direction.Front];
                    faces[1, 7].Colors[Direction.Front] = faces[5, 3].Colors[Direction.Left];
                    faces[1, 7].Colors[Direction.Down] = faces[5, 3].Colors[Direction.Front];
                    faces[1, 8].Colors[Direction.Front] = faces[5, 0].Colors[Direction.Left];
                    faces[1, 8].Colors[Direction.Right] = faces[5, 0].Colors[Direction.Up];
                    faces[1, 8].Colors[Direction.Down] = faces[5, 0].Colors[Direction.Front];

                    faces[2, 6].Colors[Direction.Front] = faces[5, 8].Colors[Direction.Down];
                    faces[2, 6].Colors[Direction.Left] = faces[5, 8].Colors[Direction.Right];
                    faces[2, 6].Colors[Direction.Down] = faces[5, 8].Colors[Direction.Front];
                    faces[2, 7].Colors[Direction.Front] = faces[5, 7].Colors[Direction.Down];
                    faces[2, 7].Colors[Direction.Down] = faces[5, 7].Colors[Direction.Front];
                    faces[2, 8].Colors[Direction.Front] = faces[5, 6].Colors[Direction.Down];
                    faces[2, 8].Colors[Direction.Right] = faces[5, 6].Colors[Direction.Left];
                    faces[2, 8].Colors[Direction.Down] = faces[5, 6].Colors[Direction.Front];

                    faces[3, 6].Colors[Direction.Front] = faces[5, 2].Colors[Direction.Right];
                    faces[3, 6].Colors[Direction.Left] = faces[5, 2].Colors[Direction.Up];
                    faces[3, 6].Colors[Direction.Down] = faces[5, 2].Colors[Direction.Front];
                    faces[3, 7].Colors[Direction.Front] = faces[5, 5].Colors[Direction.Right];
                    faces[3, 7].Colors[Direction.Down] = faces[5, 5].Colors[Direction.Front];
                    faces[3, 8].Colors[Direction.Front] = faces[5, 8].Colors[Direction.Right];
                    faces[3, 8].Colors[Direction.Right] = faces[5, 8].Colors[Direction.Down];
                    faces[3, 8].Colors[Direction.Down] = faces[5, 8].Colors[Direction.Front];

                    if (IsClockWiseRotation)
                        movesHistory.Add("Down Inverted");
                    else
                        movesHistory.Add("Down");
                    break;
            }
            LocalMovesCount++;
            if (TurnPauseOn)
                System.Threading.Thread.Sleep(solvesleep);
        }

        public void RotateCube(Direction Axe,bool IsInverseRotate)
        {
            Piece[,] Temp = new Piece[6, 9];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Temp[i, j] = faces[i, j].Clone();
                }
            }
            switch (Axe)
            {
                case Direction.Front:
                    for (int i = 0; i < 6; i++)
                    {
                        if (!IsInverseRotate)
                        {
                            switch (i)
                            {
                                case 0: faces[0, 0] = Temp[0, 6];                                    
                                    faces[0, 1] = Temp[0, 3];
                                    faces[0, 2] = Temp[0, 0];
                                    faces[0, 3] = Temp[0, 7];
                                    faces[0, 4] = Temp[0, 4];
                                    faces[0, 5] = Temp[0, 1];
                                    faces[0, 6] = Temp[0, 8];
                                    faces[0, 7] = Temp[0, 5];
                                    faces[0, 8] = Temp[0, 2];
                                    break;
                                case 1: faces[1, 0] = Temp[5, 6];
                                    faces[1, 1] = Temp[5, 3];
                                    faces[1, 2] = Temp[5, 0];
                                    faces[1, 3] = Temp[5, 7];
                                    faces[1, 4] = Temp[5, 4];
                                    faces[1, 5] = Temp[5, 1];
                                    faces[1, 6] = Temp[5, 8];
                                    faces[1, 7] = Temp[5, 5];
                                    faces[1, 8] = Temp[5, 2];
                                    break;
                                case 2: faces[2, 0] = Temp[2, 2];
                                    faces[2, 1] = Temp[2, 5];
                                    faces[2, 2] = Temp[2, 8];
                                    faces[2, 3] = Temp[2, 1];
                                    faces[2, 4] = Temp[2, 4];
                                    faces[2, 5] = Temp[2, 7];
                                    faces[2, 6] = Temp[2, 0];
                                    faces[2, 7] = Temp[2, 3];
                                    faces[2, 8] = Temp[2, 6];
                                    break;
                                case 3: faces[3, 0] = Temp[4, 6];
                                    faces[3, 1] = Temp[4, 3];
                                    faces[3, 2] = Temp[4, 0];
                                    faces[3, 3] = Temp[4, 7];
                                    faces[3, 4] = Temp[4, 4];
                                    faces[3, 5] = Temp[4, 1];
                                    faces[3, 6] = Temp[4, 8];
                                    faces[3, 7] = Temp[4, 5];
                                    faces[3, 8] = Temp[4, 2];
                                    break;
                                case 4: faces[4, 0] = Temp[1, 6];
                                    faces[4, 1] = Temp[1, 3];
                                    faces[4, 2] = Temp[1, 0];
                                    faces[4, 3] = Temp[1, 7];
                                    faces[4, 4] = Temp[1, 4];
                                    faces[4, 5] = Temp[1, 1];
                                    faces[4, 6] = Temp[1, 8];
                                    faces[4, 7] = Temp[1, 5];
                                    faces[4, 8] = Temp[1, 2];
                                    break;
                                case 5: faces[5, 0] = Temp[3, 6];
                                    faces[5, 1] = Temp[3, 3];
                                    faces[5, 2] = Temp[3, 0];
                                    faces[5, 3] = Temp[3, 7];
                                    faces[5, 4] = Temp[3, 4];
                                    faces[5, 5] = Temp[3, 1];
                                    faces[5, 6] = Temp[3, 8];
                                    faces[5, 7] = Temp[3, 5];
                                    faces[5, 8] = Temp[3, 2];
                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 0: faces[0, 6] = Temp[0, 0];
                                    faces[0, 3] = Temp[0, 1];
                                    faces[0, 0] = Temp[0, 2];
                                    faces[0, 7] = Temp[0, 3];
                                    faces[0, 4] = Temp[0, 4];
                                    faces[0, 1] = Temp[0, 5];
                                    faces[0, 8] = Temp[0, 6];
                                    faces[0, 5] = Temp[0, 7];
                                    faces[0, 2] = Temp[0, 8];
                                    break;
                                case 5: faces[5, 6] = Temp[1, 0];
                                    faces[5, 3] = Temp[1, 1];
                                    faces[5, 0] = Temp[1, 2];
                                    faces[5, 7] = Temp[1, 3];
                                    faces[5, 4] = Temp[1, 4];
                                    faces[5, 1] = Temp[1, 5];
                                    faces[5, 8] = Temp[1, 6];
                                    faces[5, 5] = Temp[1, 7];
                                    faces[5, 2] = Temp[1, 8];
                                    break;
                                case 2: faces[2, 2] = Temp[2, 0];
                                    faces[2, 5] = Temp[2, 1];
                                    faces[2, 8] = Temp[2, 2];
                                    faces[2, 1] = Temp[2, 3];
                                    faces[2, 4] = Temp[2, 4];
                                    faces[2, 7] = Temp[2, 5];
                                    faces[2, 0] = Temp[2, 6];
                                    faces[2, 3] = Temp[2, 7];
                                    faces[2, 6] = Temp[2, 8];
                                    break;
                                case 4: faces[4, 6] = Temp[3, 0];
                                    faces[4, 3] = Temp[3, 1];
                                    faces[4, 0] = Temp[3, 2];
                                    faces[4, 7] = Temp[3, 3];
                                    faces[4, 4] = Temp[3, 4];
                                    faces[4, 1] = Temp[3, 5];
                                    faces[4, 8] = Temp[3, 6];
                                    faces[4, 5] = Temp[3, 7];
                                    faces[4, 2] = Temp[3, 8];
                                    break;
                                case 1: faces[1, 6] = Temp[4, 0];
                                    faces[1, 3] = Temp[4, 1];
                                    faces[1, 0] = Temp[4, 2];
                                    faces[1, 7] = Temp[4, 3];
                                    faces[1, 4] = Temp[4, 4];
                                    faces[1, 1] = Temp[4, 5];
                                    faces[1, 8] = Temp[4, 6];
                                    faces[1, 5] = Temp[4, 7];
                                    faces[1, 2] = Temp[4, 8];
                                    break;
                                case 3: faces[3, 6] = Temp[5, 6];
                                    faces[3, 3] = Temp[5, 3];
                                    faces[3, 0] = Temp[5, 0];
                                    faces[3, 7] = Temp[5, 7];
                                    faces[3, 4] = Temp[5, 4];
                                    faces[3, 1] = Temp[5, 1];
                                    faces[3, 8] = Temp[5, 8];
                                    faces[3, 5] = Temp[5, 5];
                                    faces[3, 2] = Temp[5, 2];
                                    break;
                            }
                        }
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            faces[i, j].X = j % 3;
                            faces[i, j].Y = j / 3;
                            Dictionary<Direction, Color> tempColors = new Dictionary<Direction, Color>();
                            foreach (var item in faces[i, j].Colors)
                            {
                                tempColors.Add(item.Key, item.Value);
                            }
                            faces[i, j].Colors.Clear();
                            foreach (var item in tempColors)
                            {
                                if (!IsInverseRotate)
                                {
                                    if (item.Key == Direction.Left)
                                        faces[i, j].Colors.Add(Direction.Up, item.Value);
                                    else
                                        if (item.Key == Direction.Up)
                                            faces[i, j].Colors.Add(Direction.Right, item.Value);
                                        else
                                            if (item.Key == Direction.Right)
                                                faces[i, j].Colors.Add(Direction.Down, item.Value);
                                            else
                                                if (item.Key == Direction.Down)
                                                    faces[i, j].Colors.Add(Direction.Left, item.Value);
                                                else
                                                    faces[i, j].Colors.Add(item.Key, item.Value);
                                }
                                else
                                {
                                    if (item.Key == Direction.Left)
                                        faces[i, j].Colors.Add(Direction.Down, item.Value);
                                    else
                                        if (item.Key == Direction.Up)
                                            faces[i, j].Colors.Add(Direction.Left, item.Value);
                                        else
                                            if (item.Key == Direction.Right)
                                                faces[i, j].Colors.Add(Direction.Up, item.Value);
                                            else
                                                if (item.Key == Direction.Down)
                                                    faces[i, j].Colors.Add(Direction.Right, item.Value);
                                                else
                                                    faces[i, j].Colors.Add(item.Key, item.Value);
                                }
                            }
                        }
                    }
                    if(!IsInverseRotate)
                        movesHistory.Add("Cube Front");
                    else
                        movesHistory.Add("Cube Front Inverted");
                    break;
                case Direction.Up:
                    for (int i = 0; i < 6; i++)
                    {
                        if (!IsInverseRotate)
                        {
                            switch (i)
                            {
                                case 0: faces[0, 0] = Temp[3, 0];
                                    faces[0, 1] = Temp[3, 1];
                                    faces[0, 2] = Temp[3, 2];
                                    faces[0, 3] = Temp[3, 3];
                                    faces[0, 4] = Temp[3, 4];
                                    faces[0, 5] = Temp[3, 5];
                                    faces[0, 6] = Temp[3, 6];
                                    faces[0, 7] = Temp[3, 7];
                                    faces[0, 8] = Temp[3, 8];
                                    break;
                                case 1: faces[1, 0] = Temp[0, 0];
                                    faces[1, 1] = Temp[0, 1];
                                    faces[1, 2] = Temp[0, 2];
                                    faces[1, 3] = Temp[0, 3];
                                    faces[1, 4] = Temp[0, 4];
                                    faces[1, 5] = Temp[0, 5];
                                    faces[1, 6] = Temp[0, 6];
                                    faces[1, 7] = Temp[0, 7];
                                    faces[1, 8] = Temp[0, 8];
                                    break;
                                case 2: faces[2, 0] = Temp[1, 0];
                                    faces[2, 1] = Temp[1, 1];
                                    faces[2, 2] = Temp[1, 2];
                                    faces[2, 3] = Temp[1, 3];
                                    faces[2, 4] = Temp[1, 4];
                                    faces[2, 5] = Temp[1, 5];
                                    faces[2, 6] = Temp[1, 6];
                                    faces[2, 7] = Temp[1, 7];
                                    faces[2, 8] = Temp[1, 8];
                                    break;
                                case 3: faces[3, 0] = Temp[2, 0];
                                    faces[3, 1] = Temp[2, 1];
                                    faces[3, 2] = Temp[2, 2];
                                    faces[3, 3] = Temp[2, 3];
                                    faces[3, 4] = Temp[2, 4];
                                    faces[3, 5] = Temp[2, 5];
                                    faces[3, 6] = Temp[2, 6];
                                    faces[3, 7] = Temp[2, 7];
                                    faces[3, 8] = Temp[2, 8];
                                    break;
                                case 4: faces[4, 0] = Temp[4, 6];
                                    faces[4, 0].Colors.Add(Direction.Up, faces[4, 0].Colors[Direction.Left]);
                                    faces[4, 0].Colors.Remove(Direction.Left);
                                    faces[4, 0].Colors.Add(Direction.Left, faces[4, 0].Colors[Direction.Down]);
                                    faces[4, 0].Colors.Remove(Direction.Down);

                                    faces[4, 1] = Temp[4, 3];
                                    faces[4, 1].Colors.Add(Direction.Up, faces[4, 1].Colors[Direction.Left]);
                                    faces[4, 1].Colors.Remove(Direction.Left);

                                    faces[4, 2] = Temp[4, 0];
                                    faces[4, 2].Colors.Add(Direction.Right, faces[4, 2].Colors[Direction.Up]);
                                    faces[4, 2].Colors.Remove(Direction.Up);
                                    faces[4, 2].Colors.Add(Direction.Up, faces[4, 2].Colors[Direction.Left]);
                                    faces[4, 2].Colors.Remove(Direction.Left);

                                    faces[4, 3] = Temp[4, 7];
                                    faces[4, 3].Colors.Add(Direction.Left, faces[4, 3].Colors[Direction.Down]);
                                    faces[4, 3].Colors.Remove(Direction.Down);

                                    faces[4, 4] = Temp[4, 4];

                                    faces[4, 5] = Temp[4, 1];
                                    faces[4, 5].Colors.Add(Direction.Right, faces[4, 5].Colors[Direction.Up]);
                                    faces[4, 5].Colors.Remove(Direction.Up);

                                    faces[4, 6] = Temp[4, 8];
                                    faces[4, 6].Colors.Add(Direction.Left, faces[4, 6].Colors[Direction.Down]);
                                    faces[4, 6].Colors.Remove(Direction.Down);
                                    faces[4, 6].Colors.Add(Direction.Down, faces[4, 6].Colors[Direction.Right]);
                                    faces[4, 6].Colors.Remove(Direction.Right);

                                    faces[4, 7] = Temp[4, 5];
                                    faces[4, 7].Colors.Add(Direction.Down, faces[4, 7].Colors[Direction.Right]);
                                    faces[4, 7].Colors.Remove(Direction.Right);

                                    faces[4, 8] = Temp[4, 2];
                                    faces[4, 8].Colors.Add(Direction.Down, faces[4, 8].Colors[Direction.Right]);
                                    faces[4, 8].Colors.Remove(Direction.Right);
                                    faces[4, 8].Colors.Add(Direction.Right, faces[4, 8].Colors[Direction.Up]);
                                    faces[4, 8].Colors.Remove(Direction.Up);

                                    break;
                                case 5: 
                                    faces[5, 0] = Temp[5, 2];
                                    faces[5, 0].Colors.Add(Direction.Left, faces[5, 0].Colors[Direction.Up]);
                                    faces[5, 0].Colors.Remove(Direction.Up);
                                    faces[5, 0].Colors.Add(Direction.Up, faces[5, 0].Colors[Direction.Right]);
                                    faces[5, 0].Colors.Remove(Direction.Right);

                                    faces[5, 1] = Temp[5, 5];
                                    faces[5, 1].Colors.Add(Direction.Up, faces[5, 1].Colors[Direction.Right]);
                                    faces[5, 1].Colors.Remove(Direction.Right);

                                    faces[5, 2] = Temp[5, 8];
                                    faces[5, 2].Colors.Add(Direction.Up, faces[5, 2].Colors[Direction.Right]);
                                    faces[5, 2].Colors.Remove(Direction.Right);
                                    faces[5, 2].Colors.Add(Direction.Right, faces[5, 2].Colors[Direction.Down]);
                                    faces[5, 2].Colors.Remove(Direction.Down);

                                    faces[5, 3] = Temp[5, 1];
                                    faces[5, 3].Colors.Add(Direction.Left, faces[5, 3].Colors[Direction.Up]);
                                    faces[5, 3].Colors.Remove(Direction.Up);

                                    faces[5, 4] = Temp[5, 4];

                                    faces[5, 5] = Temp[5, 7];
                                    faces[5, 5].Colors.Add(Direction.Right, faces[5, 5].Colors[Direction.Down]);
                                    faces[5, 5].Colors.Remove(Direction.Down);

                                    faces[5, 6] = Temp[5, 0];
                                    faces[5, 6].Colors.Add(Direction.Down, faces[5, 6].Colors[Direction.Left]);
                                    faces[5, 6].Colors.Remove(Direction.Left);
                                    faces[5, 6].Colors.Add(Direction.Left, faces[5, 6].Colors[Direction.Up]);
                                    faces[5, 6].Colors.Remove(Direction.Up);

                                    faces[5, 7] = Temp[5, 3];
                                    faces[5, 7].Colors.Add(Direction.Down, faces[5, 7].Colors[Direction.Left]);
                                    faces[5, 7].Colors.Remove(Direction.Left);

                                    faces[5, 8] = Temp[5, 6];
                                    faces[5, 8].Colors.Add(Direction.Right, faces[5, 8].Colors[Direction.Down]);
                                    faces[5, 8].Colors.Remove(Direction.Down);
                                    faces[5, 8].Colors.Add(Direction.Down, faces[5, 8].Colors[Direction.Left]);
                                    faces[5, 8].Colors.Remove(Direction.Left);

                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 3: faces[3, 0] = Temp[0, 0];
                                    faces[3, 1] = Temp[0, 1];
                                    faces[3, 2] = Temp[0, 2];
                                    faces[3, 3] = Temp[0, 3];
                                    faces[3, 4] = Temp[0, 4];
                                    faces[3, 5] = Temp[0, 5];
                                    faces[3, 6] = Temp[0, 6];
                                    faces[3, 7] = Temp[0, 7];
                                    faces[3, 8] = Temp[0, 8];
                                    break;
                                case 0: faces[0, 0] = Temp[1, 0];
                                    faces[0, 1] = Temp[1, 1];
                                    faces[0, 2] = Temp[1, 2];
                                    faces[0, 3] = Temp[1, 3];
                                    faces[0, 4] = Temp[1, 4];
                                    faces[0, 5] = Temp[1, 5];
                                    faces[0, 6] = Temp[1, 6];
                                    faces[0, 7] = Temp[1, 7];
                                    faces[0, 8] = Temp[1, 8];
                                    break;
                                case 1: faces[1, 0] = Temp[2, 0];
                                    faces[1, 1] = Temp[2, 1];
                                    faces[1, 2] = Temp[2, 2];
                                    faces[1, 3] = Temp[2, 3];
                                    faces[1, 4] = Temp[2, 4];
                                    faces[1, 5] = Temp[2, 5];
                                    faces[1, 6] = Temp[2, 6];
                                    faces[1, 7] = Temp[2, 7];
                                    faces[1, 8] = Temp[2, 8];
                                    break;
                                case 2: faces[2, 0] = Temp[3, 0];
                                    faces[2, 1] = Temp[3, 1];
                                    faces[2, 2] = Temp[3, 2];
                                    faces[2, 3] = Temp[3, 3];
                                    faces[2, 4] = Temp[3, 4];
                                    faces[2, 5] = Temp[3, 5];
                                    faces[2, 6] = Temp[3, 6];
                                    faces[2, 7] = Temp[3, 7];
                                    faces[2, 8] = Temp[3, 8];
                                    break;
                                case 4: faces[4, 6] = Temp[4, 0];
                                    faces[4, 6].Colors.Add(Direction.Down, faces[4, 6].Colors[Direction.Left]);
                                    faces[4, 6].Colors.Remove(Direction.Left);
                                    faces[4, 6].Colors.Add(Direction.Left, faces[4, 6].Colors[Direction.Up]);
                                    faces[4, 6].Colors.Remove(Direction.Up);

                                    faces[4, 3] = Temp[4, 1];
                                    faces[4, 3].Colors.Add(Direction.Left, faces[4, 3].Colors[Direction.Up]);
                                    faces[4, 3].Colors.Remove(Direction.Up);

                                    faces[4, 0] = Temp[4, 2];
                                    faces[4, 0].Colors.Add(Direction.Left, faces[4, 0].Colors[Direction.Up]);
                                    faces[4, 0].Colors.Remove(Direction.Up);
                                    faces[4, 0].Colors.Add(Direction.Up, faces[4, 0].Colors[Direction.Right]);
                                    faces[4, 0].Colors.Remove(Direction.Right);

                                    faces[4, 7] = Temp[4, 3];
                                    faces[4, 7].Colors.Add(Direction.Down, faces[4, 7].Colors[Direction.Left]);
                                    faces[4, 7].Colors.Remove(Direction.Left);

                                    faces[4, 4] = Temp[4, 4];

                                    faces[4, 1] = Temp[4, 5];
                                    faces[4, 1].Colors.Add(Direction.Up, faces[4, 1].Colors[Direction.Right]);
                                    faces[4, 1].Colors.Remove(Direction.Right);

                                    faces[4, 8] = Temp[4, 6];
                                    faces[4, 8].Colors.Add(Direction.Right, faces[4, 8].Colors[Direction.Down]);
                                    faces[4, 8].Colors.Remove(Direction.Down);
                                    faces[4, 8].Colors.Add(Direction.Down, faces[4, 8].Colors[Direction.Left]);
                                    faces[4, 8].Colors.Remove(Direction.Left);

                                    faces[4, 5] = Temp[4, 7];
                                    faces[4, 5].Colors.Add(Direction.Right, faces[4, 5].Colors[Direction.Down]);
                                    faces[4, 5].Colors.Remove(Direction.Down);

                                    faces[4, 2] = Temp[4, 8];
                                    faces[4, 2].Colors.Add(Direction.Up, faces[4, 2].Colors[Direction.Right]);
                                    faces[4, 2].Colors.Remove(Direction.Right);
                                    faces[4, 2].Colors.Add(Direction.Right, faces[4, 2].Colors[Direction.Down]);
                                    faces[4, 2].Colors.Remove(Direction.Down);

                                    break;
                                case 5: faces[5, 2] = Temp[5, 0];
                                    faces[5, 2].Colors.Add(Direction.Right, faces[5, 2].Colors[Direction.Up]);
                                    faces[5, 2].Colors.Remove(Direction.Up);
                                    faces[5, 2].Colors.Add(Direction.Up, faces[5, 2].Colors[Direction.Left]);
                                    faces[5, 2].Colors.Remove(Direction.Left);

                                    faces[5, 5] = Temp[5, 1];
                                    faces[5, 5].Colors.Add(Direction.Right, faces[5, 5].Colors[Direction.Up]);
                                    faces[5, 5].Colors.Remove(Direction.Up);

                                    faces[5, 8] = Temp[5, 2];                                    
                                    faces[5, 8].Colors.Add(Direction.Down, faces[5, 8].Colors[Direction.Right]);
                                    faces[5, 8].Colors.Remove(Direction.Right);
                                    faces[5, 8].Colors.Add(Direction.Right, faces[5, 8].Colors[Direction.Up]);
                                    faces[5, 8].Colors.Remove(Direction.Up);

                                    faces[5, 1] = Temp[5, 3];
                                    faces[5, 1].Colors.Add(Direction.Up, faces[5, 1].Colors[Direction.Left]);
                                    faces[5, 1].Colors.Remove(Direction.Left);

                                    faces[5, 4] = Temp[5, 4];

                                    faces[5, 7] = Temp[5, 5];
                                    faces[5, 7].Colors.Add(Direction.Down, faces[5, 7].Colors[Direction.Right]);
                                    faces[5, 7].Colors.Remove(Direction.Right);

                                    faces[5, 0] = Temp[5, 6];
                                    faces[5, 0].Colors.Add(Direction.Up, faces[5, 0].Colors[Direction.Left]);
                                    faces[5, 0].Colors.Remove(Direction.Left);
                                    faces[5, 0].Colors.Add(Direction.Left, faces[5, 0].Colors[Direction.Down]);
                                    faces[5, 0].Colors.Remove(Direction.Down);

                                    faces[5, 3] = Temp[5, 7];
                                    faces[5, 3].Colors.Add(Direction.Left, faces[5, 3].Colors[Direction.Down]);
                                    faces[5, 3].Colors.Remove(Direction.Down);

                                    faces[5, 6] = Temp[5, 8];
                                    faces[5, 6].Colors.Add(Direction.Left, faces[5, 6].Colors[Direction.Down]);
                                    faces[5, 6].Colors.Remove(Direction.Down);
                                    faces[5, 6].Colors.Add(Direction.Down, faces[5, 6].Colors[Direction.Right]);
                                    faces[5, 6].Colors.Remove(Direction.Right);

                                    break;
                            }
                        }
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            faces[i, j].X = j % 3;
                            faces[i, j].Y = j / 3;
                        }
                    }
                    if (!IsInverseRotate)
                        movesHistory.Add("Cube Up");
                    else
                        movesHistory.Add("Cube Up Inverted");
                    break;
                case Direction.Right:
                    break;
            }
            LocalMovesCount++;
        }

        #endregion

        public void Dispose()
        {
            if (solveTHread != null && solveTHread.IsAlive)
                solveTHread.Abort();
        }
    }
}
