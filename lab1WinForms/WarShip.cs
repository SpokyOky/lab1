﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1WinForms
{
    public class WarShip : WarShipBase, IComparable<WarShip>, IEquatable<WarShip>
    { 
        public WarShip(int maxSpeed, double weight, Color primaryColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            PrimaryColor = primaryColor;
        }

        public WarShip(string info)
        {
            var strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                PrimaryColor = Color.FromName(strs[2]);
            }
        }

        public override void MoveTransport(Direction direction)
        {
            int shift = Convert.ToInt32(MaxSpeed * 100 / Weight);
            switch (direction)
            {
                case Direction.Left:
                    if (posX - shift > 0)
                    {
                        posX -= shift;
                    }
                    break;
                case Direction.Right:
                    if (posX + shift < picWidth - carrierWidht)
                    {
                        posX += shift;
                    }
                    break;
                case Direction.Up:
                    if (posY - shift > 0)
                    {
                        posY -= shift;
                    }
                    break;
                case Direction.Down:
                    if (posY + shift < picHeight - carrierHeight)
                    {
                        posY += shift;
                    }
                    break;
                default:
                    break;
            }
        }

        public override void DrawTransport(Graphics g)
        {
            //тело
            Brush brushPrimary = new SolidBrush(PrimaryColor);
            List<Point> pointsBody = new List<Point>(12);
            pointsBody.Add(new Point(posX + 1, posY + 13));
            pointsBody.Add(new Point(posX + 20, posY + 10));
            pointsBody.Add(new Point(posX + 30, posY + 5));
            pointsBody.Add(new Point(posX + 96, posY + 5));
            pointsBody.Add(new Point(posX + 119, posY + 8));
            pointsBody.Add(new Point(posX + 119, posY + 30));

            pointsBody.Add(new Point(posX + 94, posY + 32));
            pointsBody.Add(new Point(posX + 90, posY + 36));
            pointsBody.Add(new Point(posX + 55, posY + 36));
            pointsBody.Add(new Point(posX + 40, posY + 39));
            pointsBody.Add(new Point(posX + 27, posY + 30));
            pointsBody.Add(new Point(posX + 3, posY + 27));

            g.FillPolygon(brushPrimary, pointsBody.ToArray<Point>());

            brushPrimary.Dispose();  
        }

        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + PrimaryColor.Name;
        }

        public int CompareTo(WarShip other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (PrimaryColor != other.PrimaryColor)
            {
                PrimaryColor.Name.CompareTo(other.PrimaryColor.Name);
            }
            return 0;
        }

        public bool Equals(WarShip other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (PrimaryColor != other.PrimaryColor)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is WarShip warshipObj))
            {
                return false;
            }
            else
            {
                return Equals(warshipObj);
            }
        }
    }
}

