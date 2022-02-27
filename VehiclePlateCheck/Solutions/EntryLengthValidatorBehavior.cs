using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace VehiclePlateCheck.Solutions
{
    public class EntryLengthValidatorBehavior : Behavior<Xamarin.Forms.Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Xamarin.Forms.Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Xamarin.Forms.Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Xamarin.Forms.Entry)sender;

            if (entry.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 1); 

                entry.Text = entryText;
            }
        }
    }
}
