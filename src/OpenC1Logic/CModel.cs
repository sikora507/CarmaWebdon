﻿using OpenC1Logic.Parsers;
using OpenC1Logic.Xna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenC1Logic
{
    public class CModel
    {
        public string Name { get; set; }
        public List<string> MaterialNames { get; set; }
        public List<Polygon> Polygons { get; set; }
        public int VertexCount { get; set; }
        public int TextureMapCount { get; set; }
        public int VertexBaseIndex { get; set; }
        public int IndexBufferStart { get; set; }
        public bool HardEdgesInserted;

        public virtual void Resolve(List<UInt16> indices, List<VertexPositionNormalTexture> vertices, List<Vector2> vertexTextureMap, List<Vector3> vertexPositions)
        {
            bool injectHardEdges = true;
            Polygon currentPoly = null;

            foreach (Polygon poly in Polygons)
            {
                poly.NbrPrims = 1;
                indices.Add(poly.Vertex1); indices.Add(poly.Vertex2); indices.Add(poly.Vertex3);

                //if (injectHardEdges)
                //{
                //    Vector2 uv = Vector2.Zero;
                //    if (TextureMapCount > 0 && poly.Vertex1 + VertexBaseIndex < vertexTextureMap.Count) uv = vertexTextureMap[poly.Vertex1 + VertexBaseIndex];
                //    vertices.Add(new VertexPositionNormalTexture(vertexPositions[poly.Vertex1 + VertexBaseIndex], poly.Normal, uv));
                //    if (TextureMapCount > 0 && poly.Vertex2 + VertexBaseIndex < vertexTextureMap.Count) uv = vertexTextureMap[poly.Vertex2 + VertexBaseIndex];
                //    vertices.Add(new VertexPositionNormalTexture(vertexPositions[poly.Vertex2 + VertexBaseIndex], poly.Normal, uv));
                //    if (TextureMapCount > 0 && poly.Vertex3 + VertexBaseIndex < vertexTextureMap.Count) uv = vertexTextureMap[poly.Vertex3 + VertexBaseIndex];
                //    vertices.Add(new VertexPositionNormalTexture(vertexPositions[poly.Vertex3 + VertexBaseIndex], poly.Normal, uv));
                //}

                if (MaterialNames != null)
                {
                    CMaterial material;
                    if (poly.MaterialIndex < 0)
                        material = ResourceCache.GetMaterial("drkcurb.mat");
                    else
                        material = ResourceCache.GetMaterial(MaterialNames[poly.MaterialIndex]);

                    if (material != null)
                    {
                        poly.DoubleSided = material.DoubleSided;
                        poly.Material = material;
                    }

                    if (currentPoly != null && poly.MaterialIndex == currentPoly.MaterialIndex)
                    {
                        poly.Skip = true;
                        currentPoly.NbrPrims = currentPoly.NbrPrims + 1;
                    }
                    else
                    {
                        currentPoly = poly;
                    }
                }
            }
            if (!injectHardEdges)
            {
                //for (int i = 0; i < VertexCount; i++)
                //{
                //    Vector3 normal = Polygons[i / 3].Normal;
                //    if (TextureMapCount > 0)
                //        vertices.Add(new VertexPositionNormalTexture(vertexPositions[i + VertexBaseIndex], normal, vertexTextureMap[i + VertexBaseIndex]));
                //    else
                //        vertices.Add(new VertexPositionNormalTexture(vertexPositions[i + VertexBaseIndex], normal, Vector2.Zero));
                //}

                //for (int i = 0; i < indices.Count / 3; i++)
                //{
                //    Vector3 firstvec = vertices[indices[i * 3 + 1]].Position - vertices[indices[i * 3]].Position;
                //    Vector3 secondvec = vertices[indices[i * 3]].Position - vertices[indices[i * 3 + 2]].Position;
                //    Vector3 normal = Vector3.Cross(firstvec, secondvec);
                //    normal.Normalize();
                //    VertexPositionNormalTexture vpnt = vertices[indices[i * 3]];
                //    vpnt.Normal += normal;
                //    vpnt = vertices[indices[i * 3 + 1]];
                //    vpnt.Normal += normal;
                //    vpnt = vertices[indices[i * 3 + 2]];
                //    vpnt.Normal += normal;
                //}
                //for (int i = 0; i < vertices.Count; i++)
                //    vertices[i].Normal.Normalize();
            }
        }

        public virtual void Render(CMaterial actorMaterial)
        {
            //GraphicsDevice device = Engine.Device;

            CMaterial currentMaterial = null;
            int baseVert = VertexBaseIndex;
            int indexBufferStart = IndexBufferStart;

            //for (int i = 0; i < Polygons.Count; i++)
            //{
            //    Polygon poly = Polygons[i];
            //    if (poly.Skip) continue;

            //    if (GameVars.CullingOff != poly.DoubleSided)
            //    {
            //        device.RenderState.CullMode = (poly.DoubleSided ? CullMode.None : CullMode.CullClockwiseFace);
            //        GameVars.CullingOff = poly.DoubleSided;
            //    }


            //    if (poly.Material != null)
            //    {
            //        if (currentMaterial != poly.Material)
            //        {
            //            device.Textures[0] = poly.Material.Texture;
            //            currentMaterial = poly.Material;
            //        }
            //    }
            //    else if (actorMaterial != null)
            //    {
            //        if (currentMaterial != actorMaterial)
            //        {
            //            device.Textures[0] = actorMaterial.Texture;
            //            currentMaterial = actorMaterial;
            //        }
            //    }
            //    else
            //    {
            //        device.Textures[0] = null; currentMaterial = null;
            //    }

            //    if (currentMaterial != null && currentMaterial.Funk != null)
            //    {
            //        currentMaterial.Funk.BeforeRender();
            //    }
            //    GameVars.NbrDrawCalls++;
            //    if (!HardEdgesInserted)
            //        Engine.Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, baseVert, 0, 3 * poly.NbrPrims, indexBufferStart, poly.NbrPrims);
            //    else
            //        Engine.Device.DrawPrimitives(PrimitiveType.TriangleList, indexBufferStart, poly.NbrPrims);
            //    indexBufferStart += poly.NbrPrims * 3;

            //    if (currentMaterial != null && currentMaterial.Funk != null)
            //    {
            //        currentMaterial.Funk.AfterRender();
            //    }
            //}
        }
    }
}
