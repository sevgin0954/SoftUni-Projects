﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Intersection_of_Circles
{
    public class Circle
    {
        public double Raduis { get; set; }
        public double x1 { get; set; }
        public double y1 { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var xYandRadusC1 = Console.ReadLine().Split().Select(double.Parse).ToList();
            var xYandRadusC2 = Console.ReadLine().Split().Select(double.Parse).ToList();


            Circle firstCircle = new Circle();
            firstCircle.x1 = xYandRadusC1[0];
            firstCircle.y1 = xYandRadusC1[1];
            firstCircle.Raduis = xYandRadusC1[2];


            Circle secondCircle = new Circle();
            secondCircle.x1 = xYandRadusC2[0];
            secondCircle.y1 = xYandRadusC2[1];
            secondCircle.Raduis = xYandRadusC2[2];

            if (Intersect(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        private static bool Intersect(Circle firstCircle, Circle secondCircle)
        {

            double distance = 0;
            distance = Math.Sqrt(Math.Pow(secondCircle.x1 - firstCircle.x1, 2) + Math.Pow(secondCircle.y1 - firstCircle.y1, 2));
            if (distance <= firstCircle.Raduis + secondCircle.Raduis)
            {
                return true;
            }
            else if (distance > firstCircle.Raduis + secondCircle.Raduis)
            {
                return false;
            }
            return false;
        }

    }
}