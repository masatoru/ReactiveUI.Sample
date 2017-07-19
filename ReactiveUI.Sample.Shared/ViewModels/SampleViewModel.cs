using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace ReactiveUI.Shared.ViewModels
{
    public class SampleViewModel : ReactiveObject
    {
        private string _Text;
        public string Text
        {
            get => _Text;
            set => this.RaiseAndSetIfChanged(ref _Text, value);
        }

        public ReactiveCommand<object> Send { get; private set; }

        public SampleViewModel()
        {
            // We can only send tweets if we have text less that 140 characters
            var canSend = this.WhenAny(vm => vm.Text, s => 
                !String.IsNullOrEmpty(s.Value) && s.Value.Length < 140);
            Send = ReactiveCommand.Create(canSend);

            // What happens when they push the button
            Send.Subscribe(_ => Console.WriteLine("Send Tweet: " + Text));
        }
    }
}
