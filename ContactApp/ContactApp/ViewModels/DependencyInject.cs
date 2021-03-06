﻿using System;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class DependencyInject<T> where T : class
    {
        public static T Get()
        {
            return DependencyService.Get<T>() ?? (T) Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}