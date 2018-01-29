using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LabEngine.IA
{
    public class WayPointMatrix
    {
        private WayPoint[,] internalMatrix;

        private int nextId = 0;

        public WayPointMatrix(int columns, int rows)
        {
            this.internalMatrix = new WayPoint[columns, rows];
        }

        public WayPoint this[int x, int y]
        {
            get
            {
                return this.internalMatrix[x, y];
            }
        }

        public WayPoint Set(WayPoint wp, int x, int y)
        {
            this.internalMatrix[x, y] = wp;

            if (wp != null)
            {
                wp.Parent = this;
                wp.Id = this.nextId;
                this.nextId++;
            }

            return wp;
        }

        public WayPoint FindById(int id)
        {
            WayPoint aux;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    aux = this.internalMatrix[x, y];
                    if (aux != null && aux.Id == id)
                        return aux;
                }
            }
            return null;
        }

        public void SetNorth(int id, int idTarget)
        {
            WayPoint wp = this.FindById(id);
            if (wp == null)
                return;

            WayPoint target = this.FindById(idTarget);
            if (target == null)
                return;

            wp.North = target;
        }

        public void SetSouth(int id, int idTarget)
        {
            WayPoint wp = this.FindById(id);
            if (wp == null)
                return;

            WayPoint target = this.FindById(idTarget);
            if (target == null)
                return;

            wp.South = target;
        }

        public void SetEast(int id, int idTarget)
        {
            WayPoint wp = this.FindById(id);
            if (wp == null)
                return;

            WayPoint target = this.FindById(idTarget);
            if (target == null)
                return;

            wp.East = target;
        }

        public void SetWest(int id, int idTarget)
        {
            WayPoint wp = this.FindById(id);
            if (wp == null)
                return;

            WayPoint target = this.FindById(idTarget);
            if (target == null)
                return;

            wp.West = target;
        }

        public void Draw(Graphics g)
        {
            WayPoint aux;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    aux = this.internalMatrix[x, y];
                    if (aux != null)
                        aux.Draw(g);
                }
            }            
        }

        public bool IsColliding(Car car)
        {
            WayPoint aux;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    aux = this.internalMatrix[x, y];
                    if (aux != null)
                    {
                        if (aux.SquareCollider.IsColliding(car.SquareCollider))
                        {
                            car.OnCollision(aux, CollisionType.Square, -1);
                        }
                    }
                }
            }
            return false;
        }
    }
}
