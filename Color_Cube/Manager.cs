using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_Cube
{
    public enum Direction { Up, Down, Left, Right, Front, Back }
    public enum PieceKind { Center, Edge, Corner }

    public class Manager
    {
        private Piece[,] faces; 

        public Manager()
        {
            faces=new Piece[6,9];
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
 
        }

        public void Scramble()
        {
 
        }

        public void Process()
        {
 
        }


        private void Rotate(Direction Face,bool IsClockWiseRotation)
        {
            switch (Face)
            {
                case Direction.Back:
                    break;
                case Direction.Down:
                    break;
                case Direction.Front:
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
                case Direction.Up:
                    break;
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
