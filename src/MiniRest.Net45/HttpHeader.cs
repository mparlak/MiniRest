﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest
{
    /// <summary>
    /// Representation of an HTTP header
    /// </summary>
    public class HttpHeader
    {
        /// <summary>
        /// Name of the header
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the header
        /// </summary>
        public string Value { get; set; }
    }
}
