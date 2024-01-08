﻿namespace Blitz3DDecomp.MidLevel;

sealed record AllocateDimStatement(DimArray Dim, params Expression[] Dimensions) : Statement
{
    public override string StringRepresentation
        => $"Dim {Dim.Name}{Dim.ElementDeclType.Suffix}({string.Join(", ", Dimensions.Select(d => d.StringRepresentation))})";
}