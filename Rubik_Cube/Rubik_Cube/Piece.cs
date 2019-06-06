using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rubik_Cube
{
    public class Piece
    {
        private int x;
        private int y;
        private PieceKind kind;

        private Dictionary<Direction, Color> colors;

        private Model model;
        private Matrix viewMatrix;
        private Matrix projectionMatrix;
        private Matrix orientation;

        public Piece(PieceKind k, Color[] cols, Direction[] directions)
        {
            colors = new Dictionary<Direction, Color>();
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

        public Model PieceModel
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

        public Matrix ViewMatrix
        {
            get
            {
                return viewMatrix;
            }
            set
            {
                viewMatrix = value;
            }
        }

        public Matrix ProjectionMatrix
        {
            get
            {
                return projectionMatrix;
            }
            set
            {
                projectionMatrix = value;
            }
        }

        public Matrix Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }
    }
}
