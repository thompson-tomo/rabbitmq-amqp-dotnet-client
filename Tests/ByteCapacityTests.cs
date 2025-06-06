// This source code is dual-licensed under the Apache License, version 2.0,
// and the Mozilla Public License, version 2.0.
// Copyright (c) 2017-2024 Broadcom. All Rights Reserved. The term "Broadcom" refers to Broadcom Inc. and/or its subsidiaries.

using System;
using RabbitMQ.AMQP.Client;
using Xunit;

namespace Tests;

public class ByteCapacityTests
{
    [Theory]
    [InlineData("1b", 1)]
    [InlineData("1B", 1)]
    [InlineData("2kb", 2000)]
    [InlineData("1KB", 1000)]
    [InlineData("1mb", 1000 * 1000)]
    [InlineData("32MB", 32 * 1000 * 1000)]
    [InlineData("1gb", 1000 * 1000 * 1000)]
    [InlineData("28GB", 28 * 1000L * 1000L * 1000L)]
    [InlineData("1tb", 1000L * 1000L * 1000L * 1000L)]
    [InlineData("23TB", 23 * 1000L * 1000L * 1000L * 1000L)]
    public void FromShouldReturnTheCorrectBytesValues(string input, long expectedBytes)
    {
        Assert.Equal(expectedBytes, (ByteCapacity)input);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("-1")]
    [InlineData("!1.2")]
    [InlineData("-1.2b")]
    [InlineData("1.2kb")]
    [InlineData("1.2hb")]
    [InlineData("1.2gb")]
    [InlineData("1.2tb")]

    public void FromShouldThrowExceptionWhenInvalidInput(string input)
    {
        Assert.Throws<ArgumentException>(() => (ByteCapacity)input);
    }

    [Fact]
    public void ByteCapacityShouldReturnTheValidBytes()
    {
        Assert.Equal(99, (long)ByteCapacity.B(99));
        Assert.Equal(76000, (long)ByteCapacity.Kb(76));
        Assert.Equal(789 * 1000 * 1000, (long)ByteCapacity.Mb(789));
        Assert.Equal(134 * 1000L * 1000L * 1000L, (long)ByteCapacity.Gb(134));
        Assert.Equal(12 * 1000L * 1000L * 1000L * 1000L, (long)ByteCapacity.Tb(12));
    }

    [Theory]
    [InlineData(9, 9 * 1000)]
    [InlineData(76, 76 * 1000)]
    public void KbByteCapacityShouldBeEqualToB(long value, long expectedBytes)
    {
        Assert.Equal(ByteCapacity.Kb(value), ByteCapacity.B(expectedBytes));
    }

    [Theory]
    [InlineData(9, 9 * 1000L * 1000L * 1000L)]
    [InlineData(76, 76 * 1000L * 1000L * 1000L)]
    public void GbByteCapacityShouldBeEqualToB(long value, long expectedBytes)
    {
        Assert.Equal(ByteCapacity.Gb(value), ByteCapacity.B(expectedBytes));
    }
}
