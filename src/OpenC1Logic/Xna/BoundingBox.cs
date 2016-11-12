using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenC1Logic.Xna
{
    public struct BoundingBox
    {
        // Summary:
        //     The maximum point the BoundingBox contains.
        public Vector3 Max;
        //
        // Summary:
        //     The minimum point the BoundingBox contains.
        public Vector3 Min;

        //
        // Summary:
        //     Creates an instance of BoundingBox. Reference page contains links to related
        //     conceptual articles.
        //
        // Parameters:
        //   min:
        //     The minimum point the BoundingBox includes.
        //
        //   max:
        //     The maximum point the BoundingBox includes.
        public BoundingBox(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }
    }
}
