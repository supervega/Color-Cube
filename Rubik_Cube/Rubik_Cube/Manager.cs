using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rubik_Cube
{
    public enum Direction { Up, Down, Left, Right, Front, Back }
    public enum PieceKind { Center, Edge, Corner }

    public class Manager
    {
        private Piece[,] faces;// 0 = front, 1 = Left, 2 = Back, 3 = Right, 4 = Up, 5 = Down (Initial State)
        
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

        #endregion

        public void Initialize()
        {
            faces = new Piece[6, 9];
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
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 5: cols[0] = Color.Red;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
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
                                        cols[1] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 5: cols[0] = Color.Yellow;
                                        cols[1] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
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
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 5: cols[0] = Color.Orange;
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
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
                                        cols[1] = Color.Orange;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 5: cols[0] = Color.White;
                                        cols[1] = Color.Red;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
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
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 5: cols[0] = Color.Green;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
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
                                        cols[1] = Color.White;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Right;
                                        break;
                                    case 5: cols[0] = Color.Blue;
                                        cols[1] = Color.Yellow;
                                        dirs[0] = Direction.Front;
                                        dirs[1] = Direction.Left;
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

        public void Scramble()
        {
 
        }

        public void Process()
        {
 
        }


        private void Rotate(int faceIndex,bool IsClockWiseRotation)
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
            for (int i = 0; i < 9; i++)
            {
                if (faces[faceIndex, i].Kind == PieceKind.Corner)
                {
 
                }
                if (faces[faceIndex, i].Kind == PieceKind.Edge)
                {

                }
            }
        }

        private void RotateCube(Direction Axe,bool IsInverseRotate)
        {
            switch (Axe)
            {
                case Direction.Front:
                    break;
                case Direction.Right:
                    break;
                case Direction.Up:
                    break;
            }
        }
    }
}
