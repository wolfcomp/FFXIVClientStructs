using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct CharacterUtility {
    public const int ResourceHandleCount = 87;

    [FieldOffset(0x0)]
    public void* VTable;

    [FieldOffset(0x8)]
    [FixedSizeArray<Pointer<ResourceHandle>>(ResourceHandleCount)]
    public fixed byte ResourceHandles[ResourceHandleCount * sizeof(ulong)];

    [FieldOffset(0x2F8)]
    public ConstantBuffer* LegacyBodyDecalColorCBuffer;
    [FieldOffset(0x300)]
    public ConstantBuffer* FreeCompanyCrestColorCBuffer;

    public ref ResourceHandle* ResourceHandle(int index)
        => ref *(ResourceHandle**)Unsafe.AsPointer(ref ResourceHandles[0]);

    public readonly ConstantBufferPointer<Vector4> LegacyBodyDecalColorTypedCBuffer
        => new(LegacyBodyDecalColorCBuffer);

    public readonly ConstantBufferPointer<Vector4> FreeCompanyCrestColorTypedCBuffer
        => new(FreeCompanyCrestColorCBuffer);

    [StaticAddress("48 8B 05 ?? ?? ?? ?? 83 B9", 3, true)]
    public static partial CharacterUtility* Instance();
}
