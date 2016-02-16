﻿using System;
using System.Windows;
using System.Windows.Interactivity;
using KonigLabs.SpriteEvent.CommonView.Helpers;
using KonigLabs.SpriteEvent.CommonView.Windows;
using KonigLabs.SpriteEvent.CommonViewModels.Behaviors;

namespace KonigLabs.SpriteEvent.CommonView.Behaviors
{
    public class WindowContainerBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.Loaded += delegate
            {
                IWindowContainer container = AssociatedObject.DataContext as IWindowContainer;
                if (container != null)
                    container.ShowWindow += (sender, args) =>
                    {
                        var window = new DialogChildWindow { DataContext = args.Context };
                        window.Owner = this.AssociatedObject;

                        window.Loaded += (o, eventArgs) => Application.Current.Dispatcher.BeginInvoke(new Action(() => window.SetWindowCloseStatus(false)));

                        if (args.IsDialog)
                        {
                            window.ShowDialog();
                        }
                        else
                        {
                            window.Show();
                        }
                    };
            };
        }
    }
}
