using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LabEngine.IA
{
    public enum HandRule
    {
        Right,
        Left,
    }

    public class WayPoint: Body
    {
        private static Size2D Size = new Size2D(6, 6);

        public WayPoint(float x, float y)
        {
            this.SquareCollider = new SquareCollider(new Point2D(x, y), Size);
        }

        public WayPointMatrix Parent { get; set; }

        public int Id { get; set; }

        private WayPoint wpNorth;
        private WayPoint wpSouth;
        private WayPoint wpEast;
        private WayPoint wpWest;

        public WayPoint North { get { return this.wpNorth; } set { this.wpNorth = value; this.wpNorth.wpSouth = this; } }
        public WayPoint South { get { return this.wpSouth; } set { this.wpSouth = value; this.wpSouth.wpNorth = this; } }
        public WayPoint East { get { return this.wpEast; } set { this.wpEast = value; this.wpEast.wpWest = this; } }
        public WayPoint West { get { return this.wpWest; } set { this.wpWest = value; this.wpWest.wpEast = this; } }

        
        public bool HasNorth {get{ return this.North != null; }}
        public bool HasSouth {get{ return this.South != null; }}
        public bool HasEast  {get{ return this.East  != null; }}
        public bool HasWest  {get{ return this.West  != null; }}


        public WayPoint GetNextWayPoint(WayPoint where, HandRule handRule)
        {
            #region where == this.North
            if (where == this.North)
            {
                switch (handRule)
                {
                    case HandRule.Right:
                        if (this.HasWest) return this.West;
                        if (this.HasSouth) return this.South;
                        if (this.HasEast) return this.East;
                        break;
                    case HandRule.Left:
                        if (this.HasEast) return this.East;
                        if (this.HasSouth) return this.South;
                        if (this.HasWest) return this.West;
                        break;
                }
            }
            #endregion
            #region where == this.South
            else if (where == this.South)
            {
                switch (handRule)
                {
                    case HandRule.Right:
                        if (this.HasEast) return this.East;
                        if (this.HasNorth) return this.North;
                        if (this.HasWest) return this.West;
                        break;
                    case HandRule.Left:
                        if (this.HasWest) return this.West;
                        if (this.HasNorth) return this.North;
                        if (this.HasEast) return this.East;
                        break;
                }
            }
            #endregion
            #region where == this.East
            else if (where == this.East)
            {
                switch (handRule)
                {
                    case HandRule.Right:
                        if (this.HasNorth) return this.North;
                        if (this.HasWest) return this.West;
                        if (this.HasSouth) return this.South;
                        break;
                    case HandRule.Left:
                        if (this.HasSouth) return this.South;
                        if (this.HasWest) return this.West;
                        if (this.HasNorth) return this.North;
                        break;
                }
            }
            #endregion
            #region where == this.West
            else if (where == this.West)
            {
                switch (handRule)
                {
                    case HandRule.Right:
                        if (this.HasSouth) return this.South;
                        if (this.HasEast) return this.East;
                        if (this.HasNorth) return this.North;
                        break;
                    case HandRule.Left:
                        if (this.HasNorth) return this.North;
                        if (this.HasEast) return this.East;
                        if (this.HasSouth) return this.South;
                        break;
                }
            }
            #endregion
            #region where == this
            else if (where == this)
            {
                switch (handRule)
                {
                    case HandRule.Right:
                        if (this.HasSouth) return this.South;
                        if (this.HasEast) return this.East;
                        if (this.HasNorth) return this.North;
                        if (this.HasWest) return this.West;
                        break;
                    case HandRule.Left:
                        if (this.HasNorth) return this.North;
                        if (this.HasEast) return this.East;
                        if (this.HasSouth) return this.South;
                        if (this.HasWest) return this.West;
                        break;
                }
            }
            #endregion

            return where;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, new Rectangle(this.SquareCollider.Position.ToDrawPoint(), this.SquareCollider.Size.ToDrawSize()));
            
            if(this.HasEast)
                g.DrawLine(Pens.Red, this.SquareCollider.Position.ToDrawPoint(), this.East.SquareCollider.Position.ToDrawPoint());
            
            if (this.HasSouth)
                g.DrawLine(Pens.Orange, this.SquareCollider.Position.ToDrawPoint(), this.South.SquareCollider.Position.ToDrawPoint());
        }

    }
}
