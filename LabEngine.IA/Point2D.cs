using System;
using System.Collections.Generic;
using System.Text;

namespace LabEngine.IA
{
    public struct Point2D
    {
        public float x, y;

        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D GetLimits(Size2D size)
        {
            return new Point2D(this.x + size.width, this.y + size.height);
        }

        #region Operators

        public static Point2D operator +(Point2D left, Point2D right)
        {
            Point2D result;
            result.x = left.x + right.x;
            result.y = left.y + right.y;
            return result;
        }

        public static Point2D operator -(Point2D left, Point2D right)
        {
            Point2D result;
            result.x = left.x - right.x;
            result.y = left.y - right.y;
            return result;
        }

        public static Point2D operator *(Point2D source, int scalar)
        {
            Point2D result;
            result.x = source.x * scalar;
            result.y = source.y * scalar;
            return result;
        }

        public static Point2D operator *(int scalar, Point2D source)
        {
            Point2D result;
            result.x = scalar * source.x;
            result.y = scalar * source.y;
            return result;
        }

        public static Point2D operator -(Point2D source)
        {
            Point2D result;
            result.x = -source.x;
            result.y = -source.y;
            return result;
        }

        public static bool operator ==(Point2D left, Point2D right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Point2D left, Point2D right)
        {
            return !(left.x == right.x && left.y == right.y);
        }

        #endregion

        #region Base Methods

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is Point2D) && Equals((Point2D)obj);
        }

        public bool Equals(Point2D other)
        {
            return Equals(ref this, ref other);
        }

        public static bool Equals(Point2D left, Point2D right)
        {
            return left.x == right.x && left.y == right.y;
        }

        [CLSCompliant(false)]
        public static bool Equals(ref Point2D left, ref Point2D right)
        {
            return
                left.x == right.x &&
                left.y == right.y;
        }

        #endregion

        public System.Drawing.Point ToDrawPoint()
        {
            return new System.Drawing.Point(Convert.ToInt32(this.x), Convert.ToInt32(this.y));
        }





        public float GetPythagoreanDistance(Point2D ptoTwo)
        {
            float numX = this.x - ptoTwo.x;
            float numY = this.y - ptoTwo.y;
            if (numX == 0)
                return Math.Abs(numY);
            else if (numY == 0)
                return Math.Abs(numX);
            else
                return
                    (float)Math.Sqrt(
                        numX * numX +
                        numY * numY
                    );
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public Point2D GetNormal()
        {
            float magnitude = this.GetMagnitude();
            return new Point2D(this.x / magnitude, this.y / magnitude);
        }

        public Point2D GetMultNormal(float dblMult)
        {
            dblMult /= this.GetMagnitude();
            return new Point2D(this.x * dblMult, this.y * dblMult);
        }
    }
}
