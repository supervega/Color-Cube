using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_Cube
{
    public class Piece
    {
        private int x;
        private int y;
        private int z;
        private PieceKind kind;

        private Dictionary<Direction,object> colors;

        private object model;

        public Piece(PieceKind k,object[] cols,Direction[] directions)
        {
            colors = new Dictionary<Direction, object>();
            switch (k)
            {
                case PieceKind.Center: colors.Add(directions[0],cols[0]);
                    break;
                case PieceKind.Edge: colors.Add(directions[0], cols[0]);
                    colors.Add(directions[1], cols[1]);
                    break;
                case PieceKind.Corner: colors.Add(directions[0], cols[0]);
                    colors.Add(directions[1], cols[1]);
                    colors.Add(directions[2], cols[2]);
                    break;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public int Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public PieceKind Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }

        public Dictionary<Direction, object> Colors
        {
            get
            {
                return colors;
            }
        }

        public object Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
    }
}
