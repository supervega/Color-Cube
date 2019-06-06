using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Rubiks_Interface
{
    public class Piece
    {
        private int x;
        private int y;
        private PieceKind kind;

        private Dictionary<Direction, Color> colors;
        
        public Piece(PieceKind k, Color[] cols, Direction[] directions)
        {
            colors = new Dictionary<Direction, Color>();
            kind = k;
            if (cols != null && directions != null)
            {
                switch (k)
                {
                    case PieceKind.Center: colors.Add(directions[0], cols[0]);
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
        }

        public Piece Clone()
        {
            Piece NewPiece = new Piece(kind, null, null);
            NewPiece.x = x;
            NewPiece.y = y;
            NewPiece.colors = new Dictionary<Direction, Color>();
            foreach (KeyValuePair<Direction,Color> item in colors)
            {
                NewPiece.colors.Add(item.Key, item.Value);
            }
            return NewPiece;
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

        public Dictionary<Direction, Color> Colors
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
            }
        }
       
    }
}
