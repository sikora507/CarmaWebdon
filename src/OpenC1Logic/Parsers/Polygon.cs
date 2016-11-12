﻿using OpenC1Logic.Xna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenC1Logic.Parsers
{
    public class Polygon
    {
        public UInt16 Vertex1 { get; private set; }
        public UInt16 Vertex2 { get; private set; }
        public UInt16 Vertex3 { get; private set; }
        public Vector3 Normal { get; private set; }


        public int MaterialIndex;
        public bool DoubleSided;
        public CMaterial Material { get; set; }
        public bool Skip;
        public int NbrPrims;

        public Polygon()
        {
        }

        public Polygon(UInt16 v1, UInt16 v2, UInt16 v3)
        {
            Vertex1 = v1;
            Vertex2 = v2;
            Vertex3 = v3;
        }



        public void CalculateNormal(List<Vector3> vertices, int baseIndex)
        {
            //Vector3 ab = vertices[baseIndex + Vertex1] - vertices[baseIndex + Vertex3];
            //Vector3 ac = vertices[baseIndex + Vertex1] - vertices[baseIndex + Vertex2];
            //Normal = Vector3.Cross(ab, ac);
            //Normal.Normalize();
        }
    }
}
