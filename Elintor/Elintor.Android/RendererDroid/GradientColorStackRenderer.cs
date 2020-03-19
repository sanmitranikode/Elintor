﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Elintor.CustomRenderer;
using Elintor.Droid.RendererDroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomStackLayout), typeof(GradientColorStackRenderer))]
namespace Elintor.Droid.RendererDroid
{
    public class GradientColorStackRenderer: VisualElementRenderer<StackLayout>
    {
        public GradientColorStackRenderer(Context context) : base(context)
        {
          
        }
        private Xamarin.Forms.Color StartColor
        {
            get;
            set;
        }
        private Xamarin.Forms.Color EndColor
        {
            get;
            set;
        }
        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            #region for Vertical Gradient  
            //var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,      
            #endregion
            #region  for Horizontal Gradient  
           
            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
        
            this.StartColor.ToAndroid(),
            this.EndColor.ToAndroid(),
            Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            #endregion
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as CustomStackLayout;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                //Syatem.Diagnostics.Debug.WriteLine(@ "ERROR:", ex.Message);
            }
        }
    }
}