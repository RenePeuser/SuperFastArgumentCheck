﻿using System;
using System.Diagnostics;
using System.Linq;

namespace SuperFastArgumentCheck
{
    public static class Expect
    {
        public static T NotNull<T>(this T item)
        {
            if (item == null)
            {
                var stackTrace = new StackTrace();
                var frame = stackTrace.GetFrame(1);
                var parameter = frame.GetMethod().GetParameters().FirstOrDefault();
                throw new ArgumentNullException(parameter?.Name);
            }
            return item;
        }
    }
}