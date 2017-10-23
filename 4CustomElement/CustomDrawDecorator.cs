using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _4CustomElement
{
    public class CustomDrawDecorator : Decorator
    {
       

        public Color BackgroundColor
        {
            get { return (Color)GetValue(CustomDrawElement.BackgroundColorProperty); }
            set { SetValue(CustomDrawElement.BackgroundColorProperty, value); }
        }

        static CustomDrawDecorator()
        {
            //共用同一依赖属性
            CustomDrawElement.BackgroundColorProperty.AddOwner(typeof(CustomDrawDecorator));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //该方法调用OnRender方法
            this.InvalidateVisual();
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            //该方法调用OnRender方法
            this.InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Rect bounds = new Rect(0, 0, base.ActualWidth, base.ActualHeight);
            drawingContext.DrawRectangle(GetForegroundBrush(), null, bounds);
        }
        protected override Size MeasureOverride(Size constraint)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                child.Measure(constraint);
                return child.DesiredSize;
            }
            else
                return new Size();
        }

        private Brush GetForegroundBrush()
        {
            if (!IsMouseOver)
            {
                return new SolidColorBrush(BackgroundColor);
            }
            else
            {
                //RadialGradientBrush 镭射中心范围 必须是 0-1?
                RadialGradientBrush brush = new RadialGradientBrush(Colors.White, BackgroundColor);

                //获取 鼠标点击在窗口上的位置
                Point absoluteGradientOrigin = Mouse.GetPosition(this);
                //将坐标位置 转换为 对应比例的 值 
                Point relativeGradientOrigin = new Point(
                    absoluteGradientOrigin.X / base.ActualWidth,
                    absoluteGradientOrigin.Y / base.ActualHeight);

                brush.RadiusX = 0.2;
                brush.GradientOrigin = relativeGradientOrigin;
                brush.Center = relativeGradientOrigin;

                return brush;
            }
        }

    }
}
