﻿using OpenC1Logic.Xna;
using System;
using System.Collections.Generic;

namespace OpenC1Logic
{
    public class CModelGroup
    {
        //private VertexBuffer _vertexBuffer;
        //private IndexBuffer _indexBuffer;
        //private VertexDeclaration _vertexDeclaration;

        List<CModel> _models = new List<CModel>();
        public List<Vector3> _vertexPositions = new List<Vector3>();
        public List<Vector2> _vertexTextureMap = new List<Vector2>();
        public List<VertexPositionNormalTexture> _vertices;
        public List<ushort> _indices;


        public void Resolve(bool injectHardEdges)
        {

            _vertices = new List<VertexPositionNormalTexture>();
            //ushort indIdx = 0;

            List<UInt16> indices = new List<UInt16>(_vertexPositions.Count);

            foreach (CModel model in _models)
            {
                model.HardEdgesInserted = injectHardEdges;
                model.IndexBufferStart = indices.Count;
                //model.Polygons.Sort(delegate (Polygon p1, Polygon p2) { return p1.MaterialIndex.CompareTo(p2.MaterialIndex); });

                model.Resolve(indices, _vertices, _vertexTextureMap, _vertexPositions);
            }

            if (_vertices.Count > 0)
            {
                //_vertexBuffer = new VertexBuffer(Engine.Device, VertexPositionNormalTexture.SizeInBytes * _vertices.Count, BufferUsage.WriteOnly);
                //_vertexBuffer.SetData<VertexPositionNormalTexture>(_vertices.ToArray());

                //if (!injectHardEdges)
                //{
                //    _indexBuffer = new IndexBuffer(Engine.Device, typeof(UInt16), indices.Count, BufferUsage.WriteOnly);
                //    _indexBuffer.SetData<UInt16>(indices.ToArray());
                //    _indices = indices;
                //}
            }

            //_vertexDeclaration = new VertexDeclaration(Engine.Device, VertexPositionNormalTexture.VertexElements);
            _vertexTextureMap = null; //dont need this data anymore
        }


        public void SetupRender()
        {
            //GraphicsDevice device = Engine.Device;
            //if (_vertexBuffer != null)
            //{
            //    device.Vertices[0].SetSource(_vertexBuffer, 0, VertexPositionNormalTexture.SizeInBytes);
            //    device.Indices = _indexBuffer;
            //}
            //device.VertexDeclaration = _vertexDeclaration;
        }

        public void Add(CModel model)
        {
            _models.Add(model);
        }

        public CModel GetModel(string name)
        {
            return _models.Find(m => m.Name == name);
        }

        public List<CModel> GetModels()
        {
            return _models;
        }
    }
}
