// This source code is dual-licensed under the Apache License, version 2.0,
// and the Mozilla Public License, version 2.0.
// Copyright (c) 2017-2024 Broadcom. All Rights Reserved. The term "Broadcom" refers to Broadcom Inc. and/or its subsidiaries.

namespace RabbitMQ.AMQP.Client
{
    public static class Consts
    {
        public const string Exchanges = "exchanges";
        public const string Key = "key";
        public const string Queues = "queues";
        public const string Bindings = "bindings";
        public const string Messages = "messages";

        /// <summary>
        /// <code>uint.MinValue</code> means "no limit"
        /// </summary>
        public const uint DefaultMaxFrameSize = uint.MinValue; // NOTE: Azure/amqpnetlite uses 256 * 1024

        /// <summary>
        /// The default virtual host, <c>/</c>
        /// </summary>
        public const string DefaultVirtualHost = "/";
    }
}
