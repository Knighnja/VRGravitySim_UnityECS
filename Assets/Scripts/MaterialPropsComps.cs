using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

[Serializable]
[MaterialProperty("BaseColor_", MaterialPropertyFormat.Float4)]
public struct MaterialBaseColor : IComponentData {
    public float4 Value;
}

[Serializable]
[MaterialProperty("EmitColor_", MaterialPropertyFormat.Float4)]
public struct MaterialEmitColor : IComponentData {
    public float4 Value;
}