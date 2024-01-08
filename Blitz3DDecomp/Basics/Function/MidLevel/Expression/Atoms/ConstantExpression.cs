﻿namespace Blitz3DDecomp.MidLevel;

sealed record ConstantExpression(string Value) : Expression
{
    public override string StringRepresentation
        => Value;
}