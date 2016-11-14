﻿using OpenC1Logic.Parsers.Funks;
using OpenC1Logic.Parsers.Grooves;
using OpenC1Logic.Xna;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OpenC1Logic.Parsers
{
    public class CrushPoint
    {
        public int VertexIndex;
        public float DistanceFromParent;
    }
    public class CrushData
    {
        public int RefVertex;
        public BoundingBox Box;
        public float LeftScale, RightScale, TopScale, BottomScale, FrontScale, RearScale;


        public List<CrushPoint> Points;

        public CrushData()
        {
            Points = new List<CrushPoint>();
        }
    }

    class CrushSection
    {
        public float DamageMultiplier;
        public List<CrushData> Data;

        public CrushSection()
        {
            Data = new List<CrushData>();
        }
    }

    class VehicleFile : BaseTextFile
    {
        public string FileName;
        public List<string> MaterialFiles { get; private set; }
        public List<string> PixFiles { get; private set; }

        public string ActorFile { get; private set; }
        public string BonnetActorFile { get; private set; }
        public List<CrushSection> CrushSections = new List<CrushSection>();
        public List<BaseGroove> Grooves;
        public List<BaseFunk> Funks;
        public List<CWheelActor> WheelActors = new List<CWheelActor>();
        public BoundingBox BoundingBox;
        public List<Vector3> ExtraBoundingBoxPoints = new List<Vector3>();

        public float NonDrivenWheelRadius, DrivenWheelRadius;
        public float RideHeight, SuspensionGiveFront, SuspensionGiveRear;
        public float SuspensionDamping;
        public Vector3 CenterOfMass;
        public float Mass;
        public float TopSpeed, EnginePower;
        public List<int> EngineSoundIds;
        public List<int> DrivenWheelRefs, NonDrivenWheelRefs;
        public List<string> CrashMaterialFiles = new List<string>();
        public Vector3 DriverHeadPosition;
        public string WindscreenMaterial;
        public Vector3 Size;

        public VehicleFile(string filename)
            : base(filename)
        {
            FileName = Path.GetFileName(filename);
            MaterialFiles = new List<string>();
            PixFiles = new List<string>();

            SkipLines(1);
            if (ReadLine() != "START OF DRIVABLE STUFF")
            {
                throw new Exception("Invalid car file: " + filename);
            }
            DriverHeadPosition = ReadLineAsVector3();

            SkipLines(4);  //car name, pratcam shit

            EngineSoundIds = new List<int>(ReadLineAsIntList());

            SkipLines(1); //stealworthy

            //jump over the damage image info

            SkipLinesTillComment("Grid image");

            int nbrLowMemPix = ReadLineAsInt();
            SkipLines(nbrLowMemPix);
            int nbrStdDetailPix = ReadLineAsInt();
            SkipLines(nbrStdDetailPix);

            int nbrHighDetailPix = ReadLineAsInt();

            for (int i = 0; i < nbrHighDetailPix; i++)
                PixFiles.Add(ReadLine());

            int nbrShadeTables = ReadLineAsInt();
            SkipLines(nbrShadeTables);

            if (GameVars.Emulation != EmulationMode.Demo) //demo files have only 1 set of mat entries (TODO: should be txt version based)
            {
                int nbrLowMemMats = ReadLineAsInt();
                SkipLines(nbrLowMemMats);
                int nbrStdDetailMats = ReadLineAsInt();
                SkipLines(nbrStdDetailMats);
            }

            int nbrHighDetailMats = ReadLineAsInt();

            for (int i = 0; i < nbrHighDetailMats; i++)
                MaterialFiles.Add(ReadLine());

            int nbrModels = ReadLineAsInt();
            //Trace.Assert(nbrModels == 3);
            SkipLines(nbrModels);

            int nbrActors = ReadLineAsInt();
            //Trace.Assert(nbrActors == 3);

            for (int i = 0; i < nbrActors; i++)
            {
                string modelRef = ReadLine();  //this is in the format 0,Eagle.act
                int dist = int.Parse(modelRef.Substring(0, modelRef.IndexOf(",")));
                if (dist == -1)
                    BonnetActorFile = modelRef.Substring(modelRef.IndexOf(",") + 1);
                else if (dist == 0)
                    ActorFile = modelRef.Substring(modelRef.IndexOf(",") + 1);
            }

            WindscreenMaterial = ReadLine();
            int nbrSteerableWheels = ReadLineAsInt();
            //Trace.Assert(nbrSteerableWheels == 2);
            for (int i = 0; i < nbrSteerableWheels; i++)
            {
                int wref = ReadLineAsInt();
            }

            SkipLines(4); //suspension refs

            DrivenWheelRefs = new List<int>();
            NonDrivenWheelRefs = new List<int>();

            int[] refs = ReadLineAsIntList();
            foreach (int wref in refs)
                if (wref != -1) DrivenWheelRefs.Add(wref);

            refs = ReadLineAsIntList();
            foreach (int wref in refs)
                if (wref != -1) NonDrivenWheelRefs.Add(wref);

            NonDrivenWheelRadius = ReadLineAsFloat() / 2f;
            DrivenWheelRadius = ReadLineAsFloat() / 2f;

            ReadFunkSection();
            ReadGrooveSection();

            ReadCrushDataSection();

            ReadMechanicsSection();

            int nbrCrashMaterials = ReadLineAsInt();
            for (int i = 0; i < nbrCrashMaterials; i++)
            {
                CrashMaterialFiles.Add(ReadLine());
            }

            CloseFile();
        }

        private void ReadFunkSection()
        {
            //Trace.Assert(ReadLine() == "START OF FUNK");
            Funks = new List<BaseFunk>();
            FunkReader reader = new FunkReader();

            while (!reader.AtEnd)
            {
                BaseFunk f = reader.Read(this);
                if (f != null) Funks.Add(f);
            }
        }

        private void ReadGrooveSection()
        {
            //Trace.Assert(ReadLine() == "START OF GROOVE");
            Grooves = new List<BaseGroove>();
            GrooveReader reader = new GrooveReader();

            while (!reader.AtEnd)
            {
                BaseGroove g = reader.Read(this);
                if (g != null) Grooves.Add(g);
            }
        }

        private void ReadCrushDataSection()
        {
            //3 sections: unused, car model, bonnet model

            for (int i = 0; i < 3; i++)
            {
                CrushSection section = new CrushSection();
                CrushSections.Add(section);

                //Debug.WriteLine("CRUSH " + i);
                section.DamageMultiplier = ReadLineAsFloat(false);
                SkipLines(5); //unk1
                int nbrData = ReadLineAsInt();

                for (int m = 0; m < nbrData; m++)
                {
                    CrushData crushData = new CrushData();
                    section.Data.Add(crushData);

                    crushData.RefVertex = ReadLineAsInt();
                    crushData.Box = new BoundingBox(ReadLineAsVector3(false), ReadLineAsVector3(false));
                    Vector3 v = ReadLineAsVector3(false);
                    crushData.RightScale = v.X;
                    crushData.TopScale = v.Y;
                    crushData.RearScale = v.Z;
                    v = ReadLineAsVector3(false);
                    crushData.LeftScale = v.X;
                    crushData.BottomScale = v.Y;
                    crushData.FrontScale = v.Z;
                    //crushData.MinScale = ReadLineAsVector3(false);
                    //crushData.MaxScale = ReadLineAsVector3(false);

                    int nbrPoints = ReadLineAsInt();
                    int curVertex = -1; // 0;// crushData.RefVertex;

                    for (int p = 0; p < nbrPoints; p++)
                    {
                        CrushPoint point = new CrushPoint();
                        curVertex += ReadLineAsInt();
                        point.VertexIndex = curVertex;
                        point.DistanceFromParent = ReadLineAsFloat(false) / 255f; //values are 0-255 so convert to 0-1
                        crushData.Points.Add(point);
                    }
                }
            }
        }

        private void ReadMechanicsSection()
        {
            string startOfMechanics = ReadLine();
            //Trace.Assert(startOfMechanics.StartsWith("START OF MECHANICS"));

            for (int i = 0; i < 4; i++)
            {
                Vector3 wheelpos = ReadLineAsVector3();
            }

            CenterOfMass = ReadLineAsVector3(true);
            if (startOfMechanics.EndsWith("2"))
            {
                int nbrBoxes = ReadLineAsInt();
                //Trace.Assert(nbrBoxes == 1);
            }
            BoundingBox = new BoundingBox(ReadLineAsVector3(), ReadLineAsVector3());

            if (!startOfMechanics.EndsWith("2"))
            {
                int nbrPoints = ReadLineAsInt();
                for (int i = 0; i < nbrPoints; i++)
                    ExtraBoundingBoxPoints.Add(ReadLineAsVector3());
            }

            SkipLines(1);
            string[] suspGive = ReadLine().Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            SuspensionGiveFront = float.Parse(suspGive[0]);
            SuspensionGiveRear = float.Parse(suspGive[1]);
            RideHeight = ReadLineAsFloat(false);
            SuspensionDamping = ReadLineAsFloat(false);
            Mass = ReadLineAsFloat(false) * 1000;
            SkipLines(2);
            Size = ReadLineAsVector3();

            SkipLines(6);
            TopSpeed = Math.Min(320, ReadLineAsFloat(false));
            EnginePower = ReadLineAsFloat(false);

            //Trace.Assert(ReadLine().StartsWith("END OF MECHANICS"));
        }
    }
}
