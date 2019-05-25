using System;
using Xamarin.Forms;
namespace XamarinFormBehavior
{
    public class BackgroundColorChangeBehavior : Behavior<Picker>
    {
        protected override void OnAttachedTo(Picker bindable)
        {
            bindable.SelectedIndexChanged += OnItemChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            bindable.SelectedIndexChanged -= OnItemChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnItemChanged(object sender, EventArgs args)
        {
            var item = sender as Picker;

            switch (item.SelectedIndex)
            {
                case 1:
                    item.BackgroundColor = Color.Cyan;
                    break;
                case 2:
                    item.BackgroundColor = Color.Yellow;
                    break;
                case 3:
                    item.BackgroundColor = Color.Green;
                    break;
                case 4:
                    item.BackgroundColor = Color.Brown;
                    break;
                default:
                    item.BackgroundColor = Color.Default;
                    break;
            }
        }
    }
}
