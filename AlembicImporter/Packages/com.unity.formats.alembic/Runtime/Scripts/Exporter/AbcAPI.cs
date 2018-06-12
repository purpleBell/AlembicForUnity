using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UnityEngine.Formats.Alembic.Sdk
{
    public enum aeArchiveType
    {
        HDF5,
        Ogawa,
    };

    public enum aeTimeSamplingType
    {
        Uniform = 0,
        // Cyclic = 1,
        Acyclic = 2,
    };

    public enum aeXformType
    {
        Matrix,
        TRS,
    };

    public enum aeTopology
    {
        Points,
        Lines,
        Triangles,
        Quads,
    };

    public enum aePropertyType
    {
        Unknown,

        // scalar types
        Bool,
        Int,
        UInt,
        Float,
        Float2,
        Float3,
        Float4,
        Float4x4,

        // array types
        BoolArray,
        IntArray,
        UIntArray,
        FloatArray,
        Float2Array,
        Float3Array,
        Float4Array,
        Float4x4Array,

        ScalarTypeBegin = Bool,
        ScalarTypeEnd = Float4x4,

        ArrayTypeBegin = BoolArray,
        ArrayTypeEnd = Float4x4Array,
    };

    [Serializable]
    public struct aeConfig
    {
        private aeArchiveType archiveType;
        public aeArchiveType ArchiveType
        {
            get { return archiveType; }
            set { archiveType = value; }
        }
        private aeTimeSamplingType timeSamplingType;
        public aeTimeSamplingType TimeSamplingType
        {
            get { return timeSamplingType; }
            set { timeSamplingType = value; }
        }
        private float frameRate;
        public float FrameRate
        {
            get { return frameRate; }
            set { frameRate = value; }
        }
        private aeXformType xformType;
        public aeXformType XformType
        {
            get { return xformType; }
            set { xformType = value; }
        }
        private Bool swapHandedness;
        public Bool SwapHandedness
        {
            get { return swapHandedness; }
            set { swapHandedness = value; }
        }
        private Bool swapFaces;
        public Bool SwapFaces
        {
            get { return swapFaces; }
            set { swapFaces = value; }
        }
        private float scaleFactor;
        public float ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }

        public static aeConfig defaultValue
        {
            get
            {
                return new aeConfig
                {
                    ArchiveType = aeArchiveType.Ogawa,
                    TimeSamplingType = aeTimeSamplingType.Uniform,
                    FrameRate = 30.0f,
                    XformType = aeXformType.TRS,
                    SwapHandedness = true,
                    SwapFaces = false,
                    ScaleFactor = 100.0f,
                };
            }
        }
    }

    public struct aeXformData
    {
        private Bool visibility;
        public Bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        private Vector3 translation;
        public Vector3 Translation
        {
            get { return translation; }
            set { translation = value; }
        }

        private Quaternion rotation;
        public Quaternion Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        private Vector3 scale;
        public Vector3 Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        private Bool inherits;
        public Bool Inherits
        {
            get { return inherits; }
            set { inherits = value; }
        }
    }

    public struct aePointsData
    {
        private Bool visibility;
        public Bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        private IntPtr positions; // Vector3*
        public IntPtr Positions
        {
            get { return positions; }
            set { positions = value; }
        }

        private IntPtr velocities; // Vector3*. can be null
        public IntPtr Velocities
        {
            get { return velocities; }
            set { velocities = value; }
        }

        private IntPtr ids; // uint*. can be null
        public IntPtr Ids
        {
            get { return ids; }
            set { ids = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }


    public struct aeSubmeshData
    {
        private IntPtr indexes;
        public IntPtr Indexes
        {
            get { return indexes; }
            set { indexes = value; }
        }

        private int indexCount;
        public int IndexCount
        {
            get { return indexCount; }
            set { indexCount = value; }
        }

        private aeTopology topology;
        public aeTopology Topology
        {
            get { return topology; }
            set { topology = value; }
        }
    };

    internal struct aePolyMeshData
    {
        private Bool visibility;
        public Bool Visibility { get; set; }

        private IntPtr faces; // int*. if null, assume all faces are triangles
        public IntPtr Faces { get; set; }

        private IntPtr indexes; // int*. 
        public IntPtr  Indexes { get; set; }

        private int faceCount;
        public int FaceCount
        {
            get { return faceCount; }
            set { faceCount = value; }
        }

        private int indexCount;
        public int IndexCount
        {
            get { return indexCount; }
            set { indexCount = value; }
        }

        private IntPtr points; // Vector3*
        public IntPtr   Points
        {
            get { return points; }
            set { points = value; }
        }

        private IntPtr velocities; // Vector3*. can be null
        public IntPtr   Velocities
        {
            get { return velocities; }
            set { velocities = value; }
        }

        private int pointCount;
        public int PointCount
        {
            get { return pointCount; }
            set { pointCount = value; }
        }

        public IntPtr   normals;          // Vector3*. can be null
        public IntPtr   normalIndices;    // int*. if null, assume same as indices
        public int      normalCount;      // if 0, assume same as pointCount
        public int      normalIndexCount; // if 0, assume same as indexCount

        public IntPtr   uv0;              // Vector2*. can be null
        public IntPtr   uv0Indices;       // int*. if null, assume same as indices
        public int      uv0Count;         // if 0, assume same as pointCount
        public int      uv0IndexCount;    // if 0, assume same as indexCount
        
        public IntPtr   uv1;              // Vector2*. can be null
        public IntPtr   uv1Indices;       // int*. if null, assume same as indices
        public int      uv1Count;         // if 0, assume same as pointCount
        public int      uv1IndexCount;    // if 0, assume same as indexCount
        
        public IntPtr   colors;           // Vector2*. can be null
        public IntPtr   colorIndices;     // int*. if null, assume same as indices
        public int      colorCount;       // if 0, assume same as pointCount
        public int      colorIndexCount;  // if 0, assume same as indexCount

        public IntPtr   submeshes;        // aeSubmeshData*. can be null
        public int      submeshCount;
    }

    internal struct aeFaceSetData
    {
        public IntPtr faces;
        public int faceCount;
    }

    internal struct aeCameraData
    {
        public Bool visibility;

        public float nearClippingPlane;
        public float farClippingPlane;
        public float fieldOfView;   // in degree. relevant only if focalLength==0.0 (default)
        public float aspectRatio;

        public float focusDistance; // in cm
        public float focalLength;   // in mm. if 0.0f, automatically computed by aperture and fieldOfView. alembic's default value is 0.035f.
        public float aperture;      // in cm. vertical one

        public static aeCameraData defaultValue
        {
            get
            {
                return new aeCameraData
                {
                    nearClippingPlane = 0.3f,
                    farClippingPlane = 1000.0f,
                    fieldOfView = 60.0f,
                    aspectRatio = 16.0f / 9.0f,
                    focusDistance = 5.0f,
                    focalLength = 0.0f,
                    aperture = 2.4f,
                };
            }
        }
    }

    internal struct aeContext
    {
        public IntPtr self;

        public aeObject topObject { get { return NativeMethods.aeGetTopObject(self); } }

        public static aeContext Create() { return NativeMethods.aeCreateContext(); }
        public void Destroy() { NativeMethods.aeDestroyContext(self); self = IntPtr.Zero; }
        public void SetConfig(ref aeConfig conf) { NativeMethods.aeSetConfig(self, ref conf); }
        public bool OpenArchive(string path) { return NativeMethods.aeOpenArchive(self, path); }
        public int AddTimeSampling(float start_time) { return NativeMethods.aeAddTimeSampling(self, start_time); }
        public void AddTime(float start_time) { NativeMethods.aeAddTime(self, start_time); }
        public void MarkFrameBegin() { NativeMethods.aeMarkFrameBegin(self); }
        public void MarkFrameEnd() { NativeMethods.aeMarkFrameEnd(self); }
    }

    internal struct aeObject
    {
        public IntPtr self;

        public aeObject NewXform(string name, int tsi) { return NativeMethods.aeNewXform(self, name, tsi); }
        public aeObject NewCamera(string name, int tsi) { return NativeMethods.aeNewCamera(self, name, tsi); }
        public aeObject NewPoints(string name, int tsi) { return NativeMethods.aeNewPoints(self, name, tsi); }
        public aeObject NewPolyMesh(string name, int tsi) { return NativeMethods.aeNewPolyMesh(self, name, tsi); }

        public void WriteSample(ref aeXformData data) { NativeMethods.aeXformWriteSample(self, ref data); }
        public void WriteSample(ref aeCameraData data) { NativeMethods.aeCameraWriteSample(self, ref data); }

        public void WriteSample(ref aePolyMeshData data) { NativeMethods.aePolyMeshWriteSample(self, ref data); }
        public void AddFaceSet(string name) { NativeMethods.aePolyMeshAddFaceSet(self, name); }

        public void WriteSample(ref aePointsData data) { NativeMethods.aePointsWriteSample(self, ref data); }

        public aeProperty NewProperty(string name, aePropertyType type) { return NativeMethods.aeNewProperty(self, name, type); }

        public void MarkForceInvisible() { NativeMethods.aeMarkForceInvisible(self); }
    }

    internal struct aeProperty
    {
        public IntPtr self;

        public void WriteArraySample(IntPtr data, int numData) { NativeMethods.aePropertyWriteArraySample(self, data, numData); }

        public void WriteScalarSample(ref float data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
        public void WriteScalarSample(ref int data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
        public void WriteScalarSample(ref Bool data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
        public void WriteScalarSample(ref Vector2 data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
        public void WriteScalarSample(ref Vector3 data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
        public void WriteScalarSample(ref Vector4 data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
        public void WriteScalarSample(ref Matrix4x4 data) { NativeMethods.aePropertyWriteScalarSample(self, ref data); }
    }



    public static partial class AbcAPI
    {
        public static void aeWaitMaxDeltaTime()
        {
            var next = Time.unscaledTime + Time.maximumDeltaTime;
            while (Time.realtimeSinceStartup < next)
                System.Threading.Thread.Sleep(1);
        }
    }

    internal static class NativeMethods
    {
        [DllImport(Abci.Lib)] public static extern aeContext aeCreateContext();
        [DllImport(Abci.Lib)] public static extern void aeDestroyContext(IntPtr ctx);

        [DllImport(Abci.Lib)] public static extern void aeSetConfig(IntPtr ctx, ref aeConfig conf);
        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern Bool aeOpenArchive(IntPtr ctx, string path);
        [DllImport(Abci.Lib)] public static extern aeObject aeGetTopObject(IntPtr ctx);
        [DllImport(Abci.Lib)] public static extern int aeAddTimeSampling(IntPtr ctx, float start_time);
        // relevant only if plingType is acyclic. if tsi==-1, add time to all time samplings.
        [DllImport(Abci.Lib)] public static extern void aeAddTime(IntPtr ctx, float time, int tsi = -1);
        [DllImport(Abci.Lib)] public static extern void aeMarkFrameBegin(IntPtr ctx);
        [DllImport(Abci.Lib)] public static extern void aeMarkFrameEnd(IntPtr ctx);


        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern aeObject aeNewXform(IntPtr self, string name, int tsi);
        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern aeObject aeNewCamera(IntPtr self, string name, int tsi);
        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern aeObject aeNewPoints(IntPtr self, string name, int tsi);
        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern aeObject aeNewPolyMesh(IntPtr self, string name, int tsi);
        [DllImport(Abci.Lib)] public static extern void aeXformWriteSample(IntPtr self, ref aeXformData data);
        [DllImport(Abci.Lib)] public static extern void aeCameraWriteSample(IntPtr self, ref aeCameraData data);
        [DllImport(Abci.Lib)] public static extern void aePolyMeshWriteSample(IntPtr self, ref aePolyMeshData data);
        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern int aePolyMeshAddFaceSet(IntPtr self, string name);
        [DllImport(Abci.Lib)] public static extern void aePointsWriteSample(IntPtr self, ref aePointsData data);
        [DllImport(Abci.Lib, CharSet = CharSet.Unicode)] public static extern aeProperty aeNewProperty(IntPtr self, string name, aePropertyType type);
        [DllImport(Abci.Lib)] public static extern void aeMarkForceInvisible(IntPtr self);


        [DllImport(Abci.Lib)] public static extern void aePropertyWriteArraySample(IntPtr self, IntPtr data, int num_data);

        // all of these are  IntPtr version. just for convenience.
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref float data);
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref int data);
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref Bool data);
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref Vector2 data);
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref Vector3 data);
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref Vector4 data);
        [DllImport(Abci.Lib)] public static extern void aePropertyWriteScalarSample(IntPtr self, ref Matrix4x4 data);


        [DllImport("abci")] public static extern int aeGenerateRemapIndices(IntPtr dstIndices, IntPtr points, IntPtr weights4, int numPoints);
        [DllImport("abci")] public static extern void aeApplyMatrixP(IntPtr dstPoints, int num, ref Matrix4x4 mat);
        [DllImport("abci")] public static extern void aeApplyMatrixV(IntPtr dstVectors, int num, ref Matrix4x4 mat);
    }
}
