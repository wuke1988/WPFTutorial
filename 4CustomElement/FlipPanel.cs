using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace _4CustomElement
{
    [TemplatePart(Name = "PART_FlipButton", Type = typeof(ToggleButton))]
    [TemplatePart(Name = "PART_FlipButtonAlternate", Type = typeof(ToggleButton))]
    [TemplateVisualState(Name = "Normal",GroupName ="ViewStates")]
    [TemplateVisualState(Name = "Flipped", GroupName = "ViewStates")]
    public class FlipPanel: System.Windows.Controls.Control
    {
        public static readonly DependencyProperty FrontContentProperty;

        public object FrontContent
        {
            get { return GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty,value); }
        }

        public static readonly DependencyProperty BackContentProperty;

        public object BackContent
        {
            get { return GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        public static readonly DependencyProperty IsFlippedProperty;

        public bool IsFlipped
        {
            get { return (bool)GetValue(IsFlippedProperty); }
            set
            {
                SetValue(IsFlippedProperty,value);
                ChangeVisualState(true);
            }
        }

        public static readonly DependencyProperty CornerRadiusProperty;
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        static FlipPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel),new FrameworkPropertyMetadata(typeof(FlipPanel)));

            FrontContentProperty = DependencyProperty.Register("FrontContent",typeof(object),typeof(FlipPanel));
            BackContentProperty = DependencyProperty.Register("BackContent", typeof(object), typeof(FlipPanel));
            IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipPanel));
            CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(bool), typeof(FlipPanel));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ToggleButton flipButton = base.GetTemplateChild("PART_FlipButton") as ToggleButton;
            if(flipButton!=null)
                flipButton.Click += FlipButton_Click;

            this.ChangeVisualState(false);
        }

        private void FlipButton_Click(object sender, RoutedEventArgs e)
        {
            IsFlipped = !this.IsFlipped;
        }
        /// <summary>
        /// 实现两个visualState状态的更换
        /// 通过静态方法 VisualStateManager.GoToState()
        /// @useTransitions:判断是否需要显示过渡效果；true:显示；
        /// </summary>
        /// <param name="useTransitions"></param>
        private void ChangeVisualState(bool useTransitions)
        {
            if (!IsFlipped)
            {
                //传递正在改变状态的控件的对象引用，状态名称，是否显示过渡的bool值
                VisualStateManager.GoToState(this, "Normal", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Flipped", useTransitions);
            }

            UIElement front = FrontContent as UIElement;

            if (front != null)
            {
                if (IsFlipped)
                    front.Visibility = Visibility.Hidden;
                else
                    front.Visibility = Visibility.Visible;
            }

            UIElement back = BackContent as UIElement;

            if (back != null)
            {
                if (IsFlipped)
                    back.Visibility = Visibility.Visible;
                else
                    back.Visibility = Visibility.Hidden;
            }
        }
    }
}
