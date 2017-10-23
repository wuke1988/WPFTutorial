using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _4CustomElement
{
    public class CustomDrawElement:FrameworkElement
    {
        public static DependencyProperty BackgroundColorProperty;

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty,value); }
        }

        static CustomDrawElement()
        {
            FrameworkPropertyMetadata metadata = 
                new FrameworkPropertyMetadata(Colors.Yellow);
            //依赖属性发生变化时 需要重新绘制底图
            metadata.AffectsRender = true;

            BackgroundColorProperty = DependencyProperty.Register("BackgroundColor",
                typeof(Color),typeof(CustomDrawElement),metadata);
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

            Rect bounds = new Rect(0,0,base.ActualWidth,base.ActualHeight);
            drawingContext.DrawRectangle(GetForegroundBrush(), null,bounds);
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
                RadialGradientBrush brush = new RadialGradientBrush(Colors.White,BackgroundColor);

                //获取 鼠标点击在窗口上的位置
                Point absoluteGradientOrigin = Mouse.GetPosition(this);
                //将坐标位置 转换为 对应比例的 值 
                Point relativeGradientOrigin = new Point(
                    absoluteGradientOrigin.X/base.ActualWidth,
                    absoluteGradientOrigin.Y/base.ActualHeight);

                brush.GradientOrigin = relativeGradientOrigin;
                brush.Center = relativeGradientOrigin;

                return brush;
            }
        }
    }
}
