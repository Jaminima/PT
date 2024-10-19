using ComputeSharp;
using ComputeSharp.Descriptors;
using ComputeSharp.Interop;

namespace PT_LIb
{
    [ThreadGroupSize(DefaultThreadGroupSizes.X)]
    [GeneratedComputeShaderDescriptor]
    public readonly partial struct MultiplyByTwo(ReadWriteBuffer<float> buffer) : IComputeShader, IComputeShaderDescriptor<MultiplyByTwo>
    {
        public void Execute()
        {
            buffer[ThreadIds.X] *= 2;
        }
    }

    public class Core
    {
        public static void Init()
        {
            Console.WriteLine("Hello, World!");

            var numbers = new float[] { 1, 2, 3, 4, 5 };

            using ReadWriteBuffer<float> buffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer(numbers);

            GraphicsDevice.GetDefault().For(buffer.Length, new MultiplyByTwo(buffer));

            buffer.CopyTo(numbers);
        }
    }
}